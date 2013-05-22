using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hangman
{
    public partial class PlayerName : Form
    {

        public string playerName { get; set; }
        public PlayerName()
        {
            InitializeComponent();
            lblScore.Text = Form1.currentScore;
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            playerName = tbPlayer.Text;
            DialogResult = DialogResult.Yes;
            this.Close();
        }

       private void label3_Click(object sender, EventArgs e)
        {

        } 
    }
}
