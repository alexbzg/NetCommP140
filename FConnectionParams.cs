using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EncRotator.Properties;

namespace EncRotator
{
    public partial class fConnectionParams : Form
    {
        private ConnectionParamsData _data = new ConnectionParamsData();
        private Bitmap bmIcon;
        public ConnectionParamsData data
        {
            get
            {
                return _data;
            }
        }

        public fConnectionParams( ConnectionSettings cSettings )
        {
            InitializeComponent();

            tbName.Text = cSettings.name;
            tbHost.Text = cSettings.host;
            tbPort.Text = cSettings.port;
            tbPassword.Text = cSettings.password;
            tbUSARTPort.Text = cSettings.usartPort;
            nudSlowInt.Value = cSettings.slowInt;
            cbDeviceType.SelectedIndex = cSettings.deviceType;
            chbSoft.Checked = cSettings.soft;

            _data.name = cSettings.name;
            _data.host = cSettings.host;
            _data.port = cSettings.port;
            _data.password = cSettings.password;
            _data.usartPort = cSettings.usartPort;
            _data.slowInt = cSettings.slowInt;
            _data.deviceType = cSettings.deviceType;
            _data.soft = cSettings.soft;
            _data.icon = cSettings.icon;

            displayIcon();
        }

        private void displayIcon()
        {
            bmIcon = Bitmap.FromHicon( ((Icon) Resources.ResourceManager.GetObject( CommonInf.icons[ _data.icon ] ) ).Handle );
            pIcon.BackgroundImage = bmIcon;
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
                _data.port = tbPort.Text.Trim();
            }            
        }


        private void tbUSARTPort_Validated(object sender, EventArgs e)
        {
            if (tbUSARTPort.Text.Trim().Length > 0)
            {
                _data.usartPort = tbUSARTPort.Text.Trim();
            }            

        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            if (tbName.Text.Trim().Length > 0)
            {
                _data.name = tbName.Text.Trim();
            }            

        }

        private void nudSlowInt_Validated(object sender, EventArgs e)
        {
            _data.slowInt = (int)nudSlowInt.Value;
        }

        private void nudSlowInt_Validating(object sender, CancelEventArgs e)
        {
            if (nudSlowInt.Value < 0)
                e.Cancel = true;
        }

        private void cbDeviceType_Validated(object sender, EventArgs e)
        {
            _data.deviceType = cbDeviceType.SelectedIndex;
        }

        private void chbSoft_Validated(object sender, EventArgs e)
        {
            _data.soft = chbSoft.Checked;
        }

        private void cbDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chbSoft.Visible = cbDeviceType.SelectedIndex == 0;
            if (!chbSoft.Visible)
                chbSoft.Checked = false;
        }

        private void bIconPrev_Click(object sender, EventArgs e)
        {
            if (_data.icon == 0)
                _data.icon = CommonInf.icons.Count() - 1;
            else
                _data.icon--;
            displayIcon();
        }

        private void bIconNext_Click(object sender, EventArgs e)
        {
            if (_data.icon == CommonInf.icons.Count() - 1)
                _data.icon = 0;
            else
                _data.icon++;
            displayIcon();
        }


    }

    public class ConnectionParamsData
    {
        private string _host = "192.168.0.101";
        private string _name = "";
        private string _port = "2424";
        private string _password = "Jerome";
        private string _usartPort = "2525";
        private int _slowInt = 10;
        private int _deviceType = 0;
        private bool _soft;
        private int _icon = 0;

        public int icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }



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

        public bool soft
        {
            get
            {
                return _soft;
            }
            set
            {
                _soft = value;
            }
        }


        public int slowInt
        {
            get
            {
                return _slowInt;
            }
            set
            {
                _slowInt = value;
            }
        }

        public int deviceType
        {
            get
            {
                return _deviceType;
            }
            set
            {
                _deviceType = value;
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

        public string port
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

        public string usartPort
        {
            get
            {
                return _usartPort;
            }
            set
            {
                _usartPort = value;
            }
        }



    }



}
