using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class KitchenForm : Form
    {
        public KitchenForm()
        {
            InitializeComponent();
        }

        private void KitchenForm_Load(object sender, EventArgs e)
        {
            var thread = new Thread(() =>
            {
                int listenPort = 11000;
                TcpListener server = new TcpListener(IPAddress.Any, listenPort);
                server.Start();
                while (true)
                {
                    var client = server.AcceptTcpClient();
                    byte[] data = new byte[2000];
                    while (true)
                    {
                        int dataSize = client.GetStream().Read(data, 0, data.Length);
                        if (dataSize == 0)
                            break;
                        Invoke(() => {
                            textBox1.Text += Encoding.UTF8.GetString(data, 0,

                        dataSize) + "\r\n";
                        });

                        //SaveTextFile();
                    }
                    client.Close();
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void KitchenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
