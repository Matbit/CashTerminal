using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProxyPatternExample
{
    public partial class Main : Form
    {
              
        CashTerminalOS ctOS;

        public Main()
        {
            InitializeComponent();
            ctOS = new CashTerminalOS(this);

            //usertb
            tbxUserInput.PasswordChar = '*';
            tbxUserInput.MaxLength = 4;

            //program start
            ctOS.useProgram(0);
        }

        //View settings
        public void setView(String s, bool clearView)
        {
            if (clearView)
            {
                clearTbx();
                tbxProgram.Text = s + Environment.NewLine;
            }
            else if (!clearView)
            {
                tbxProgram.AppendText(s + Environment.NewLine);
            }
            
        }

        private void clearTbx()
        {
            tbxProgram.Clear();
        }
        //View userInput
        public void setViewUserInput(String s)
        {
            tbxUserInput.Text = s;
        }
        //clear view
        public void clearView()
        {
            tbxProgram.Text = "";
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

        public void abortProgram()
        {

            if (ctOS.ProcessID == 2 || ctOS.ProcessID == 3 || ctOS.ProcessID == 4)
            {
                ctOS.useProgram(6);
            }
            else if(ctOS.ProcessID == 9) 
            {
                ctOS.useProgram(0);
            }    
            else if(ctOS.ProcessID == 10)
            {
                ctOS.useProgram(1);
            }
            else if(ctOS.ProcessID == 11)
            {
                ctOS.useProgram(6);
            }
            else if(ctOS.ProcessID == 12)
            {
                ctOS.useProgram(2);
            }
            else if(ctOS.ProcessID == 13)
            {
                ctOS.useProgram(6);
            }

            else ctOS.useProgram(5);//log out
        }

        private void userInput(string s)
        {   
            if(tbxUserInput.TextLength >= 4)
            {
                return;
            }
            tbxUserInput.AppendText(s);
            
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

            if(ctOS.ProcessID == 6)
            {
                ctOS.useProgram(5);
            }
            else
            {
                userInput("4");
            }            
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

            if(ctOS.ProcessID == 6)
            {
                useUserInputFielAsPassword(true);
                userInput("1");
                ctOS.useProgram(2);

            }
            else userInput("1");
        }

        private void btnNB2_Click(object sender, EventArgs e)
        {   
            if(ctOS.ProcessID == 6)
            {
                useUserInputFielAsPassword(true);
                //userInput("2");
                ctOS.useProgram(3);
            }
            else userInput("2");
        }

        private void btnNB3_Click(object sender, EventArgs e)
        {

            if(ctOS.ProcessID == 6)
            {
                ctOS.useProgram(4);
            }
            else userInput("3");
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            byte processID = ctOS.ProcessID;

            if(processID == 1)
            {
                ctOS.useProgram(7);
            }
            else if(processID == 2)
            {
                ctOS.useProgram(8);
            }
            else if(processID == 8)
            {
                ctOS.useProgram(5);
            }
        }

        public String getUserInput()
        {
            return tbxUserInput.Text;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if(ctOS.ProcessID == 0)
            {
                ctOS.useProgram(9);
            }
            else if(ctOS.ProcessID == 1)
            {
                ctOS.useProgram(10);
            }
            else if(ctOS.ProcessID == 6)
            {
                ctOS.useProgram(11);
            }
            else if(ctOS.ProcessID == 2)
            {
                ctOS.useProgram(12);
            }
            else if(ctOS.ProcessID == 3 || ctOS.ProcessID == 4)
            {
                ctOS.useProgram(13);
            }
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //  string link = "https://en.wikipedia.org/wiki/Proxy_pattern";
        //linklabelMore.LinkVisited = true;
        //System.Diagnostics.Process.Start(link);
        //}
    }
}
