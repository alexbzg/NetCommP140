using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jerome;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using ExpertSync;
using System.Net;

namespace NetCommP140
{
    public partial class FMain : Form
    {
        private List<P140Connection> connections;
        private List<ToolStripMenuItem> connectionsMIs = new List<ToolStripMenuItem>();
        private int activeButton = -1;
        private List<ToolStripButton> buttons = new List<ToolStripButton>();
        private string[] buttonLabels = { "160CW", "160SSB", "80CW", "80SSB", "40CW", "40SSB", "20CW", "20SSB", "15", "10" };
        private Dictionary<int, int> esBindings = new Dictionary<int, int>();
        private ExpertSyncConnector esConnector;
        private IPEndPoint esEndPoint;

        public FMain()
        {
            InitializeComponent();
            if (readConfig())
                Parallel.ForEach(connections, c => c.disconnected += connectionBroken);
            else
                connections = new List<P140Connection>();
            updateConnectionsMIs();
        }

        private void connectionBroken(object obj, Jerome.DisconnectEventArgs e)
        {
            if (!e.requested)
                MessageBox.Show(((P140Connection)obj).name + ": связь потеряна", "NetCommP140");
        }


        private void updateConnectionsMIs()
        {
            foreach (ToolStripMenuItem mi in connectionsMIs)
                ddbSettings.DropDownItems.Remove(mi);
            connectionsMIs.Clear();
            foreach (P140Connection cc in connections )
            {
                P140Connection c = cc;
                c.disconnected -= connectionBroken;
                c.disconnected += connectionBroken;
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = c.name;
                mi.Click += delegate(object sender, EventArgs e)
                {
                    if (c.connected)
                        c.disconnect();
                    else 
                        if (!c.connect())
                            MessageBox.Show( c.name + ": подключение не удалось!" );
                };
                connectionsMIs.Add(mi);
                ddbSettings.DropDownItems.Insert(connections.IndexOf(c), mi);
            }
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            Width = 50;
            for (int co = 0; co < buttonLabels.Count(); co++)
            {
                ToolStripButton b = new ToolStripButton();
                int no = co;
                b.Text = buttonLabels[co];
                b.BackColor = SystemColors.Control;
                b.CheckedChanged += new EventHandler(delegate(object obj, EventArgs ea)
                {
                    Cursor tmpCursor = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;
                    if (activeButton > -1)
                        buttons[activeButton].ForeColor = toolStrip.ForeColor;
                    b.ForeColor = Color.Red;
                    activeButton = buttons.IndexOf(b);
                    toolStrip.Refresh();
                    Parallel.ForEach(connections, c => c.buttonPressed(no));
                    Cursor.Current = tmpCursor;
                });
                b.MouseDown += new MouseEventHandler(delegate(object obj, MouseEventArgs ea)
                {
                    if (ea.Button == MouseButtons.Right)
                    {
                        string bindStr = string.Join("; ", esBindings.Where(x => x.Value == no).Select(x => x.Key).ToArray());
                        FButtonProps ib = new FButtonProps(buttonLabels[no], bindStr);
                        ib.StartPosition = FormStartPosition.CenterParent;
                        ib.ShowDialog(this);
                        if (ib.DialogResult == DialogResult.OK)
                        {
                            buttonLabels[no] = ib.name;
                            b.Text = ib.name;
                            foreach (KeyValuePair<int, int> x in esBindings.Where(x => x.Value == no).ToList())
                                esBindings.Remove(x.Key);
                            foreach (int mhz in ib.esMHzValues)
                                esBindings[mhz] = no;
                            writeConfig();
                        }
                    }
                });
                buttons.Add(b);
                toolStrip.Items.Add(b);
            }

        }

