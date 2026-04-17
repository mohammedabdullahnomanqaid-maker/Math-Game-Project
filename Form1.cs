using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace MathGame
{
    public partial class Form1 : Form
    {
        byte Length;
        int Counter = 0;
        byte TypeOfLevel;
        char TypeOfTopic;
        byte LengthOfQuestion;
        byte NumberOfQuestion;
        byte FirstSlide;
        byte SecondSlide;
        double Soulation;
        byte Counter2 = 1;
        byte Counter3 = 0;
        int CountTurner;
        short CounterMusic = 1;
        string MusicPath;
        string DefaultMusic = "Deep_Music";
        bool IsDone = false;
        bool IsAnyButtonOfTypeOfLevelClicked = false;
        bool IsAnyButtonOfTypeOfTopicClicked = false;
        bool IsAnyButtonOfTimeClicked = false;
        bool IsAnyButtonOfNumberOfQuestionClicked = false;


        void MusicPlayer(bool isRight = false)
        {
            string[] arrMusic = { "Deep_Music", "Happy_Music", "Excited_Music" };
            if (CounterMusic >= 0 && CounterMusic <= 2)
            {
                if (CounterMusic >= 0 && isRight)
                {
                    if (CounterMusic == 0)
                        CounterMusic++;

                    tbTypeOfMusic.Text = arrMusic[CounterMusic++];
                    MusicIcon(tbTypeOfMusic.Text);

                    if (CounterMusic == 3)
                        CounterMusic--;
                }
                else if (CounterMusic <= 2)
                {
                    if (CounterMusic == 2)
                        CounterMusic--;

                    tbTypeOfMusic.Text = arrMusic[CounterMusic--];
                    MusicIcon(tbTypeOfMusic.Text);

                    if (CounterMusic == -1)
                        CounterMusic++;
                }
            }
        }

        Random rand = new Random();
        void CombindOperation()
        {
            if (btnCombined.Tag == "&")
            {


                int r = rand.Next(0, 5);
                switch (r)
                {
                    case 0:
                        TypeOfTopic = '+';
                        break;

                    case 1:
                        TypeOfTopic = '-';
                        break;

                    case 2:
                        TypeOfTopic = '/';
                        break;

                    case 3:
                        TypeOfTopic = '*';
                        break;

                    case 4:
                        TypeOfTopic = '%';
                        break;
                }
            }
        }

        WMPLib.WindowsMediaPlayer mSound = new WMPLib.WindowsMediaPlayer();

        bool IsReadyToLaunchGame()
        {
            if (IsAnyButtonOfNumberOfQuestionClicked && IsAnyButtonOfTimeClicked &&
                IsAnyButtonOfTypeOfTopicClicked && IsAnyButtonOfTypeOfLevelClicked)
            {
                return true;
            }
            return false;
        }

   
        bool IsClick()
        {
            if (btnOption1.Tag == "?" &&
                btnOption2.Tag == "?" &&
                btnOpetion3.Tag == "?" &&
                btnOption4.Tag == "?")
            {


                if (btnOption1.Text == Convert.ToString(Soulation))
                {
                    btnOption1.BackColor = Color.Blue;
                    // MarkRightAnswer(btnOption1);
                }
                if (btnOption2.Text == Convert.ToString(Soulation))
                {
                    btnOption1.BackColor = Color.Blue;

                    // MarkRightAnswer(btnOption2);
                }
                if (btnOpetion3.Text == Convert.ToString(Soulation))
                {
                    btnOption1.BackColor = Color.Blue;
                    // MarkRightAnswer(btnOpetion3);
                }
                if (btnOption4.Text == Convert.ToString(Soulation))
                {
                    btnOption4.BackColor = Color.Blue;
                    // MarkRightAnswer(btnOption4);
                }


                btnOpetion3.Enabled = false;
                btnOption1.Enabled = false;
                btnOption2.Enabled = false;
                btnOption4.Enabled = false;

                return true;
            }
            return false;
        }
        void Reset()
        {
            btnOpetion3.Enabled = true;
            btnOption1.Enabled = true;
            btnOption2.Enabled = true;
            btnOption4.Enabled = true;
            btnOption4.BackColor = Color.Gainsboro;
            btnOption2.BackColor = Color.Gainsboro;
            btnOption1.BackColor = Color.Gainsboro;
            btnOpetion3.BackColor = Color.Gainsboro;
            btnOption1.Tag = "?";
            btnOption2.Tag = "?";
            btnOpetion3.Tag = "?";
            btnOption4.Tag = "?";
            //  btnCombined.Tag = "";

        }

        void IncreaseScore()
        {
            progressBar1.Value += 1;
            lbScore.Text = Convert.ToString(Convert.ToInt32(lbScore.Text) + 10);
            mSound.URL = "Correct_Sound.m4a";
            mSound.controls.play();
            lbOfScore.Text = progressBar1.Value.ToString() + "/" + NumberOfQuestion.ToString();

        }

        void DecreaseScore()
        {
            if (Convert.ToInt32(lbScore.Text) > 0)
                lbScore.Text = Convert.ToString(Convert.ToInt32(lbScore.Text) - 5);
            mSound.URL = "Faild_Sound.m4a";
            mSound.controls.play();
        }

        void Check()
        {

        }

        void MarkRightAnswer(Button btnOption)
        {
            if (Convert.ToDouble(btnOption.Text) == Soulation)
            {
                    btnOption.BackColor = Color.Blue;
                    IncreaseScore();
            }

            else
            {
                btnOption.BackColor = Color.Red;
                DecreaseScore();

            }
            btnOpetion3.Enabled = false;
            btnOption1.Enabled = false;
            btnOption2.Enabled = false;
            btnOption4.Enabled = false;



        }
        void EasyLevel(byte From, byte To)
        {
            FirstSlide = Convert.ToByte(rand.Next(From, To));
            SecondSlide = Convert.ToByte(rand.Next(From, To));
        }

        int CheckOption(byte From, byte To)
        {
            int value = 0;

            do
            {
                value = Convert.ToInt32(rand.Next(From, To));

            } while (value == Convert.ToInt32(btnOption1.Text) ||
                value == Convert.ToInt32(btnOption2.Text) ||
                value == Convert.ToInt32(btnOpetion3.Text) ||
                value == Convert.ToInt32(btnOption4.Text));

            return value;
        }

        void Solation1(byte From, byte To)
        {
            btnOption1.Text = Convert.ToString(Soulation);
            btnOption2.Text = Convert.ToString(CheckOption(From, To));
            btnOpetion3.Text = Convert.ToString(CheckOption(From, To));
            btnOption4.Text = Convert.ToString(CheckOption(From, To));
        }

        void Solation2(byte From, byte To)
        {
            btnOption1.Text = Convert.ToString(CheckOption(From, To));
            btnOption2.Text = Convert.ToString(Soulation);
            btnOpetion3.Text = Convert.ToString(CheckOption(From, To));
            btnOption4.Text = Convert.ToString(CheckOption(From, To));
        }

        void Solation3(byte From, byte To)
        {
            btnOption1.Text = Convert.ToString(CheckOption(From, To));
            btnOption2.Text = Convert.ToString(CheckOption(From, To));
            btnOpetion3.Text = Convert.ToString(Soulation);
            btnOption4.Text = Convert.ToString(CheckOption(From, To));
        }

        void Solation4(byte From, byte To)
        {
            btnOption1.Text = Convert.ToString(CheckOption(From, To));
            btnOption2.Text = Convert.ToString(CheckOption(From, To));
            btnOpetion3.Text = Convert.ToString(CheckOption(From, To));
            btnOption4.Text = Convert.ToString(Soulation);
        }

        void MixOptions(byte From, byte To)
        {
            for (byte i = 0; i < 4; i++)
            {

                byte randNum = Convert.ToByte(rand.Next(0, 4));
                switch (randNum)
                {
                    case 0:
                        Solation1(From, To);
                        break;

                    case 1:
                        Solation2(From, To);
                        break;

                    case 2:
                        Solation3(From, To);
                        break;

                    case 3:
                        Solation4(From, To);
                        break;
                }
            }
        }
        void MediumLevel(byte From, byte To)
        {
            FirstSlide = Convert.ToByte(rand.Next(From, To));
            SecondSlide = Convert.ToByte(rand.Next(From, To));
        }

        void MixLevel(byte From, byte To)
        {
            FirstSlide = Convert.ToByte(rand.Next(From, To));
            SecondSlide = Convert.ToByte(rand.Next(From, To));
        }

        void HardLevel(byte From, byte To)
        {
            FirstSlide = Convert.ToByte(rand.Next(From, To));
            SecondSlide = Convert.ToByte(rand.Next(From, To));
        }

        byte FillOptionEasy()
        {
            byte num1 = Convert.ToByte(rand.Next(0, 9));
            return num1;

        }

        void CalculateResualt()
        {
            CombindOperation();
            string LineOfCalculate = Convert.ToString(FirstSlide) + TypeOfTopic + Convert.ToString(SecondSlide);
            DataTable calculator = new DataTable();
            object resualt = calculator.Compute(LineOfCalculate, "");
            Soulation = Convert.ToDouble(resualt);
            tbShowResualt.Text = Convert.ToString(FirstSlide) + TypeOfTopic + Convert.ToString(SecondSlide) + "= ?";

        }
        void MathGame()
        {
            CountTurner++;
            if (IsDoneQuestion())
                return;

            lbChallenge.Text = Convert.ToString(Convert.ToInt32(lbChallenge.Text) + 1);


            switch (TypeOfLevel)
            {
                case 1:
                    EasyLevel(0, 20);
                    CalculateResualt();
                    MixOptions(0, 20);
                    break;

                case 2:
                    MediumLevel(20, 50);
                    CalculateResualt();
                    MixOptions(20, 50);
                    break;

                case 3:
                    HardLevel(50, 100);
                    CalculateResualt();
                    MixOptions(50, 250);
                    break;

                case 4:
                    MixLevel(0, 250);
                    CalculateResualt();
                    MixOptions(50, 250);
                    break;
            }


        }

        void ShowFinalCard()
        {
            Form frm = new FrmResualt();
            //frm.Parent = this;
            clsfInalCard.CounterTime = Counter;
            clsfInalCard.CounterWinner = progressBar1.Value;
            clsfInalCard.CounterFaild = (Convert.ToInt32(NumberOfQuestion) - progressBar1.Value);
            clsfInalCard.FinalScore = Convert.ToInt32(lbScore.Text);
            timer1.Enabled = false;
          
            frm.ShowDialog();
        }
        void MusicIcon(string PathM)
        {
            MusicPath = PathM;
            if (rbOff.Checked)
            {
                picMusic.Image = Properties.Resources.MusicOff;
                wmp.controls.stop();

            }
            else
            {
                picMusic.Image = Properties.Resources.MusicOn;

                wmp.URL = PathM + ".mp3";
                wmp.settings.setMode("loop", true);

            }
        }

        bool IsDoneQuestion()
        {
            CountTurner = Convert.ToInt32(lbChallenge.Text);



            if (CountTurner == NumberOfQuestion && IsDone)
            {
                this.Visible = false;
                ShowFinalCard();
                timer1.Enabled = false;
                this.Visible = true;
                Properties.Settings.Default.IsFormal = Convert.ToByte(cbTheme.SelectedIndex);
                Properties.Settings.Default.Save();
                Application.Restart();
                return true;

            }
            //because on u click on next first answer and sencond pass so we want the final form to show after second next
            if (CountTurner == NumberOfQuestion)
            {
                IsDone = true;
            }

            return false;
        }

       async void StartPlay()
        {

            if (IsDoneQuestion())
                return;

            if (Counter3 / Counter2 == LengthOfQuestion)
            {


                if (IsClick())
                {
                    await WrongAnswer();
                   // return;
                }

                Reset();
                MathGame();
                Counter2++;
            }
        }
        void Visit(string URL)
        {





            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = URL,
                    UseShellExecute = true,

                }

                    );

            }

            catch (Exception ex)
            {
                MessageBox.Show("Sorry , Faild");
            }
        }
        public Form1()
        {
            InitializeComponent();

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            Reset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbTheme.SelectedIndex = Properties.Settings.Default.IsFormal;

            tabControl1.SelectedIndex = 1;
            rbOn.Checked = true;
            tbTypeOfMusic.Text = DefaultMusic;
            MusicPath = tbTypeOfMusic.Text;
            MusicIcon(DefaultMusic);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TypeOfLevel = Convert.ToByte(btnHard.Tag);
            IsAnyButtonOfTypeOfLevelClicked = true;
            ButtonClickTypes(btnHard);

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnLaunchGame.BackColor = Color.Blue;

        }

        private void btnLaunchGame_MouseLeave(object sender, EventArgs e)
        {
            btnLaunchGame.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelWhats.LinkVisited = true;
            Visit(linkLabelWhats.Text);
        }

        private void linkLabelTlegram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelTlegram.LinkVisited = true;
            Visit(linkLabelTlegram.Text);

        }


        private void linkLabelGethub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelGethub.LinkVisited = true;
            Visit(linkLabelGethub.Text);

        }

        private void linkLabelInstgram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelInstgram.LinkVisited = true;
            Visit(linkLabelInstgram.Text);
        }
        WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();

        private void rbOn_CheckedChanged(object sender, EventArgs e)
        {
            MusicIcon(MusicPath);
        }

        private void rbOff_CheckedChanged(object sender, EventArgs e)
        {
            MusicIcon(MusicPath);
        }

        private void btnLaunchGame_Click(object sender, EventArgs e)
        {
            if (!IsReadyToLaunchGame())
            {
                MessageBox.Show("Select Types", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbChallenge.Text = "0";
            tabControl1.SelectedIndex = 0;
            Counter3 = 0;
            Counter = 0;
            timer1.Enabled = true;
            MathGame();
            StartPlay();
            progressBar1.Value = 0;
            lbOfScore.Text = "0/0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Counter++;
            Counter3++;
            TimeSpan tim = new TimeSpan();
            lbTimer.Text = TimeSpan.FromSeconds(Counter).ToString();

            StartPlay();
        }

        void ButtonClickTypes(Button btnClicked)
        {
            btnEasy.BackColor = Color.FromArgb(64, 64, 64);
            btnHard.BackColor = Color.FromArgb(64, 64, 64);
            btnMedium.BackColor = Color.FromArgb(64, 64, 64);
            btnCombined.BackColor = Color.FromArgb(64, 64, 64);
            button3.BackColor = Color.FromArgb(64, 64, 64);
            btnClicked.BackColor = Color.FromArgb(128, 128, 255);

        }

        void ButtonClickTopics(Button btnClicked)
        {
            btnDivision.BackColor = Color.FromArgb(64, 64, 64);
            btnMultiplication.BackColor = Color.FromArgb(64, 64, 64);
            btnAddition.BackColor = Color.FromArgb(64, 64, 64);
            btnSubtraction.BackColor = Color.FromArgb(64, 64, 64);
            btnPercentage.BackColor = Color.FromArgb(64, 64, 64);
            btnCombined.BackColor = Color.FromArgb(64, 64, 64);
            btnClicked.BackColor = Color.FromArgb(128, 128, 255);

        }
        void ButtonClickTime(Button btnClicked)
        {
            btnTen.BackColor = Color.FromArgb(64, 64, 64);
            btnTwenty.BackColor = Color.FromArgb(64, 64, 64);
            btnFifty.BackColor = Color.FromArgb(64, 64, 64);
            btnNone.BackColor = Color.FromArgb(64, 64, 64);
            btnClicked.BackColor = Color.FromArgb(128, 128, 255);

        }

        void ButtonClickNumberOfQuestion(Button btnClicked)
        {
            btnTenQ.BackColor = Color.FromArgb(64, 64, 64);
            btnTwentyQ.BackColor = Color.FromArgb(64, 64, 64);
            btnFiftyQ.BackColor = Color.FromArgb(64, 64, 64);
            btnEndless.BackColor = Color.FromArgb(64, 64, 64);
            btnClicked.BackColor = Color.FromArgb(128, 128, 255);

        }
        private void btnEasy_Click(object sender, EventArgs e)
        {
            TypeOfLevel = Convert.ToByte(btnEasy.Tag);
            IsAnyButtonOfTypeOfLevelClicked = true;
            ButtonClickTypes(btnEasy);
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            TypeOfLevel = Convert.ToByte(btnMedium.Tag);
            IsAnyButtonOfTypeOfLevelClicked = true;
            ButtonClickTypes(btnMedium);

        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            TypeOfTopic = Convert.ToChar(btnAddition.Tag);
            IsAnyButtonOfTypeOfTopicClicked = true;
            ButtonClickTopics(btnAddition);

        }

        private void btnSubtraction_Click(object sender, EventArgs e)
        {
            TypeOfTopic = Convert.ToChar(btnSubtraction.Tag);
            IsAnyButtonOfTypeOfTopicClicked = true;
            ButtonClickTopics(btnSubtraction);


        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            TypeOfTopic = Convert.ToChar(btnMultiplication.Tag);
            IsAnyButtonOfTypeOfTopicClicked = true;
            ButtonClickTopics(btnMultiplication);

        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            TypeOfTopic = Convert.ToChar(btnDivision.Tag);
            IsAnyButtonOfTypeOfTopicClicked = true;
            ButtonClickTopics(btnDivision);

        }

        private void btnPercentage_Click(object sender, EventArgs e)
        {
            TypeOfTopic = Convert.ToChar(btnPercentage.Tag);
            IsAnyButtonOfTypeOfTopicClicked = true;
            ButtonClickTopics(btnPercentage);

        }

        private void btnCombined_Click(object sender, EventArgs e)
        {
            btnCombined.Tag = "&";
            IsAnyButtonOfTypeOfTopicClicked = true;
            ButtonClickTopics(btnCombined);

        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            LengthOfQuestion = Convert.ToByte(btnNone.Tag);
            IsAnyButtonOfTimeClicked = true;
            ButtonClickTime(btnNone);
        }

        private void btnTen_Click(object sender, EventArgs e)
        {
            LengthOfQuestion = Convert.ToByte(btnTen.Tag);
            IsAnyButtonOfTimeClicked = true;
            ButtonClickTime(btnTen);

        }

        private void btnTwenty_Click(object sender, EventArgs e)
        {
            LengthOfQuestion = Convert.ToByte(btnTwenty.Tag);
            IsAnyButtonOfTimeClicked = true;
            ButtonClickTime(btnTwenty);

        }

        private void btnFifty_Click(object sender, EventArgs e)
        {
            LengthOfQuestion = Convert.ToByte(btnFifty.Tag);
            IsAnyButtonOfTimeClicked = true;
            ButtonClickTime(btnFifty);

        }

        private void btnTenQ_Click(object sender, EventArgs e)
        {
            NumberOfQuestion = Convert.ToByte(btnTenQ.Tag);
            progressBar1.Maximum = Convert.ToByte(btnTenQ.Tag);
            IsAnyButtonOfNumberOfQuestionClicked = true;
            ButtonClickNumberOfQuestion(btnTenQ);
        }

        private void btnTwentyQ_Click(object sender, EventArgs e)
        {
            NumberOfQuestion = Convert.ToByte(btnTwentyQ.Tag);
            progressBar1.Maximum = Convert.ToByte(btnTwentyQ.Tag);
            IsAnyButtonOfNumberOfQuestionClicked = true;
            ButtonClickNumberOfQuestion(btnTwentyQ);

        }

        private void btnFiftyQ_Click(object sender, EventArgs e)
        {
            NumberOfQuestion = Convert.ToByte(btnFiftyQ.Tag);
            progressBar1.Maximum = Convert.ToByte(btnFiftyQ.Tag);
            IsAnyButtonOfNumberOfQuestionClicked = true;
            ButtonClickNumberOfQuestion(btnFiftyQ);

        }

        private void btnEndless_Click(object sender, EventArgs e)
        {
            NumberOfQuestion = Convert.ToByte(btnEndless.Tag);
            progressBar1.Maximum = Convert.ToByte(btnEndless.Tag);
            IsAnyButtonOfNumberOfQuestionClicked = true;
            ButtonClickNumberOfQuestion(btnEndless);


        }

        private void btnOption1_Click(object sender, EventArgs e)
        {
            MarkRightAnswer(btnOption1);
            btnOption1.Tag = "";
        }

        private void btnOption2_Click(object sender, EventArgs e)
        {
            MarkRightAnswer(btnOption2);
            btnOption2.Tag = "";

        }

        private void btnOpetion3_Click(object sender, EventArgs e)
        {
            MarkRightAnswer(btnOpetion3);
            btnOpetion3.Tag = "";

        }

        private  void btnOption4_Click(object sender, EventArgs e)
        {
            MarkRightAnswer(btnOption4);
            btnOption4.Tag = "";

        }

        async Task WrongAnswer()
        {
            if (IsClick())
            {
                DecreaseScore();
                await Task.Delay(3000);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
          await WrongAnswer();

            if (Convert.ToInt32(lbChallenge.Text) < NumberOfQuestion)
            {
                Reset();
                Counter3 = 0;
                MathGame();
            }

        }

        private void cbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTheme.SelectedIndex == 1)
            {
                panlWallPaper.BackColor = Color.White;
                panlTop.BackColor = Color.Yellow;
                panlTop.BackgroundImage = Properties.Resources.Child;
                tabPage1.BackColor = Color.Yellow;
                tabPage2.BackColor = Color.White;
                // tabPage1.BackgroundImage = Properties.Resources.FormIcon;
                panelSide.BackColor = Color.White;
                panelSide.BackgroundImage = Properties.Resources.WinnerIcon;
                panelGameConfigration.BackColor = Color.White;
                // panelGameConfigration.BackgroundImage = Properties.Resources.FormIcon;
                tabPage3.BackColor = Color.White;
                tabPage3.BackgroundImage = Properties.Resources.FormIcon;
                panel8.BackColor = Color.White;
                panlWallPaper.BackgroundImage = Properties.Resources.NewMathIcon;
                panelTopGameConfigration.BackgroundImage = Properties.Resources.ThinkerIcon;
                lbStaticScore.ForeColor = Color.Black;
                lbScore.ForeColor = Color.Black;
                lbChallenge.ForeColor = Color.Blue;
                lbStaticChallenge.ForeColor = Color.Blue;
                panelMusic.BackColor = Color.White;
                lbMusic.ForeColor = Color.Black;
                tbTypeOfMusic.BackColor = Color.White;
                clsfInalCard.isChild = true;


            }
            else
            {
                panlWallPaper.BackColor = Color.Gray;
                panlTop.BackColor = Color.FromArgb(64, 64, 64);
                panlTop.BackgroundImage = null;
                tabPage1.BackColor = Color.FromArgb(64, 64, 64);
                tabPage1.BackgroundImage = null;
                panelSide.BackColor = Color.Gray;
                panelSide.BackgroundImage = null;
                panelGameConfigration.BackColor = Color.Gray;
                panelGameConfigration.BackgroundImage = null;
                tabPage3.BackgroundImage = null;
                panel8.BackColor = Color.Gray;
                panlWallPaper.BackgroundImage = null;
                tabPage3.BackColor = Color.FromArgb(64, 64, 64);
                tabPage3.BackgroundImage = null;
                panelMusic.BackColor = Color.FromArgb(64, 64, 64);
                lbMusic.ForeColor = Color.White;
                tabPage2.BackColor = Color.FromArgb(64, 64, 64);
                panelTopGameConfigration.BackgroundImage = null;
                tbTypeOfMusic.BackColor = Color.FromArgb(64, 64, 64);
                clsfInalCard.isChild = true;
                clsfInalCard.isChild = false;

            }
            Properties.Settings.Default.IsFormal =Convert.ToByte(cbTheme.SelectedIndex);
            Properties.Settings.Default.Save();
        }

        void FontSize(byte size, bool isBold)
        {
            FontStyle style = isBold ? FontStyle.Bold : FontStyle.Regular;

            tbShowResualt.Font = new Font(tbShowResualt.Font.FontFamily, size, style);
            btnOption1.Font = new Font(btnOption1.Font.FontFamily, size, style);
            btnOption2.Font = new Font(btnOption2.Font.FontFamily, size, style);
            btnOpetion3.Font = new Font(btnOpetion3.Font.FontFamily, size, style);
            btnOption4.Font = new Font(btnOption4.Font.FontFamily, size, style);
        }

        private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFont.SelectedIndex == 0)
            {
                FontSize(8, true);
            }
            if (cbFont.SelectedIndex == 1)
            {
                FontSize(14, true);
            }
            if (cbFont.SelectedIndex == 2)
            {
                FontSize(20, true);
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MusicPlayer(true);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            MusicPlayer();


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            TypeOfLevel = Convert.ToByte(button3.Tag);
            IsAnyButtonOfTypeOfLevelClicked = true;
            ButtonClickTypes(button3);
        }
    }
}
