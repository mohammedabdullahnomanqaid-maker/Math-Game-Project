using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathGame
{
    public partial class FrmResualt : Form
    {
        public FrmResualt()
        {
            InitializeComponent();
        }
        WMPLib.WindowsMediaPlayer GameOverSound =new WMPLib.WindowsMediaPlayer();

        void IsWinner()
        {
            if (clsfInalCard.isChild)
            {
                pictureBox1.Image = Properties.Resources.ChildWinner;
                GameOverSound.URL = "End_Winner_Sound.mp3";
            }
            else
            {
                GameOverSound.URL = "End_Winner_Sound.mp3";
            }

            if (clsfInalCard.CounterFaild > clsfInalCard.CounterWinner)
            {
                picFaild.Visible = true;
                GameOverSound.URL = "End_Faild_Game.m4a";
            }
        }

        private void FrmResualt_Load(object sender, EventArgs e)
        {
            IsWinner();
            lbScore.Text = Convert.ToString(clsfInalCard.FinalScore);
            lbFaild.Text = Convert.ToString(clsfInalCard.CounterFaild);
            lbFinalTime.Text =TimeSpan.FromSeconds(clsfInalCard.CounterTime).ToString();
            lbAnswer.Text = Convert.ToString(clsfInalCard.CounterWinner);
        }
    }
}
