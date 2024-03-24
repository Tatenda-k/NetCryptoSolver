using System.Collections.Generic;

namespace Net6CryptoSolver
{
    /// <summary>
    /// THe GUI
    /// </summary>
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
            LoadE();
            
        }




        /// <summary>
        /// a substitution cipher object
        /// </summary>
        SubstitutionCipher _cipher = new SubstitutionCipher();
        /// <summary>
        /// reads in the dictionary file
        /// </summary>
        private void LoadE()
        {
            if (!_cipher.ReadDictionary("C:\\Users\\taten\\Source\\Repos\\homework-assignment-4-Tatenda-k\\TestProject\\bin\\Debug\\net6.0-windows\\..\\..\\..\\dictionary.txt"))
            {
                Environment.Exit(0);
            }
        }




        


        /// <summary>
        /// checks for errors and encrypts the given message
        /// </summary>
        /// <param name="sender"> what signaled the event </param>
        /// <param name="e">informationo about the event</param>
        private void UxEncrypt_Click(object sender, EventArgs e)
        {
            if (_cipher.ContainsInvalid(uxMessage.Text))
            {
                uxResult.Text="Error: Invalid characters. Only lowercase letters and spaces allowed.";
            }
            else if (!_cipher.AllWords(uxMessage.Text))
            {
                uxResult.Text = "Error: not all words are in the dictionary.";
            }
            //how to access allwords


            else
            {
               uxResult.Text= _cipher.Encrypt(uxMessage.Text);
                
            }
                
        }
        /// <summary>
        /// decrypts the messgage in the top textbox
        /// </summary>
        /// <param name="sender">what signaled the event</param>
        /// <param name="e">information about the event</param>

        private void UxDecrypt_Click(object sender, EventArgs e)
        {
            if (_cipher.ContainsInvalid(uxMessage.Text))
            {
                uxResult.Text="Error: Invalid characters. Only lowercase letters and spaces allowed.";

            }
            //check dictionary
            else
            {
                bool solved;
                string x=_cipher.Decrypt(uxMessage.Text, out solved);
                if (solved)
                {
                    uxResult.Text=x;
                }
                else
                {
                    uxResult.Text="No solution exists";
                }
            }


        }
    }
}
