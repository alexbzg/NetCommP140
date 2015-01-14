using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jerome;

namespace NetCommP140
{
    public partial class FConnectionParams : Form
    {
        private ConnectionParamsData _data = new ConnectionParamsData();
        public ConnectionParamsData data
        {
            get
            {
                return _data;
            }
        }

        public FConnectionParams( P140Connection c )
        {
            InitializeComponent();

            tbName.Text = c.name;
            tbHost.Text = c.host;
            tbPort.Text = c.port.ToString();
            tbPassword.Text = c.password;

            _data.name = c.name;
            _data.host = c.host;
            _data.port = c.port;
            _data.password = c.password;

        }


        private void tbHost_Validated(object sender, EventArgs e)
        {
            if (tbHost.Text.Trim().Length > 0)
            {
                _data.host = tbHost.Text.Trim();
            }
        }

        private void tbPassword_Validated(object sender, EventArgs e)
        {
            if (tbPassword.Text.Trim().Length > 0)
            {
                _data.password = tbPassword.Text.Trim();
            }
        }

        private void tbPort_Validated(object sender, EventArgs e)
        {
            if (tbPort.Text.Trim().Length > 0)
            {
                _data.port = Convert.ToInt16( tbPort.Text.Trim() );
            }            
        }


        private void tbName_Validated(object sender, EventArgs e)
        {
            if (tbName.Text.Trim().Length > 0)
            {
                _data.name = tbName.Text.Trim();
            }            

        }

    }

    public class ConnectionParamsData
    {
        private string _host = "192.168.0.101";
        private string _name = "";
        private int _port = 2424;
        private string _password = "Jerome";

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
            }
        }

        public int port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

    }



}
