using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombie_Dice_Jeff_Jia
{
    public partial class PlayerVsPlayerForm : Form
    {
        //initialise 2 players
        Player player1 = new Player();
        Player player2 = new Player();

        //initialise cup
        Cup cup = new Cup();

        //random object for all random needs in this code
        Random rand = new Random();

        //current turn variables

        string[] diceOutcomes = new string[3];
        Color[] diceColors = new Color[3];

        int p1BrainsCount = 0;
        int p1ShotgunCount = 0;

        int p2BrainsCount = 0;
        int p2ShotgunCount = 0;


        //list of currently drawn dice  
        List<Die> drawnDiceList = new List<Die>();

        //List of currently set aside dice
        List<Die> setAsideDice = new List<Die>();

        public PlayerVsPlayerForm()
        {
            InitializeComponent();

            //add 13 dices accordingly
            cup.AddDices();


            //gets 3 dice from cup
            drawnDiceList = cup.DrawDice();



            //randomly decides who goes first
            int turnDecider = rand.Next(0, 2);
            Debug.WriteLine(turnDecider);
            if (turnDecider == 0)
            {
                SwitchPlayer1Turn();
                labelCurrentTurnDisplay.Text = "Current Turn: Player 1";
            }
            else
            {
                SwitchPlayer2Turn();
                labelCurrentTurnDisplay.Text = "Current Turn: Player 2";
            }




        }

        private void buttonReRoll_Click(object sender, EventArgs e)
        {
            
            diceOutcomes[0] = drawnDiceList[0].Roll();
            diceColors[0] = drawnDiceList[0].GetDiceColor();

            diceOutcomes[1] = drawnDiceList[1].Roll();
            diceColors[1] = drawnDiceList[1].GetDiceColor();

            diceOutcomes[2] = drawnDiceList[2].Roll();
            diceColors[2] = drawnDiceList[2].GetDiceColor();

            DiceOutcomeEvaluation(diceOutcomes[0], diceOutcomes[1], diceOutcomes[2]);


            Update();

        }

        private void buttonStopAndScore_Click(object sender, EventArgs e)
        {
            foreach (Die item in setAsideDice)
            {
                cup._diceList.Add(item);
                setAsideDice.Remove(item);
            }

            player1.BrainsCount += p1BrainsCount;
            ResetP1Counts();

        }

        private void buttonPlayer2ReRoll_Click(object sender, EventArgs e)
        {

        }

        private void buttonPlayer2StopAndScore_Click(object sender, EventArgs e)
        {

        }




        /// <summary>
        /// evaluates each dice by processing it
        /// </summary>
        /// <param name="dice1Outcome"></param>
        /// <param name="dice2Outcome"></param>
        /// <param name="dice3Outcome"></param>
        public void DiceOutcomeEvaluation(string dice1Outcome, string dice2Outcome, string dice3Outcome)
        {

            if (dice1Outcome == "Brain")
            {
                if (player1.IsPlayerTurn)
                {
                    p1BrainsCount++;

                }
                else
                {
                    p2BrainsCount++;
                }


            }
            else if (dice1Outcome == "Shotgun")
            {
                if (player1.IsPlayerTurn)
                {
                    p1ShotgunCount++;
                }
                else
                {
                    p2ShotgunCount++;
                }
            }

            setAsideDice.Add(drawnDiceList[0]);
            drawnDiceList[0] = null;


            if (dice2Outcome == "Brain")
            {
                if (player1.IsPlayerTurn)
                {
                    p1BrainsCount++;
                }
                else
                {
                    p2BrainsCount++;
                }


            }
            else if (dice2Outcome == "Shotgun")
            {
                if (player1.IsPlayerTurn)
                {
                    p1ShotgunCount++;
                }
                else
                {
                    p2ShotgunCount++;
                }
            }
            setAsideDice.Add(drawnDiceList[1]);
            drawnDiceList[1] = null;



            if (dice3Outcome == "Brain")
            {
                if (player1.IsPlayerTurn)
                {
                    p1BrainsCount++;
                }
                else
                {
                    p2BrainsCount++;
                }
            }
            else if (dice3Outcome == "Shotgun")
            {
                if (player1.IsPlayerTurn)
                {
                    p1ShotgunCount++;
                }
                else
                {
                    p2ShotgunCount++;
                }
            }

            setAsideDice.Add(drawnDiceList[2]);
            drawnDiceList[2] = null;




        }


        public void Update()
        {
            //p1 update
            textBoxPlayerBrainsThisRound.Text = p1BrainsCount.ToString();
            textBoxPlayerShotGunCount.Text = p1ShotgunCount.ToString();
            textBoxTotalPlayerBrains.Text = player1.BrainsCount.ToString();

            //p2 update
            textBoxPlayer2BrainsThisRound.Text = p2BrainsCount.ToString();
            textBoxPlayer2ShotgunCount.Text = p2ShotgunCount.ToString();
            textBoxTotalPlayer2Brains.Text = player2.BrainsCount.ToString();

            //update dice
            labelDice1Display.Text = diceOutcomes[0];
            labelDice1Display.BackColor = diceColors[0];
            labelDice2Display.Text = diceOutcomes[1];
            labelDice2Display.BackColor = diceColors[1];
            labelDice3Display.Text = diceOutcomes[2];
            labelDice3Display.BackColor = diceColors[2];

            //update turn info
            if (player1.IsPlayerTurn)
            {
                labelCurrentTurnDisplay.Text = "Current Turn: Player 1";
            }
            else
            {
                labelCurrentTurnDisplay.Text = "Current Turn: Player 2";
            }
        }



        public void ResetP1Counts()
        {
            p1BrainsCount = 0;
            p1ShotgunCount = 0;
        }

        public void ResetP2Counts()
        {
            p2BrainsCount = 0;
            p2ShotgunCount = 0;
        }

        /// <summary>
        /// switches to player 1's turn
        /// </summary>
        public void SwitchPlayer1Turn()
        {
            //changes turns to player 1
            player1.IsPlayerTurn = true;
            player2.IsPlayerTurn = false;

            //enable/disable appropriate buttons
            buttonPlayer2ReRoll.Enabled = false;
            buttonPlayer2StopAndScore.Enabled = false;
            buttonReRoll.Enabled = true;
            buttonStopAndScore.Enabled = true;


        }
        /// <summary>
        /// switches to player 2's turn
        /// </summary>
        public void SwitchPlayer2Turn()
        {
            //changes turns to player 2
            player1.IsPlayerTurn = false;
            player2.IsPlayerTurn = true;

            //enable/disable appropriate buttons
            buttonPlayer2ReRoll.Enabled = true;
            buttonPlayer2StopAndScore.Enabled = true;
            buttonReRoll.Enabled = false;
            buttonStopAndScore.Enabled = false;
        }

        
    }
}
