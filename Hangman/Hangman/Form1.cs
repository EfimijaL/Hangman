using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Hangman
{
    public partial class Form1 : Form
    {
       
        private string level = "";
        private HangmanWord hangmanWord;
        private Data dataWords;
        private static readonly int TIME = 120;
        private int timeElapsed;
        private Scores score;

        public Form1()
        {
            InitializeComponent();
            score = new Scores();
          /*  SoundPlayer player = new SoundPlayer(@"C:\WINDOWS\Media\ding.wav");
            player.PlayLooping();*/
        }

        private void Start_Game(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            level = btn.Text;
            tabControl.SelectedTab= tabGame;
            newGame();
        }

        private void Help(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabHelp;
        }

        private void Scores(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabScore;
            //tbScores.Text = score.ListofPlayers();
            rtb.Text = score.ListofPlayers();
        }

        private void Menu_buttons(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabMenu;
        }

        private void Enabled_Button(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            enterLetter( btn.Text[0]);        
        }

        private void ResetLetters() {
            foreach (Button btn in flowPanelButtons.Controls)
                btn.Enabled = true;
        }




        private void newGame()
        {
            ResetLetters();
            Random r = new Random();
            dataWords = new Data(level);
            int index = r.Next(dataWords.Words.Count);
            hangmanWord = new HangmanWord(dataWords.Words[index]);
            label1.Text = Application.StartupPath;
            updateWordMask();    
            timeElapsed = 0;
            timer1.Start();
            pgbLife.Maximum = TIME;
            pgbLife.Value = TIME;          
            picuterBox.Load("../../pictures/Gallows0.jpg");
        }
        /// <summary>
        /// Метод за обновување на содржината на скриениот збор.
        /// </summary>
        private void updateWordMask()
        {
            lblword.Text = hangmanWord.WordMask();
        }

       
        private void enterLetter(char c)
        {           
                c = Char.ToUpper(c);
                if (hangmanWord.GuessLetter(c))
                {
                    updateWordMask();                
                }
                picuterBox.Load(string.Format("../../pictures/Gallows{0}.jpg", hangmanWord.WrongCount));
                checkGameState();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            pgbLife.Value = TIME - timeElapsed;
            if (timeElapsed == TIME)
            {
                hangmanWord.EndGame();
                updateWordMask();
                timer1.Stop();
                gameResult();
            }
        }
       

        private void checkGameState()
        {
            if (hangmanWord.IsGameOver)
            {
                hangmanWord.EndGame();
                updateWordMask();
                timer1.Stop();
                buttons_Disabled();
                gameResult();

            }
            else
            {
                if (hangmanWord.IsGuessed)
                {
                    timer1.Stop();
                    buttons_Disabled();
                    gameResult();
                }
            }
        }

        public void startNewGame(string caption)
        {
            if (MessageBox.Show("Нова игра?", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                newGame();
            }
        }
        

        private void button9_Click(object sender, EventArgs e) // Reset button
        {
            newGame();
        }

        private void buttons_Disabled() {
            foreach (Button btn in flowPanelButtons.Controls)
                btn.Enabled = false;
        }

        private void gameResult() {
            int lowest = score.LowestScore;
            int left = pgbLife.Value;
            int totalScore = 0;
            if (left > 0) {
                totalScore = 10 * left/(hangmanWord.WrongCount+1);
                switch (level) { 
                    case "Easy":
                        totalScore *= 1;
                        break;
                    case "Normal":
                        totalScore *= 2;
                        break;

                    case "Hard":
                        totalScore *= 3;
                        break;
                
                }
            }
            if (totalScore > lowest)
            {
                PlayerName pl = new PlayerName();
                if ((pl.ShowDialog()) == DialogResult.Yes)
                {
                    score.update(pl.playerName, totalScore);
                    rtb.Text = score.ListofPlayers();
                    tabControl.SelectedTab = tabScore;
                    btnPlay.Enabled = true;
                }

            }
            else {
                startNewGame("Your score is too low for top 10 scores");
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab=tabGame;
            btnPlay.Enabled = false;
            newGame();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
