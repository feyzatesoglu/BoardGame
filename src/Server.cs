using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace BoardGame
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            Game game = new Game(false, textBox1.Text);
            Visible = false;
            if (!game.IsDisposed)
            {
                game.ShowDialog();
            }
            Visible = true;
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            Game.host = true;
            Game game = new Game(true);
            Visible = false;
            if (!game.IsDisposed)
            {
                game.ShowDialog();
            }
            Visible = true;
        }
    }
}
