using System.Diagnostics;

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

        //keep track of the current player
        Player currentPlayer;
        
        //keeps track of rolled dice outcomes
        string[] diceOutcomes = new string[3];
        Color[] diceColors = new Color[3];

        //list of currently drawn dice  
        List<Die> drawnDiceList = new List<Die>();

        //List of currently set aside dice
        List<Die> setAsideDice = new List<Die>();

        /// <summary>
        /// This form constructor initilises the form, adds 13 dices to the cup, and decides which player goes first
        /// </summary>
        public PlayerVsPlayerForm()
        {
            InitializeComponent();

            //add 13 dice to the cup accordingly
            cup.AddDice();
            

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
                currentPlayer = player1;
                SwitchPlayerTurn();
                labelCurrentTurnDisplay.Text = "Current Turn: Player 1";
            }
            else
            {
                currentPlayer = player2;
                SwitchPlayerTurn();
                labelCurrentTurnDisplay.Text = "Current Turn: Player 2";
            }
        }

        /// <summary>
        /// Rolls/rerolls control for player 1. Gets 3 dice outcomes and evaluates them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReRoll_Click(object sender, EventArgs e)
        {
            PlayGame(currentPlayer);
        }
        /// <summary>
        /// ends turn for player 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStopAndScore_Click(object sender, EventArgs e)
        {
            StopAndScore(currentPlayer);
        }
        /// <summary>
        /// Rolls/rerolls control for player 2. Gets 3 dice outcomes and evaluates them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlayer2ReRoll_Click(object sender, EventArgs e)
        {
            PlayGame(currentPlayer);
        }


        /// <summary>
        /// ends turn for player 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlayer2StopAndScore_Click(object sender, EventArgs e)
        {
            StopAndScore(currentPlayer);
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Ends turn and scores the current brains in the turn into the total brains
        /// </summary>
        /// <param name="currentPlayer"></param>
        public void StopAndScore(Player currentPlayer)
        {
            currentPlayer.BrainsCount += currentPlayer.TurnBrainCount;

            if (currentPlayer.BrainsCount >= 13)
            {
                MessageBox.Show($"player 2 has collected {currentPlayer.BrainsCount} brains and won the game");
                Application.Restart();
            }
            else
            {
                //removes all null values as theyre not needed anymore
                drawnDiceList.RemoveAll(item => item == null);

                for (int i = drawnDiceList.Count - 1; i >= 0; i--)
                {
                    cup._diceList.Add(drawnDiceList[i]);
                }
                drawnDiceList.Clear();

                for (int i = setAsideDice.Count - 1; i >= 0; i--)
                {
                    cup._diceList.Add(setAsideDice[i]);
                }
                setAsideDice.Clear();

                ResetPlayerCounts();
                SwitchPlayerTurn();
                UpdateGraphics();
                NullLabels();
            }
        }

        /// <summary>
        /// Gets 3 dice outcomes and evaluates them. Updates graphics afterwards
        /// </summary>
        /// <param name="currentPlayer"></param>
        public void PlayGame(Player currentPlayer)
        {
            //check how many dice is already in the drawn list
            CheckDieAmount();

            //gets the outcomes and set them into the array
            diceOutcomes[0] = drawnDiceList[0].Roll();
            diceColors[0] = drawnDiceList[0].GetDiceColor();

            diceOutcomes[1] = drawnDiceList[1].Roll();
            diceColors[1] = drawnDiceList[1].GetDiceColor();

            diceOutcomes[2] = drawnDiceList[2].Roll();
            diceColors[2] = drawnDiceList[2].GetDiceColor();

            //evalutates the dice outcomes
            DiceOutcomeEvaluation(currentPlayer);

            //check to see if the shotgun count is 3 or above
            if (currentPlayer.TurnShotgunCount >= 3)
            {
                //removes all null values as theyre not needed anymore
                drawnDiceList.RemoveAll(item => item == null);

                //shows player what they rolled before ultimately ending their turn
                UpdateGraphics();
                MessageBox.Show("3 shotguns!, turn over.");

                //loops from back to front of the list to 
                for (int i = drawnDiceList.Count - 1; i >= 0; i--)
                {
                    cup._diceList.Add(drawnDiceList[i]);
                }
                drawnDiceList.Clear();


                for (int i = setAsideDice.Count - 1; i >= 0; i--)
                {
                    cup._diceList.Add(setAsideDice[i]);

                }
                setAsideDice.Clear();

                ResetPlayerCounts();
                SwitchPlayerTurn();
                UpdateGraphics();
                NullLabels();
                Debug.WriteLine(cup._diceList.Count);
            }
            else
            {
                UpdateGraphics();
                Debug.WriteLine(cup._diceList.Count);
            }
        }

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
            for (int i = drawnDiceList.Count; i < 3; i++)
            {
                Die die = cup.DrawDie();
                drawnDiceList.Add(die);

            }
        }

        /// <summary>
        /// evaluates each die
        /// </summary>
        /// <param name="dice1Outcome"></param>
        /// <param name="dice2Outcome"></param>
        /// <param name="dice3Outcome"></param>
        public void DiceOutcomeEvaluation(Player currentPlayer)
        {

            for (int i = 0; i < diceOutcomes.Length; i++)
            {

                if (diceOutcomes[i] != "Footsteps")
                {
                    if (diceOutcomes[i] == "Brain")
                    {
                        currentPlayer.TurnBrainCount++;
                        
                    }
                    else if (diceOutcomes[i] == "Shotgun")
                    {
                        currentPlayer.TurnShotgunCount++;
                        
                    }
                    else if (diceOutcomes[i] == "DoubleBrain")
                    {
                        currentPlayer.TurnBrainCount += 2;
                        
                    }
                    else if (diceOutcomes[i] == "DoubleShotgun")
                    {
                        currentPlayer.TurnShotgunCount += 2;
                        
                    }
                    setAsideDice.Add(drawnDiceList[i]);
                    drawnDiceList[i] = null; //equal to null to keep the positions of other objects in the list
                }
               
                
            }
        }


        /// <summary>
        /// updates grahpics
        /// </summary>
        public void UpdateGraphics()
        {
            //p1 update
            textBoxPlayerBrainsThisRound.Text = player1.TurnBrainCount.ToString();
            textBoxPlayerShotGunCount.Text = player1.TurnShotgunCount.ToString();
            textBoxTotalPlayerBrains.Text = player1.BrainsCount.ToString();

            //p2 update
            textBoxPlayer2BrainsThisRound.Text = player2.TurnBrainCount.ToString();
            textBoxPlayer2ShotgunCount.Text = player2.TurnShotgunCount.ToString();
            textBoxTotalPlayer2Brains.Text = player2.BrainsCount.ToString();

            //update dice labels
            labelDice1Display.Text = diceOutcomes[0];
            labelDice2Display.Text = diceOutcomes[1];
            labelDice3Display.Text = diceOutcomes[2];


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
        /// <summary>
        /// Emptys the labels nulls the pictureboxs 
        /// </summary>
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

        /// <summary>
        /// resets the turn counters
        /// </summary>
        public void ResetPlayerCounts()
        {
           currentPlayer.TurnBrainCount = 0;
           currentPlayer.TurnShotgunCount = 0; 
        }
        
        /// <summary>
        /// switches the players turns
        /// </summary>
        public void SwitchPlayerTurn()
        {

            if (player1.IsPlayerTurn)
            {
                //changes turns to player 2
                player1.IsPlayerTurn = false;
                player2.IsPlayerTurn = true;
                currentPlayer = player2;

                //enable/disable appropriate buttons
                buttonPlayer2ReRoll.Enabled = true;
                buttonPlayer2StopAndScore.Enabled = true;
                buttonReRoll.Enabled = false;
                buttonStopAndScore.Enabled = false;
            }
            else
            {
                //changes turns to player 1
                player1.IsPlayerTurn = true;
                player2.IsPlayerTurn = false;
                currentPlayer = player1;

                //enable/disable appropriate buttons
                buttonPlayer2ReRoll.Enabled = false;
                buttonPlayer2StopAndScore.Enabled = false;
                buttonReRoll.Enabled = true;
                buttonStopAndScore.Enabled = true;
                
            }  
        }
    }
}