        public void writeConfig()
        {
            using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\config.xml"))
            {
                AppState s = new AppState();
                s.connections = connections.ToArray();
                s.buttonLabels = buttonLabels;
                if (esEndPoint != null)
                {
                    s.esHost = esEndPoint.Address.ToString();
                    s.esPort = esEndPoint.Port;
                }

                s.esMhzValues = new int[esBindings.Count];
                s.esButtons = new int[esBindings.Count];
                int co = 0;
                foreach (KeyValuePair<int, int> x in esBindings)
                {
                    s.esMhzValues[co] = x.Key;
                    s.esButtons[co] = x.Value;
                    co++;
                }


                XmlSerializer ser = new XmlSerializer(typeof(AppState));
                ser.Serialize(sw, s);
            }

        }

        private bool readConfig()
        {
            bool result = false;
            if (File.Exists(Application.StartupPath + "\\config.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(AppState));
                using (FileStream fs = File.OpenRead(Application.StartupPath + "\\config.xml"))
                {
                    try
                    {
                        AppState s = (AppState)ser.Deserialize(fs);
                        if (s.connections != null)
                            connections = s.connections.ToList();
                        else
                            connections = new List<P140Connection>();
                        if (s.buttonLabels != null)
                            buttonLabels = s.buttonLabels;
                        if (s.esMhzValues != null)
                            for (int co = 0; co < s.esButtons.Count(); co++)
                                esBindings[s.esMhzValues[co]] = s.esButtons[co];
                        IPAddress hostIP;
                        if ( IPAddress.TryParse( s.esHost, out hostIP) )
                            esEndPoint = new IPEndPoint( hostIP, s.esPort );
                        result = true;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return result;
        }

        private void miModuleSettings_Click(object sender, EventArgs e)
        {
            (new FModuleSettings()).ShowDialog();
        }

        private void miConnectionsList_Click(object sender, EventArgs e)
        {
            (new FConnectionsList(connections)).ShowDialog(this);
            updateConnectionsMIs();
        }

        private void ddbSettings_DropDownOpening(object sender, EventArgs e)
        {
            tssConnectionsSeparator.Visible = connections.Count > 0;
            foreach (ToolStripMenuItem mi in connectionsMIs)
            {
                P140Connection c = connections[connectionsMIs.IndexOf(mi)];
                mi.ForeColor = c.active && !c.connected ? Color.Red : mi.Owner.ForeColor;
                mi.Checked = c.connected;
            }
        }

        private void miExpertSync_Click(object sender, EventArgs e)
        {
            if (miExpertSync.Checked)
            {
                FESConnection fes;
                if ( esEndPoint != null ) 
                    fes = new FESConnection( esEndPoint.Address.ToString(), esEndPoint.Port );
                else
                    fes = new FESConnection();
                fes.ShowDialog();
                if (fes.DialogResult == DialogResult.OK)
                {
                    esConnector = ExpertSyncConnector.create(fes.host, fes.port);
                    esEndPoint = new IPEndPoint(IPAddress.Parse(fes.host), fes.port);
                    esConnector.disconnected += esDisconnected;
                    esConnector.onMessage += esMessage;
                    writeConfig();
                    miExpertSync.Checked = esConnector.connect();
                }
            }
            else
            {
                esConnector.disconnect();
                miExpertSync.Checked = false;
            }
        }

        private void esDisconnected(object sender, ExpertSync.DisconnectEventArgs e)
        {
            if (!e.requested)
                MessageBox.Show("Соединение с ExpertSync потеряно!");
            miExpertSync.Checked = false;
        }

        private void esMessage(object sender, MessageEventArgs e)
        {
            int mhz = ((int)e.vfoa) / 1000000;
            if (esBindings.ContainsKey(mhz))
                this.Invoke((MethodInvoker)delegate
                {
                    buttons[esBindings[mhz]].Checked = true;
                });
        }
    }

    public class AppState
    {
        public P140Connection[] connections;
        public string[] buttonLabels;
        public int[] esMhzValues;
        public int[] esButtons;
        public string esHost;
        public int esPort;
    }
}
