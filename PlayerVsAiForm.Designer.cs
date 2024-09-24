namespace Zombie_Dice_Jeff_Jia
{
    partial class PlayerVsAiForm
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
            buttonReRoll = new Button();
            buttonTakeScore = new Button();
            textBoxShotGunCount = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBoxTotalAIBrains = new TextBox();
            label4 = new Label();
            textBoxTotalPlayerBrains = new TextBox();
            SuspendLayout();
            // 
            // buttonReRoll
            // 
            buttonReRoll.Location = new Point(12, 318);
            buttonReRoll.Name = "buttonReRoll";
            buttonReRoll.Size = new Size(126, 74);
            buttonReRoll.TabIndex = 0;
            buttonReRoll.Text = "ReRoll";
            buttonReRoll.UseVisualStyleBackColor = true;
            // 
            // buttonTakeScore
            // 
            buttonTakeScore.Location = new Point(12, 398);
            buttonTakeScore.Name = "buttonTakeScore";
            buttonTakeScore.Size = new Size(126, 36);
            buttonTakeScore.TabIndex = 1;
            buttonTakeScore.Text = "Stop and Score";
            buttonTakeScore.UseVisualStyleBackColor = true;
            // 
            // textBoxShotGunCount
            // 
            textBoxShotGunCount.Location = new Point(204, 12);
            textBoxShotGunCount.Name = "textBoxShotGunCount";
            textBoxShotGunCount.ReadOnly = true;
            textBoxShotGunCount.Size = new Size(125, 27);
            textBoxShotGunCount.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 3;
            label1.Text = "Shotgun Count:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(186, 20);
            label2.TabIndex = 5;
            label2.Text = "Brains eaten from this turn:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(204, 49);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(550, 406);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 9;
            label3.Text = "Total AI Brains:";
            // 
            // textBoxTotalAIBrains
            // 
            textBoxTotalAIBrains.Location = new Point(663, 402);
            textBoxTotalAIBrains.Name = "textBoxTotalAIBrains";
            textBoxTotalAIBrains.ReadOnly = true;
            textBoxTotalAIBrains.Size = new Size(125, 27);
            textBoxTotalAIBrains.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(524, 368);
            label4.Name = "label4";
            label4.Size = new Size(133, 20);
            label4.TabIndex = 7;
            label4.Text = "Total Player Brains:";
            // 
            // textBoxTotalPlayerBrains
            // 
            textBoxTotalPlayerBrains.Location = new Point(663, 365);
            textBoxTotalPlayerBrains.Name = "textBoxTotalPlayerBrains";
            textBoxTotalPlayerBrains.ReadOnly = true;
            textBoxTotalPlayerBrains.Size = new Size(125, 27);
            textBoxTotalPlayerBrains.TabIndex = 6;
            // 
            // PlayerVsAiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(textBoxTotalAIBrains);
            Controls.Add(label4);
            Controls.Add(textBoxTotalPlayerBrains);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(textBoxShotGunCount);
            Controls.Add(buttonTakeScore);
            Controls.Add(buttonReRoll);
            Name = "PlayerVsAiForm";
            Text = "PlayerVsAiForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonReRoll;
        private Button buttonTakeScore;
        private TextBox textBoxShotGunCount;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBoxTotalAIBrains;
        private Label label4;
        private TextBox textBoxTotalPlayerBrains;
    }
}