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

namespace NetCommP140
{
    public partial class FMain : Form
    {
        private List<P140Connection> connections;
        private List<ToolStripMenuItem> connectionsMIs = new List<ToolStripMenuItem>();

        public FMain()
        {
            InitializeComponent();
            if (!readConfig())
                connections = new List<P140Connection>();
            updateConnectionsMIs();
        }

        private void updateConnectionsMIs()
        {
            foreach (ToolStripMenuItem mi in connectionsMIs)
                ddbSettings.DropDownItems.Remove(mi);
            connectionsMIs.Clear();
            foreach (P140Connection cc in connections )
            {
                P140Connection c = cc;
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = c.name;
                mi.Click += delegate(object sender, EventArgs e)
                {
                    if (c.connected)
                        c.disconnect();
                    else
                        c.connect();
                };
                connectionsMIs.Add(mi);
                ddbSettings.DropDownItems.Insert(connections.IndexOf(c), mi);
            }
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            Width = 50;
        }

        public void writeConfig()
        {
            using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\config.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<P140Connection>));
                ser.Serialize(sw, connections);
            }

        }

        private bool readConfig()
        {
            bool result = false;
            if (File.Exists(Application.StartupPath + "\\config.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<P140Connection>));
                using (FileStream fs = File.OpenRead(Application.StartupPath + "\\config.xml"))
                {
                    try
                    {
                        connections = (List<P140Connection>)ser.Deserialize(fs);
                        result = true;
                    }
                    catch (Exception ex)
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
    }
}
