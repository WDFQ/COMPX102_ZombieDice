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
            for (int i = 0; i < 3; i++)
            {
                Die die = cup.DrawDie();
                drawnDiceList.Add(die);
            }

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

            CheckDieAmount();

            diceOutcomes[0] = drawnDiceList[0].Roll();
            diceColors[0] = drawnDiceList[0].GetDiceColor();

            diceOutcomes[1] = drawnDiceList[1].Roll();
            diceColors[1] = drawnDiceList[1].GetDiceColor();

            diceOutcomes[2] = drawnDiceList[2].Roll();
            diceColors[2] = drawnDiceList[2].GetDiceColor();

            DiceOutcomeEvaluation(diceOutcomes[0], diceOutcomes[1], diceOutcomes[2]);



            if (p1ShotgunCount >= 3)
            {
                UpdateGraphics();
                MessageBox.Show("3 shotguns!, turn over.");
                for (int i = setAsideDice.Count - 1; i >= 0; i--)
                {
                    cup._diceList.Add(setAsideDice[i]);
                    setAsideDice.RemoveAt(i);  // Safely remove items by index
                }

                drawnDiceList.Clear();
                setAsideDice.Clear();
                ResetP1Counts();
                SwitchPlayer2Turn();
                UpdateGraphics();
                NullLabels();
            }
            else
            {
                UpdateGraphics();

            }

            Debug.WriteLine(cup._diceList.Count);

        }

        private void buttonStopAndScore_Click(object sender, EventArgs e)
        {



            for (int i = setAsideDice.Count - 1; i >= 0; i--)
            {
                cup._diceList.Add(setAsideDice[i]);
                setAsideDice.RemoveAt(i);  // Safely remove items by index
            }

            player1.BrainsCount += p1BrainsCount;

            if (player1.BrainsCount >= 13)
            {
                MessageBox.Show($"player 1 has collected {player1.BrainsCount} brains and won the game");

                Application.Restart();
            }
            else
            {
                drawnDiceList.Clear();
                setAsideDice.Clear();
                ResetP1Counts();
                SwitchPlayer2Turn();
                UpdateGraphics();
                NullLabels();
            }


        }

        private void buttonPlayer2ReRoll_Click(object sender, EventArgs e)
        {
            Console.WriteLine(cup._diceList.Count.ToString());

            CheckDieAmount();

            diceOutcomes[0] = drawnDiceList[0].Roll();
            diceColors[0] = drawnDiceList[0].GetDiceColor();

            diceOutcomes[1] = drawnDiceList[1].Roll();
            diceColors[1] = drawnDiceList[1].GetDiceColor();

            diceOutcomes[2] = drawnDiceList[2].Roll();
            diceColors[2] = drawnDiceList[2].GetDiceColor();

            DiceOutcomeEvaluation(diceOutcomes[0], diceOutcomes[1], diceOutcomes[2]);


            if (p2ShotgunCount >= 3)
            {
                UpdateGraphics();
                MessageBox.Show("3 shotguns!, turn over.");
                for (int i = setAsideDice.Count - 1; i >= 0; i--)
                {
                    cup._diceList.Add(setAsideDice[i]);
                    setAsideDice.RemoveAt(i);  // Safely remove items by index
                }

                drawnDiceList.Clear();
                setAsideDice.Clear();
                ResetP2Counts();
                SwitchPlayer1Turn();
                UpdateGraphics();
                NullLabels();
            }
            else
            {
                UpdateGraphics();

            }

            Debug.WriteLine(cup._diceList.Count);

        }

        private void buttonPlayer2StopAndScore_Click(object sender, EventArgs e)
        {



            for (int i = setAsideDice.Count - 1; i >= 0; i--)
            {
                cup._diceList.Add(setAsideDice[i]);
                setAsideDice.RemoveAt(i);  // Safely remove items by index
            }

            player2.BrainsCount += p2BrainsCount;

            if (player1.BrainsCount >= 13)
            {
                MessageBox.Show($"player 1 has collected {player1.BrainsCount} brains and won the game");
                Application.Restart();
            }
            else
            {
                drawnDiceList.Clear();
                setAsideDice.Clear();
                ResetP2Counts();
                SwitchPlayer1Turn();


                UpdateGraphics();
                NullLabels();
            }


        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////




        /// <summary>
        ///checks die amount and populates accordingly
        /// </summary>
        public void CheckDieAmount()
        {
            //removes all null values as theyre not needed anymore
            drawnDiceList.RemoveAll(item => item == null);

            if (cup._diceList.Count < 3)
            {
                //loop from end to beginning to make sure the indexes dont get messed up when removing from lists
                for (int i = setAsideDice.Count - 1; i >= 0; i--)
                {
                    if (setAsideDice[i].LastRoll == "Brain")
                    {
                        cup._diceList.Add(setAsideDice[i]);
                        Debug.WriteLine($"{setAsideDice[i]} was added back into the cup");
                        setAsideDice.RemoveAt(i);

                    }

                    // stop adding once we have 3 dice in total
                    if (cup._diceList.Count >= 3)
                    {
                        break;
                    }

                }
            }

            //check if list contains any dice outcomes, which determines how many dices to roll
            if (drawnDiceList.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    Die die = cup.DrawDie();
                    drawnDiceList.Add(die);
                }
            }
            else if (drawnDiceList.Count == 2)
            {
                Die die = cup.DrawDie();
                drawnDiceList.Add(die);

            }
            else if (drawnDiceList.Count == 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Die die = cup.DrawDie();
                    drawnDiceList.Add(die);
                }
            }
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
            else if (dice1Outcome == "DoubleBrain")
            {
                if (player1.IsPlayerTurn)
                {
                    p1BrainsCount += 2;

                }
                else
                {
                    p2BrainsCount += 2;
                }
            }
            else if (dice1Outcome == "DoubleShotgun")
            {
                if (player1.IsPlayerTurn)
                {
                    p1ShotgunCount += 2;

                }
                else
                {
                    p2ShotgunCount += 2;
                }
            }

            setAsideDice.Add(drawnDiceList[0]);
            //sets null instead of delete so that the list order doesnt change when trying to get the index of the die to set aside
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
            else if (dice2Outcome == "DoubleBrain")
            {
                if (player1.IsPlayerTurn)
                {
                    p1BrainsCount += 2;

                }
                else
                {
                    p2BrainsCount += 2;
                }
            }
            else if (dice2Outcome == "DoubleShotgun")
            {
                if (player1.IsPlayerTurn)
                {
                    p1ShotgunCount += 2;

                }
                else
                {
                    p2ShotgunCount += 2;
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
            else if (dice3Outcome == "DoubleBrain")
            {
                if (player1.IsPlayerTurn)
                {
                    p1BrainsCount += 2;

                }
                else
                {
                    p2BrainsCount += 2;
                }
            }
            else if (dice3Outcome == "DoubleShotgun")
            {
                if (player1.IsPlayerTurn)
                {
                    p1ShotgunCount += 2;

                }
                else
                {
                    p2ShotgunCount += 2;
                }
            }

            setAsideDice.Add(drawnDiceList[2]);
            drawnDiceList[2] = null;

        }


        /// <summary>
        /// updates grahpics
        /// </summary>
        public void UpdateGraphics()
        {
            //p1 update
            textBoxPlayerBrainsThisRound.Text = p1BrainsCount.ToString();
            textBoxPlayerShotGunCount.Text = p1ShotgunCount.ToString();
            textBoxTotalPlayerBrains.Text = player1.BrainsCount.ToString();

            //p2 update
            textBoxPlayer2BrainsThisRound.Text = p2BrainsCount.ToString();
            textBoxPlayer2ShotgunCount.Text = p2ShotgunCount.ToString();
            textBoxTotalPlayer2Brains.Text = player2.BrainsCount.ToString();

            //update dice labels
            labelDice1Display.Text = diceOutcomes[0];
            labelDice2Display.Text = diceOutcomes[1];
            labelDice3Display.Text = diceOutcomes[2];
            //labelDice1Display.BackColor = diceColors[0];
            //labelDice2Display.BackColor = diceColors[1];
            //labelDice3Display.BackColor = diceColors[2];


            //update dice images
            if (diceOutcomes[0] == "Brain")
            {
                pictureBoxDice1.Image = Properties.Resources.Brain;
            }
            else if (diceOutcomes[0] == "Shotgun")
            {
                pictureBoxDice1.Image = Properties.Resources.Shotgun;
            }
            else if (diceOutcomes[0] == "DoubleShotgun")
            {
                pictureBoxDice1.Image = Properties.Resources.DoubleShotgun;
            }
            else if (diceOutcomes[0] == "DoubleBrain")
            {
                pictureBoxDice1.Image = Properties.Resources.DoubleBrain;
            }
            else
            {
                pictureBoxDice1.Image = Properties.Resources.Footsteps;
            }
            pictureBoxDice1Color.BackColor = diceColors[0];




            if (diceOutcomes[1] == "Brain")
            {
                pictureBoxDice2.Image = Properties.Resources.Brain;
            }
            else if (diceOutcomes[1] == "Shotgun")
            {
                pictureBoxDice2.Image = Properties.Resources.Shotgun;
            }
            else if (diceOutcomes[1] == "DoubleShotgun")
            {
                pictureBoxDice2.Image = Properties.Resources.DoubleShotgun;
            }
            else if (diceOutcomes[1] == "DoubleBrain")
            {
                pictureBoxDice2.Image = Properties.Resources.DoubleBrain;
            }
            else
            {
                pictureBoxDice2.Image = Properties.Resources.Footsteps;
            }
            pictureBoxDice2Color.BackColor = diceColors[1];

            if (diceOutcomes[2] == "Brain")
            {
                pictureBoxDice3.Image = Properties.Resources.Brain;
            }
            else if (diceOutcomes[2] == "Shotgun")
            {
                pictureBoxDice3.Image = Properties.Resources.Shotgun;
            }
            else if (diceOutcomes[2] == "DoubleShotgun")
            {
                pictureBoxDice3.Image = Properties.Resources.DoubleShotgun;
            }
            else if (diceOutcomes[2] == "DoubleBrain")
            {
                pictureBoxDice3.Image = Properties.Resources.DoubleBrain;
            }
            else
            {
                pictureBoxDice3.Image = Properties.Resources.Footsteps;
            }
            pictureBoxDice3Color.BackColor = diceColors[2];

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

        public void NullLabels()
        {
            //Nulls labels
            labelDice1Display.Text = "--";
            labelDice2Display.Text = "--";
            labelDice3Display.Text = "--";
            labelDice1Display.BackColor = Color.Transparent;
            labelDice2Display.BackColor = Color.Transparent;
            labelDice3Display.BackColor = Color.Transparent;


            //nulls pictureboxes
            pictureBoxDice1.Image = null;
            pictureBoxDice2.Image = null;
            pictureBoxDice3.Image = null;
            pictureBoxDice1Color.BackColor = Color.Transparent;
            pictureBoxDice2Color.BackColor = Color.Transparent;
            pictureBoxDice3Color.BackColor = Color.Transparent;
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
