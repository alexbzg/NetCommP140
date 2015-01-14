using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetCommP140
{
    public partial class FConnectionsList : Form
    {
        List<P140Connection> connections;
        public FConnectionsList(List<P140Connection> cs)
        {
            InitializeComponent();
            connections = cs;
            fillList();
        }

        private void fillList()
        {
            lbConnections.Items.Clear();
            foreach (P140Connection cs in connections)
                lbConnections.Items.Add(cs.name);
            if (connections.Count > 0)
            {
                lbConnections.SelectedIndex = 0;
                bEdit.Enabled = true;
                bDelete.Enabled = true;
            }

        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (connections[lbConnections.SelectedIndex].edit())
            {
                ((FMain)this.Owner).writeConfig();
                int sel = lbConnections.SelectedIndex;
                fillList();
                lbConnections.SelectedIndex = sel;
            }

        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить соединение " + lbConnections.Items[lbConnections.SelectedIndex] + "?",
                "Удаление соединения", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                connections.RemoveAt(lbConnections.SelectedIndex);
                lbConnections.Items.RemoveAt(lbConnections.SelectedIndex);
                ((FMain)this.Owner).writeConfig();
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            P140Connection nc = new P140Connection();
            if (nc.edit())
            {
                connections.Add(nc);
                ((FMain)this.Owner).writeConfig();
                fillList();
                lbConnections.SelectedIndex = connections.Count - 1;
            }
        }


    }
}
