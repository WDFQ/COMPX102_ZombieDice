namespace Zombie_Dice_Jeff_Jia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// opens player vs ai form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVsAI_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form 
            PlayerVsAiForm pveForm = new PlayerVsAiForm();

            //opens new form
            this.Hide();
            pveForm.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// opens player vs player form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVsPlayer_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form 
            PlayerVsPlayerForm pvpForm = new PlayerVsPlayerForm();

            //opens new form
            this.Hide();
            pvpForm.ShowDialog();
            this.Close();

        }
    }
}
