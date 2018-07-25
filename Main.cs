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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PIN: 3749","Note",MessageBoxButtons.OK);
        }


        
        private void btnAbort_Click(object sender, EventArgs e)
        {
           abortProgram();
        }
        

        
        private void userInput(char c, bool isPassword)
        {
            if (isPassword)
            {
                tbxUserInput.AppendText("*");


            }
        }


        public void abortProgram()
        {
            ctOS.useProgram(5);
        }

        public void useUserInputFielAsPassword(char c)
        {
            String s = c.ToString();
            tbxUserInput.AppendText();
        }


    }
}
