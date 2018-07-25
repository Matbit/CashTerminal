using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProxyPatternExample
{
    public partial class Main : Form
    {
             

        ProxyCashTerminal proxy;
        CashTerminalOS ctOS;


        public Main()
        {
            InitializeComponent();
            proxy = new ProxyCashTerminal();
            ctOS = new CashTerminalOS(this);

            //usertb
            tbxUserInput.PasswordChar = '*';
            tbxUserInput.MaxLength = 6;

            //program start
            ctOS.useProgram(0);

        }

        //View settings
        public void setView(String s, bool clearView)
        {
            if (clearView)
            {
                tbxProgram.Clear();
                tbxProgram.AppendText(s + Environment.NewLine);
            }
            else if (!clearView)
            {
                tbxProgram.AppendText(s + Environment.NewLine);
            }
            
        }
        //View userInput
        public void setViewUserInput(String s)
        {
            tbxUserInput.Text = s;
        }

        //USE Card button 
        private void btnPutCardIn_Click(object sender, EventArgs e)
        {
            ctOS.useProgram(1);
            
        }

        //set panel colour green
        public void setStatusGreen()
        {
            panelStatusCard.BackColor = Color.Green;
        }
        //set panel colour black
        public void setStatusBlack()
        {
            panelStatusCard.BackColor = Color.Black;
        }

        //able or enabled the numeric keypad
        public void isAvailableNB(bool available)
        {
            btnNB0.Enabled = available;
            btnNB1.Enabled = available;
            btnNB2.Enabled = available;
            btnNB3.Enabled = available;
            btnNB4.Enabled = available;
            btnNB5.Enabled = available;
            btnNB6.Enabled = available;
            btnNB7.Enabled = available;
            btnNB8.Enabled = available;
            btnNB9.Enabled = available;
            btnClear.Enabled = available;
        }

        //use card btn - control
        public void isAvailableUseCardBtn(bool available)
        {
            btnPutCardIn.Enabled = available;
            
        }
        public void isAvailableConfirm(bool available)
        {
            btnConfirm.Enabled = available;
        }

        public void isAvailableAbort(bool available)
        {
            btnAbort.Enabled = available;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PIN: 3749","Note",MessageBoxButtons.OK);
        }


        
        private void btnAbort_Click(object sender, EventArgs e)
        {
           abortProgram();
        }
        

        
        private void userInput(string s)
        {   
            if(tbxUserInput.TextLength >= 4)
            {
                return;
            }
            tbxUserInput.AppendText(s);
            
        }


        public void abortProgram()
        {
            ctOS.useProgram(5);
        }

        public void useUserInputFielAsPassword(bool isPassword)
        {

            tbxUserInput.UseSystemPasswordChar = isPassword;

            
        }

        private void btnNB7_Click(object sender, EventArgs e)
        {
            userInput("7");
        }

        private void btnNB8_Click(object sender, EventArgs e)
        {
            userInput("8");
        }

        private void btnNB9_Click(object sender, EventArgs e)
        {
            userInput("9");
        }

        private void btnNB4_Click(object sender, EventArgs e)
        {
            userInput("4");
        }

        private void btnNB5_Click(object sender, EventArgs e)
        {
            userInput("5");
        }

        private void btnNB6_Click(object sender, EventArgs e)
        {
            userInput("6");
        }

        private void btnNB1_Click(object sender, EventArgs e)
        {
            userInput("1");
        }

        private void btnNB2_Click(object sender, EventArgs e)
        {
            userInput("2");
        }

        private void btnNB3_Click(object sender, EventArgs e)
        {
            userInput("3");
        }

        private void btnNB0_Click(object sender, EventArgs e)
        {
            userInput("0");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            String userText = tbxUserInput.Text;
            int length = userText.Length;
            try
            {
                userText = userText.Remove((length - 1));
            }
            catch
            {
                //
            }
            
            tbxUserInput.Text = userText;
        }
    }
}
