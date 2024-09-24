namespace Zombie_Dice_Jeff_Jia
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonVsPlayer = new Button();
            buttonVsAI = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonVsPlayer
            // 
            buttonVsPlayer.Location = new Point(177, 273);
            buttonVsPlayer.Name = "buttonVsPlayer";
            buttonVsPlayer.Size = new Size(157, 65);
            buttonVsPlayer.TabIndex = 0;
            buttonVsPlayer.Text = "Player vs Player";
            buttonVsPlayer.UseVisualStyleBackColor = true;
            buttonVsPlayer.Click += buttonVsPlayer_Click;
            // 
            // buttonVsAI
            // 
            buttonVsAI.Location = new Point(542, 273);
            buttonVsAI.Name = "buttonVsAI";
            buttonVsAI.Size = new Size(157, 65);
            buttonVsAI.TabIndex = 1;
            buttonVsAI.Text = "Player vs AI";
            buttonVsAI.UseVisualStyleBackColor = true;
            buttonVsAI.Click += buttonVsAI_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(273, 104);
            label1.Name = "label1";
            label1.Size = new Size(301, 62);
            label1.TabIndex = 2;
            label1.Text = "Zombie Dice";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 533);
            Controls.Add(label1);
            Controls.Add(buttonVsAI);
            Controls.Add(buttonVsPlayer);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonVsPlayer;
        private Button buttonVsAI;
        private Label label1;
    }
}