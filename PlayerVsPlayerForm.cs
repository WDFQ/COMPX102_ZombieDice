using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms.Design;

namespace Zombie_Dice_Jeff_Jia
{
    //declares enum for brain, shotgun, footsteps, doubleshotgun, and double brains
    public enum DiceResult {Brain, Shotgun, Footsteps, DoubleShotgun, DoubleBrain}

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
        DiceResult[] diceOutcomes = new DiceResult[3];
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
                //makes player 1 start first
                currentPlayer = player1;
                SwitchPlayerTurn();
                labelCurrentTurnDisplay.Text = "Current Turn: Player 1";
            }
            else
            {
                //makes player 2 start first
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
            //roll dice, evaluate, and update turn scores & graphics
            PlayGame(currentPlayer);
        }
        /// <summary>
        /// ends turn for player 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStopAndScore_Click(object sender, EventArgs e)
        {
            //update total brain scores and clears turn scores
            StopAndScore(currentPlayer);
        }
        /// <summary>
        /// Rolls/rerolls control for player 2. Gets 3 dice outcomes and evaluates them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlayer2ReRoll_Click(object sender, EventArgs e)
        {
            //roll dice, evaluate, and update scores & graphics
            PlayGame(currentPlayer);
        }


        /// <summary>
        /// ends turn for player 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlayer2StopAndScore_Click(object sender, EventArgs e)
        {
            //update total brain scores and clears turn scores
            StopAndScore(currentPlayer);
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /// <summary>
        /// Ends turn and scores the current brains in the turn into the total brains
        /// </summary>
        /// <param name="currentPlayer"></param>
        public void StopAndScore(Player currentPlayer)
        {
            //adds current turn brain count to total brain count
            currentPlayer.BrainsCount += currentPlayer.TurnBrainCount;

            //check if current player has 13 or more brains
            if (currentPlayer.BrainsCount >= 13)
            {
                if (currentPlayer == player2)
                {
                    //display game end message and restarts
                    MessageBox.Show($"Player 2 has collected {currentPlayer.BrainsCount} brains and won the game");
                    
                }
                else
                {
                    //display game end message and restarts
                    MessageBox.Show($"Player 1 has collected {currentPlayer.BrainsCount} brains and won the game");
                }
                Application.Restart();
            }
            else
            {
                //removes all null values as theyre not needed anymore
                drawnDiceList.RemoveAll(item => item == null);

                //moves all dice in the drawn dice list and all dice that were set aside back to the cup and clears the list 
                MoveAllDiceToCup();

                //resets turn couts, changes the player in turn, and updates labels & graphics
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

            //evaluates the dice outcomes
            DiceOutcomeEvaluation(currentPlayer);

            //check to see if the shotgun count is 3 or above
            if (currentPlayer.TurnShotgunCount >= 3)
            {
                //removes all null values as theyre not needed anymore
                drawnDiceList.RemoveAll(item => item == null);

                //shows player what they rolled before ending their turn
                UpdateGraphics();
                MessageBox.Show("3 shotguns!, turn over.");

                //moves all dice in the drawn dice list and all dice that were set aside back to the cup and clears the list 
                MoveAllDiceToCup();

                //resets turn couts, changes the player in turn, and updates labels & graphics
                ResetPlayerCounts();
                SwitchPlayerTurn();
                UpdateGraphics();
                NullLabels();
                Debug.WriteLine(cup._diceList.Count);
            }
            else
            {
                //only update graphics with new rolls if shotgun count isnt 3 or above
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
                    //check if current die is a brain
                    if (setAsideDice[i].LastRoll == DiceResult.Brain)
                    {
                        cup._diceList.Add(setAsideDice[i]); //adds brain die back to cup
                        Debug.WriteLine($"{setAsideDice[i]} was added back into the cup");
                        setAsideDice.RemoveAt(i); //remove this brain die from the set aside list
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
        /// <param name="currentPlayer"></param>
        public void DiceOutcomeEvaluation(Player currentPlayer)
        {
            //loops through the array containing the outcomes
            for (int i = 0; i < diceOutcomes.Length; i++)
            {
                //checks for footsteps outcome, if its footsteps, dont set it aside
                if (diceOutcomes[i] != DiceResult.Footsteps)
                {
                    
                    //check for different types of dice and apply the corrosponding conditions
                    if (diceOutcomes[i] == DiceResult.Brain)
                    {
                        currentPlayer.TurnBrainCount++;
                    }
                    else if (diceOutcomes[i] == DiceResult.Shotgun)
                    {
                        currentPlayer.TurnShotgunCount++;

                        //Check if the shotgun is from hottie
                        if (drawnDiceList[i] is Hottie)
                        {   
                            //loop through setaside dice to see if we can find hunk
                            foreach (var item in setAsideDice)
                            {
                                //if we find hunk and the last roll is a brain
                                if (item is Hunk && item.LastRoll == DiceResult.Brain || item.LastRoll == DiceResult.DoubleBrain)
                                {
                                    //check how many brain to take away from player
                                    if (item.LastRoll == DiceResult.DoubleBrain)
                                    {
                                        //take away two brains if last roll is doublebrain
                                        currentPlayer.TurnBrainCount -= 2;
                                    }
                                    else if (item.LastRoll == DiceResult.Brain)
                                    {
                                        //take away one brain if lat roll is single
                                        currentPlayer.TurnBrainCount--;
                                    }

                                    //remove the die from the list and add it back into the cup
                                    cup._diceList.Add(item);
                                    setAsideDice.Remove(item);
                                    MessageBox.Show("The Hunk has been rescued by the Hottie!");
                                    break;
                                }
                            }
                        }
                        else if (drawnDiceList[i] is Hunk)
                        {
                            //
                            foreach (var item in setAsideDice)
                            {
                                if (item is Hottie && item.LastRoll == DiceResult.Brain)
                                {
                                    currentPlayer.TurnBrainCount--;

                                    //remove the die from the list and add it back into the cup
                                    cup._diceList.Add(item);
                                    setAsideDice.Remove(item);
                                    MessageBox.Show("The Hottie has been rescued by the Hunk!");
                                    break;
                                }
                            }
                        }

                    }
                    else if (diceOutcomes[i] == DiceResult.DoubleBrain)
                    {
                        currentPlayer.TurnBrainCount += 2;
                        
                    }
                    else if (diceOutcomes[i] == DiceResult.DoubleShotgun)
                    {
                        currentPlayer.TurnShotgunCount += 2;
                        
                    }
                    setAsideDice.Add(drawnDiceList[i]); // set the current non footstep die aside
                    drawnDiceList[i] = null; //equal to null to keep the positions of other objects in the list
                }
               
                
            }
        }

        /// <summary>
        /// Moves all dice from the drawn dice list and set aside list back into the cup 
        /// </summary>
        public void MoveAllDiceToCup()
        {
            //loops through drawn dice list and adds all values back into cup
            for (int i = 0; i < drawnDiceList.Count; i++)
            {
                cup._diceList.Add(drawnDiceList[i]);
            }
            drawnDiceList.Clear(); //clears list

            //loops through set aside dice and adds all values back into cup
            for (int i = 0; i < setAsideDice.Count; i++)
            {
                cup._diceList.Add(setAsideDice[i]);
            }
            setAsideDice.Clear(); //clears list
        }


        /// <summary>
        /// updates grahpics
        /// </summary>
        public void UpdateGraphics()
        {
            //p1 label updates
            textBoxPlayerBrainsThisRound.Text = player1.TurnBrainCount.ToString();
            textBoxPlayerShotGunCount.Text = player1.TurnShotgunCount.ToString();
            textBoxTotalPlayerBrains.Text = player1.BrainsCount.ToString();

            //p2 label updates
            textBoxPlayer2BrainsThisRound.Text = player2.TurnBrainCount.ToString();
            textBoxPlayer2ShotgunCount.Text = player2.TurnShotgunCount.ToString();
            textBoxTotalPlayer2Brains.Text = player2.BrainsCount.ToString();

            //updates dice name labels
            labelDice1Display.Text = diceOutcomes[0].ToString();
            labelDice2Display.Text = diceOutcomes[1].ToString();
            labelDice3Display.Text = diceOutcomes[2].ToString();


            //Checks each case for each die the user rolled and updates the pic boxes accordingly. I really tried to find a shorter way T-T
            //checks die 1 result
            if (diceOutcomes[0] == DiceResult.Brain)
            {
                //updates picturebox with the matching image
                pictureBoxDice1.Image = Properties.Resources.Brain;
            }
            else if (diceOutcomes[0] == DiceResult.Shotgun)
            {
                pictureBoxDice1.Image = Properties.Resources.Shotgun;
            }
            else if (diceOutcomes[0] == DiceResult.DoubleShotgun)
            {
                pictureBoxDice1.Image = Properties.Resources.DoubleShotgun;
            }
            else if (diceOutcomes[0] == DiceResult.DoubleBrain)
            {
                pictureBoxDice1.Image = Properties.Resources.DoubleBrain;
            }
            else
            {
                pictureBoxDice1.Image = Properties.Resources.Footsteps;
            }
            pictureBoxDice1Color.BackColor = diceColors[0]; //updates color

            //checks die 2 result
            if (diceOutcomes[1] == DiceResult.Brain)
            {
                pictureBoxDice2.Image = Properties.Resources.Brain;
            }
            else if (diceOutcomes[1] == DiceResult.Shotgun)
            {
                pictureBoxDice2.Image = Properties.Resources.Shotgun;
            }
            else if (diceOutcomes[1] == DiceResult.DoubleShotgun)
            {
                pictureBoxDice2.Image = Properties.Resources.DoubleShotgun;
            }
            else if (diceOutcomes[1] == DiceResult.DoubleBrain)
            {
                pictureBoxDice2.Image = Properties.Resources.DoubleBrain;
            }
            else
            {
                pictureBoxDice2.Image = Properties.Resources.Footsteps;
            }
            pictureBoxDice2Color.BackColor = diceColors[1]; //updates color

            //checks die 3 result
            if (diceOutcomes[2] == DiceResult.Brain)
            {
                pictureBoxDice3.Image = Properties.Resources.Brain;
            }
            else if (diceOutcomes[2] == DiceResult.Shotgun)
            {
                pictureBoxDice3.Image = Properties.Resources.Shotgun;
            }
            else if (diceOutcomes[2] == DiceResult.DoubleShotgun)
            {
                pictureBoxDice3.Image = Properties.Resources.DoubleShotgun;
            }
            else if (diceOutcomes[2] == DiceResult.DoubleBrain)
            {
                pictureBoxDice3.Image = Properties.Resources.DoubleBrain;
            }
            else
            {
                pictureBoxDice3.Image = Properties.Resources.Footsteps;
            }
            pictureBoxDice3Color.BackColor = diceColors[2]; //updates color

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
            //Emptys labels
            labelDice1Display.Text = "--";
            labelDice2Display.Text = "--";
            labelDice3Display.Text = "--";

            //nulls pictureboxes and their color
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
            //check which player's turn it is currently
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
