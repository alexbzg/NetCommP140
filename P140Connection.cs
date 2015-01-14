using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jerome;
using System.Windows.Forms;
using System.Threading;

namespace NetCommP140
{
    public class P140Connection
    {
        static public string[] buttonLabels = { "160CW", "160SSB", "80CW", "80SSB", "40CW", "40SSB", "20CW", "20SSB", "15", "10" };
        private static int[] buttonLines = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private static int relay27Line = 11;
        private static int relay12Line = 22;

        public string name;
        public string host;
        public int port = 2424;
        public string password = "Jerome";
        private JeromeController controller;
        private bool _active;
        private bool[] _buttons = { false, false, false, false, false, false, false, false, false, false };

        public bool button(int no)
        {
            return _buttons[no];
        }

        public bool active
        {
            get
            {
                return _active;
            }
        }

        public bool connected
        {
            get
            {
                return controller != null && controller.connected;
            }
        }

        public void buttonPressed(int no)
        {
            if (controller != null && controller.connected)
            {
                controller.switchLine(relay12Line, 1);
                Thread.Sleep(500);
                controller.switchLine(relay27Line, 1);
                Thread.Sleep(500);
                controller.switchLine(buttonLines[no], 1);
                Thread.Sleep(30000);
                controller.switchLine(buttonLines[no], 0);
                controller.switchLine(relay12Line, 0);
                controller.switchLine(relay27Line, 0);
            }
        }

        public bool connect()
        {
            _active = true;
            controller = JeromeController.create(host, port, password);
            if (controller.connect())
            {
                foreach (int line in buttonLines)
                {
                    controller.setLineMode(line, 0);
                    controller.switchLine(line, 0);
                }
                controller.setLineMode(relay12Line, 0);
                controller.switchLine(relay12Line, 0);
                controller.setLineMode(relay27Line, 0);
                controller.switchLine(relay12Line, 0);
                return true;
            }
            else
                return false;
        }

        public void disconnect()
        {
            _active = false;
            if (controller != null && controller.connected)
                controller.disconnect();
        }

        public bool edit()
        {
            FConnectionParams fcp = new FConnectionParams( this );
            if (fcp.ShowDialog() == DialogResult.OK)
            {
                name = fcp.data.name;
                host = fcp.data.host;
                port = fcp.data.port;
                password = fcp.data.password;
                return true;
            }
            else
                return false;
        }

    }
}
