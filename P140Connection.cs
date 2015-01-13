using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jerome;

namespace NetCommP140
{
    public class P140Connection
    {
        public string name;
        public string host;
        public int port = 2424;
        public string password = "Jerome";
        private JeromeController controller;

        public bool connected
        {
            get
            {
                return controller != null && controller.connected;
            }
        }

        public bool connect()
        {
            controller = JeromeController.create(host, port, password);
            return controller.connect();
        }

        public void disconnect()
        {
            if (controller != null && controller.connected)
                controller.disconnect();
        }

    }
}
