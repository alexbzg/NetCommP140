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
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            JeromeController jc = JeromeController.create("192.168.0.101", 2424);
            jc.connect();
        }
    }
}
