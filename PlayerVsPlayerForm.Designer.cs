namespace Zombie_Dice_Jeff_Jia
{
    partial class PlayerVsPlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxTotalPlayer2Brains = new TextBox();
            label4 = new Label();
            textBoxTotalPlayerBrains = new TextBox();
            label2 = new Label();
            textBoxPlayerBrainsThisRound = new TextBox();
            label1 = new Label();
            textBoxPlayerShotGunCount = new TextBox();
            buttonStopAndScore = new Button();
            buttonReRoll = new Button();
            label5 = new Label();
            label3 = new Label();
            textBoxPlayer2BrainsThisRound = new TextBox();
            label6 = new Label();
            textBoxPlayer2ShotgunCount = new TextBox();
            buttonPlayer2StopAndScore = new Button();
            buttonPlayer2ReRoll = new Button();
            labelDice1Display = new Label();
            labelDice2Display = new Label();
            labelDice3Display = new Label();
            labelCurrentTurnDisplay = new Label();
            SuspendLayout();
            // 
            // textBoxTotalPlayer2Brains
            // 
            textBoxTotalPlayer2Brains.Location = new Point(1085, 140);
            textBoxTotalPlayer2Brains.Margin = new Padding(5);
            textBoxTotalPlayer2Brains.Name = "textBoxTotalPlayer2Brains";
            textBoxTotalPlayer2Brains.ReadOnly = true;
            textBoxTotalPlayer2Brains.Size = new Size(201, 39);
            textBoxTotalPlayer2Brains.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 140);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(225, 32);
            label4.TabIndex = 17;
            label4.Text = "Total Player1 Brains:";
            // 
            // textBoxTotalPlayerBrains
            // 
            textBoxTotalPlayerBrains.Location = new Point(329, 133);
            textBoxTotalPlayerBrains.Margin = new Padding(5);
            textBoxTotalPlayerBrains.Name = "textBoxTotalPlayerBrains";
            textBoxTotalPlayerBrains.ReadOnly = true;
            textBoxTotalPlayerBrains.Size = new Size(201, 39);
            textBoxTotalPlayerBrains.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 78);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(304, 32);
            label2.TabIndex = 15;
            label2.Text = "Brains eaten from this turn:";
            // 
            // textBoxPlayerBrainsThisRound
            // 
            textBoxPlayerBrainsThisRound.Location = new Point(329, 73);
            textBoxPlayerBrainsThisRound.Margin = new Padding(5);
            textBoxPlayerBrainsThisRound.Name = "textBoxPlayerBrainsThisRound";
            textBoxPlayerBrainsThisRound.ReadOnly = true;
            textBoxPlayerBrainsThisRound.Size = new Size(201, 39);
            textBoxPlayerBrainsThisRound.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 25);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(182, 32);
            label1.TabIndex = 13;
            label1.Text = "Shotgun Count:";
            // 
            // textBoxPlayerShotGunCount
            // 
            textBoxPlayerShotGunCount.Location = new Point(329, 14);
            textBoxPlayerShotGunCount.Margin = new Padding(5);
            textBoxPlayerShotGunCount.Name = "textBoxPlayerShotGunCount";
            textBoxPlayerShotGunCount.ReadOnly = true;
            textBoxPlayerShotGunCount.Size = new Size(201, 39);
            textBoxPlayerShotGunCount.TabIndex = 12;
            // 
            // buttonStopAndScore
            // 
            buttonStopAndScore.Enabled = false;
            buttonStopAndScore.Location = new Point(116, 632);
            buttonStopAndScore.Margin = new Padding(5);
            buttonStopAndScore.Name = "buttonStopAndScore";
            buttonStopAndScore.Size = new Size(205, 58);
            buttonStopAndScore.TabIndex = 11;
            buttonStopAndScore.Text = "Stop and Score";
            buttonStopAndScore.UseVisualStyleBackColor = true;
            buttonStopAndScore.Click += buttonStopAndScore_Click;
            // 
            // buttonReRoll
            // 
            buttonReRoll.Enabled = false;
            buttonReRoll.Location = new Point(116, 504);
            buttonReRoll.Margin = new Padding(5);
            buttonReRoll.Name = "buttonReRoll";
            buttonReRoll.Size = new Size(205, 118);
            buttonReRoll.TabIndex = 10;
            buttonReRoll.Text = "Roll";
            buttonReRoll.UseVisualStyleBackColor = true;
            buttonReRoll.Click += buttonReRoll_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(773, 140);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(225, 32);
            label5.TabIndex = 20;
            label5.Text = "Total Player2 Brains:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(773, 76);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(304, 32);
            label3.TabIndex = 24;
            label3.Text = "Brains eaten from this turn:";
            // 
            // textBoxPlayer2BrainsThisRound
            // 
            textBoxPlayer2BrainsThisRound.Location = new Point(1085, 71);
            textBoxPlayer2BrainsThisRound.Margin = new Padding(5);
            textBoxPlayer2BrainsThisRound.Name = "textBoxPlayer2BrainsThisRound";
            textBoxPlayer2BrainsThisRound.ReadOnly = true;
            textBoxPlayer2BrainsThisRound.Size = new Size(201, 39);
            textBoxPlayer2BrainsThisRound.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(773, 23);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(182, 32);
            label6.TabIndex = 22;
            label6.Text = "Shotgun Count:";
            // 
            // textBoxPlayer2ShotgunCount
            // 
            textBoxPlayer2ShotgunCount.Location = new Point(1085, 12);
            textBoxPlayer2ShotgunCount.Margin = new Padding(5);
            textBoxPlayer2ShotgunCount.Name = "textBoxPlayer2ShotgunCount";
            textBoxPlayer2ShotgunCount.ReadOnly = true;
            textBoxPlayer2ShotgunCount.Size = new Size(201, 39);
            textBoxPlayer2ShotgunCount.TabIndex = 21;
            // 
            // buttonPlayer2StopAndScore
            // 
            buttonPlayer2StopAndScore.Enabled = false;
            buttonPlayer2StopAndScore.Location = new Point(983, 632);
            buttonPlayer2StopAndScore.Margin = new Padding(5);
            buttonPlayer2StopAndScore.Name = "buttonPlayer2StopAndScore";
            buttonPlayer2StopAndScore.Size = new Size(205, 58);
            buttonPlayer2StopAndScore.TabIndex = 26;
            buttonPlayer2StopAndScore.Text = "Stop and Score";
            buttonPlayer2StopAndScore.UseVisualStyleBackColor = true;
            buttonPlayer2StopAndScore.Click += buttonPlayer2StopAndScore_Click;
            // 
            // buttonPlayer2ReRoll
            // 
            buttonPlayer2ReRoll.Enabled = false;
            buttonPlayer2ReRoll.Location = new Point(983, 504);
            buttonPlayer2ReRoll.Margin = new Padding(5);
            buttonPlayer2ReRoll.Name = "buttonPlayer2ReRoll";
            buttonPlayer2ReRoll.Size = new Size(205, 118);
            buttonPlayer2ReRoll.TabIndex = 25;
            buttonPlayer2ReRoll.Text = "Roll";
            buttonPlayer2ReRoll.UseVisualStyleBackColor = true;
            buttonPlayer2ReRoll.Click += buttonPlayer2ReRoll_Click;
            // 
            // labelDice1Display
            // 
            labelDice1Display.AutoSize = true;
            labelDice1Display.Font = new Font("Unispace", 19.875F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelDice1Display.Location = new Point(128, 317);
            labelDice1Display.Name = "labelDice1Display";
            labelDice1Display.Size = new Size(91, 64);
            labelDice1Display.TabIndex = 27;
            labelDice1Display.Text = "--";
            // 
            // labelDice2Display
            // 
            labelDice2Display.AutoSize = true;
            labelDice2Display.Font = new Font("Unispace", 19.875F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelDice2Display.Location = new Point(505, 317);
            labelDice2Display.Name = "labelDice2Display";
            labelDice2Display.Size = new Size(91, 64);
            labelDice2Display.TabIndex = 28;
            labelDice2Display.Text = "--";
            // 
            // labelDice3Display
            // 
            labelDice3Display.AutoSize = true;
            labelDice3Display.Font = new Font("Unispace", 19.875F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelDice3Display.Location = new Point(881, 317);
            labelDice3Display.Name = "labelDice3Display";
            labelDice3Display.Size = new Size(91, 64);
            labelDice3Display.TabIndex = 29;
            labelDice3Display.Text = "--";
            // 
            // labelCurrentTurnDisplay
            // 
            labelCurrentTurnDisplay.AutoSize = true;
            labelCurrentTurnDisplay.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            labelCurrentTurnDisplay.Location = new Point(427, 640);
            labelCurrentTurnDisplay.Name = "labelCurrentTurnDisplay";
            labelCurrentTurnDisplay.Size = new Size(337, 39);
            labelCurrentTurnDisplay.TabIndex = 30;
            labelCurrentTurnDisplay.Text = "Current Turn: --";
            // 
            // PlayerVsPlayerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 710);
            Controls.Add(labelCurrentTurnDisplay);
            Controls.Add(labelDice3Display);
            Controls.Add(labelDice2Display);
            Controls.Add(labelDice1Display);
            Controls.Add(buttonPlayer2StopAndScore);
            Controls.Add(buttonPlayer2ReRoll);
            Controls.Add(label3);
            Controls.Add(textBoxPlayer2BrainsThisRound);
            Controls.Add(label6);
            Controls.Add(textBoxPlayer2ShotgunCount);
            Controls.Add(label5);
            Controls.Add(textBoxTotalPlayer2Brains);
            Controls.Add(label4);
            Controls.Add(textBoxTotalPlayerBrains);
            Controls.Add(label2);
            Controls.Add(textBoxPlayerBrainsThisRound);
            Controls.Add(label1);
            Controls.Add(textBoxPlayerShotGunCount);
            Controls.Add(buttonStopAndScore);
            Controls.Add(buttonReRoll);
            Name = "PlayerVsPlayerForm";
            Text = " ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTotalPlayer2Brains;
        private Label label4;
        private TextBox textBoxTotalPlayerBrains;
        private Label label2;
        private TextBox textBoxPlayerBrainsThisRound;
        private Label label1;
        private TextBox textBoxPlayerShotGunCount;
        private Button buttonStopAndScore;
        private Button buttonReRoll;
        private Label label5;
        private Label label3;
        private TextBox textBoxPlayer2BrainsThisRound;
        private Label label6;
        private TextBox textBoxPlayer2ShotgunCount;
        private Button buttonPlayer2StopAndScore;
        private Button buttonPlayer2ReRoll;
        private Label labelDice1Display;
        private Label labelDice2Display;
        private Label labelDice3Display;
        private Label labelCurrentTurnDisplay;
    }
}