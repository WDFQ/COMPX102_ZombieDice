namespace Zombie_Dice_Jeff_Jia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void buttonVsAI_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form (Form2)
            PlayerVsAiForm newForm = new PlayerVsAiForm();

            this.Hide();
            PlayerVsAiForm.ShowDialog();
            this.Close();
        }

        private void buttonVsPlayer_Click(object sender, EventArgs e)
        {

        }
    }
}
