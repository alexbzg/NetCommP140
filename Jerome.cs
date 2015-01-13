﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;

namespace Jerome
{
    public class StateObject
    {
        // Size of receive buffer.
        public const int BufferSize = 256;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
        //received data callback
        public Func<string> reCb;
    }

    public class JeromeController
    {
        class CmdEntry
        {
            public string cmd;
            public Action<string> cb;

            public CmdEntry(string cmdE, Action<string> cbE)
            {
                cmd = cmdE;
                cb = cbE;
            }
        }

        private static int timeout = 1000;
        private static Regex rEVT = new Regex(@"#EVT,IN,\d+,(\d+),(\d)"); 
        
        // ManualResetEvent instances signal completion.
        private ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        private IPEndPoint remoteEP;
        private string password;
        private volatile Socket socket;

        private volatile CmdEntry currentCmd = null;
        private Object cmdQueeLock = new Object();
        private List<CmdEntry> cmdQuee = new List<CmdEntry>();
        private Timer replyTimer;

        public bool connected
        {
            get
            {
                return socket != null && socket.Connected;
            }
        }

        public static JeromeController create(string host, int port, string password)
        {
            IPAddress hostIP;
            if (IPAddress.TryParse(host, out hostIP))
            {
                JeromeController jc = new JeromeController();
                jc.remoteEP = new IPEndPoint(hostIP, port);
                jc.password = password;
                return jc;
            }
            else
            {
                return null;
            }
        }

        private void newCmd(string cmd, Action<string> cb)
        {
            CmdEntry ce = new CmdEntry( cmd, cb );
            lock (cmdQueeLock)
            {
                cmdQuee.Add(ce);
            }
            if (currentCmd == null)
                processQuee();
        }

        private void processQuee()
        {
            if (cmdQuee.Count > 0 && currentCmd == null)
            {
                lock (cmdQueeLock)
                {
                    currentCmd = cmdQuee[0];
                    cmdQuee.RemoveAt(0);
                }
                send("$KE," + currentCmd.cmd + "\r\n");
            }
        }

        public bool connect()
        {
            // Connect to a remote device.
            try
            {
                int retryCo = 0;

                while ((socket == null || !socket.Connected) && retryCo++ < 3)
                {
                    System.Diagnostics.Debug.WriteLine("Connecting...");
                    // Create a TCP/IP socket.
                    socket = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);

                    // Connect to the remote endpoint.
                    IAsyncResult ar = socket.BeginConnect(remoteEP,
                        new AsyncCallback(connectCallback), null);
                    ar.AsyncWaitHandle.WaitOne(timeout, true);

                    if (socket != null && !socket.Connected)
                    {
                        socket.Close();
                        System.Diagnostics.Debug.WriteLine("Timeout");
                    }
                    else
                    {
                        receive();
                        newCmd("PSW,SET," + password, null);
                    }
                }
                if (socket == null || !socket.Connected)
                    System.Diagnostics.Debug.WriteLine("Retries limit reached. Connect failed");
                return (socket != null && socket.Connected);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        public void disconnect()
        {
            if (socket != null && socket.Connected)
                socket.Close();
        }

        private void connectCallback(IAsyncResult ar)
        {
            try
            {
                if (socket != null && socket.Connected)
                {
                    socket.EndConnect(ar);

                    System.Diagnostics.Debug.WriteLine("Socket connected to " +
                        socket.RemoteEndPoint.ToString());

                    // Signal that the connection has been made.
                    connectDone.Set();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        private void receive()
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine("receiving");
                // Create the state object.
                StateObject state = new StateObject();

                // Begin receiving the data from the remote device.
                socket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(receiveCallback), state);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        private void receiveCallback(IAsyncResult ar)
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine("receive callback");
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;

                // Read data from the remote device.
                int bytesRead = socket.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    System.Diagnostics.Debug.WriteLine("received: " + state.sb.ToString());

                    string reply = state.sb.ToString();

                    if ( reply.Contains( '\n' ) )
                        processReply( reply );
                    else
                        socket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(receiveCallback), state);
                }
                receiveDone.Set();
                receive();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        private void processReply(string reply)
        {
            //System.Diagnostics.Debug.WriteLine(reply);
            Match match = rEVT.Match(reply);
            if (match.Success)
            {
                string line = match.Groups[1].Value;
                int lineState = match.Groups[2].Value == "0" ? 1 : 0;
            }
            else
            {
                replyTimer.Change(Timeout.Infinite, Timeout.Infinite);
                if (currentCmd.cb != null)
                {
                    currentCmd.cb.Invoke(reply);
                }
                lock (cmdQuee)
                {
                    currentCmd = null;
                }
                processQuee();

            }            
        }

        public void setLineMode(int line, int mode)
        {
            newCmd("IO,SET," + line.ToString() + "," + mode.ToString(), null);
        }

        public void switchLine(int line, int state)
        {
            newCmd("WR," + line.ToString() + "," + state.ToString(), null);
        }

        private void replyTimeout()
        {
            System.Diagnostics.Debug.WriteLine( "Reply timeout" );
        }

        private void send(String data)
        {
            System.Diagnostics.Debug.WriteLine("sending: " + data);
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            socket.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(sendCallback), null);
        }

        private void sendCallback(IAsyncResult ar)
        {
            try
            {

                // Complete sending the data to the remote device.
                int bytesSent = socket.EndSend(ar);
                System.Diagnostics.Debug.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                sendDone.Set();
                replyTimer = new Timer(obj => { replyTimeout(); }, null, timeout, Timeout.Infinite);
                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

    }
}
