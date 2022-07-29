using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame {
    public partial class Settings : Form {
        public Settings() {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e) {
            this.TopMost = true;

            var properties = BoardGame.Properties.Settings.Default;

            if (properties.DifLevel == "Easy") {
                this.easyRadioBtn.Checked = true;
            } else if (properties.DifLevel == "Medium") {
                this.medRadioBtn.Checked = true;
            } else if (properties.DifLevel == "Hard") {
                this.hardRadioBtn.Checked = true;
            } else if (properties.DifLevel == "Custom") {
                this.customRadioBtn.Checked = true;
            }

            if (properties.ShapeSquare) {
                this.squareCheckBox.Checked = true;
            }

            if (properties.ShapeCircle) {
                this.circleCheckBox.Checked = true;
            }

            if (properties.ShapeTriangle) {
                this.triangleCheckBox.Checked = true;
            }

            if (properties.ColorRed) {
                this.redCheckbox.Checked = true;
            }

            if (properties.ColorGreen) {
                this.greenCheckbox.Checked = true;
            }

            if (properties.ColorBlue) {
                this.blueCheckbox.Checked = true;
            }

            this.borderTextboxX.Text = properties.BorderX;
            this.borderTextboxY.Text = properties.BorderY;


        }

        private void easyRadioBtn_CheckedChanged(object sender, EventArgs e) {
            this.customPanel.Visible = false;
        }

        private void medRadioBtn_CheckedChanged(object sender, EventArgs e) {
            this.customPanel.Visible = false;
        }

        private void hardRadioBtn_CheckedChanged(object sender, EventArgs e) {
            this.customPanel.Visible = false;
        }

        private void customRadioBtn_CheckedChanged(object sender, EventArgs e) {
            this.customPanel.Visible = true;
        }

        private void settingsSaveBtn_Click(object sender, EventArgs e) {
            var difficulty = this.difficultyPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            BoardGame.Properties.Settings.Default.DifLevel = difficulty.Text;

            if (this.redCheckbox.Checked) {
                BoardGame.Properties.Settings.Default.ColorRed = true;
            } else {
                BoardGame.Properties.Settings.Default.ColorRed = false;
            }

            if (this.greenCheckbox.Checked) {
                BoardGame.Properties.Settings.Default.ColorGreen = true;
            } else {
                BoardGame.Properties.Settings.Default.ColorGreen = false;
            }

            if (this.blueCheckbox.Checked) {
                BoardGame.Properties.Settings.Default.ColorBlue = true;
            } else {
                BoardGame.Properties.Settings.Default.ColorBlue = false;
            }

            if (this.squareCheckBox.Checked) {
                BoardGame.Properties.Settings.Default.ShapeSquare = true;
            } else {
                BoardGame.Properties.Settings.Default.ShapeSquare = false;
            }

            if (this.circleCheckBox.Checked) {
                BoardGame.Properties.Settings.Default.ShapeCircle = true;
            } else {
                BoardGame.Properties.Settings.Default.ShapeCircle = false;
            }

            if (this.triangleCheckBox.Checked) {
                BoardGame.Properties.Settings.Default.ShapeTriangle = true;
            } else {
                BoardGame.Properties.Settings.Default.ShapeTriangle = false;
            }
            if ((Int32.Parse(this.borderTextboxX.Text) > 14 || Int32.Parse(this.borderTextboxX.Text) < 10)|| (Int32.Parse(this.borderTextboxY.Text) > 14 || Int32.Parse(this.borderTextboxY.Text) < 10))
            {
                MessageBox.Show("Custom level allows you set X-Y value between 9-15");
                return;
            }
            BoardGame.Properties.Settings.Default.BorderX = this.borderTextboxX.Text;
                BoardGame.Properties.Settings.Default.BorderY = this.borderTextboxY.Text;
                BoardGame.Properties.Settings.Default.Save();

            MessageBox.Show("Settings successfully saved.");
        }
        private void backButton_Click(object sender, EventArgs e) {
            this.Visible = false;
        }
    }
}

