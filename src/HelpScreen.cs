using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame
{
    public partial class HelpScreen : Form
    {
        public HelpScreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "This game playing with clicking.";
        }

        private void HelpScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Credits credits = new Credits();
            if (credits.ShowDialog() == System.Windows.Forms.DialogResult.No)
                this.Close();
        }
    }
}
