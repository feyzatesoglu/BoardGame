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
    public partial class MainGame : Form
    {
        public MainGame()
        {
            InitializeComponent();
        }

        private void mainSettingsBtn_Click(object sender, EventArgs e) {
            Settings settings = new Settings();
            if (settings.ShowDialog() == System.Windows.Forms.DialogResult.No)
                this.Close();
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
        }

        private void btnProfile_Click(object sender, EventArgs e) {
            Profile profile = new Profile();
            if (profile.ShowDialog() == System.Windows.Forms.DialogResult.No)
                this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
            LogIn logIn = new LogIn();
            if (logIn.ShowDialog() == System.Windows.Forms.DialogResult.No)
                this.Close();
        }

        private void btnCredits_Click(object sender, EventArgs e) {
            Credits credits = new Credits();
            if (credits.ShowDialog() == System.Windows.Forms.DialogResult.No)
                this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e) {
            Game game = new Game();
            if (game.ShowDialog() == System.Windows.Forms.DialogResult.No)
                this.Close();
    }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpScreen helpScreen = new HelpScreen();
            if (helpScreen.ShowDialog() == System.Windows.Forms.DialogResult.No)
                this.Close();
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            if (server.ShowDialog() == System.Windows.Forms.DialogResult.No)
                this.Close();
        }
    }
}
