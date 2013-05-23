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
        private bool Sound { get; set; }
        private SoundPlayer player;
        public static string currentScore { get; set; }
        public Form1()
        {
            InitializeComponent();
            score = new Scores();
            dataWords = new Data();
            player = new SoundPlayer(@"../../Resources/Blaues Licht - Afterworld.wav");
            player.PlayLooping();
            Sound = true;
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
            btn.FlatStyle = FlatStyle.Popup;
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
            
            int index = r.Next(dataWords.getWords(level).Count);
            hangmanWord = new HangmanWord(dataWords.getWords(level)[index]);
            updateWordMask();  
            timeElapsed = 0;
            timer1.Start();
            pgbLife.Maximum = TIME;
            pgbLife.Value = TIME;
            picuterBox.Load("../../Resources/pictures/Gallows0.jpg");
        }

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
                picuterBox.Load(string.Format("../../Resources/pictures/Gallows{0}.jpg", hangmanWord.WrongCount));
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
               // gameResult();
                startNewGame("Better luck next time!");
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
            if (MessageBox.Show(caption, "New game?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
            {
                btn.Enabled = false;
                btn.FlatStyle = FlatStyle.Standard;
            }
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
                currentScore = totalScore.ToString();
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
                startNewGame("Your score is too lower!!");
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

        private void changeVoulmen(object sender, EventArgs e)
        {
            Sound = !Sound;
            if (Sound)
            {
                player.PlayLooping();
                pbSound1.Load("../../Resources/pictures/soundOn.png");
                pbSound2.Load("../../Resources/pictures/soundOn.png");
                pbSound3.Load("../../Resources/pictures/soundOn.png");
                pbSound4.Load("../../Resources/pictures/soundOn.png");
            }
            else {
                player.Stop();
                pbSound1.Load("../../Resources/pictures/soundOff.png");
                pbSound2.Load("../../Resources/pictures/soundOff.png");
                pbSound3.Load("../../Resources/pictures/soundOff.png");
                pbSound4.Load("../../Resources/pictures/soundOff.png");
            }
        }


    }
}
