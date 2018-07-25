using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProxyPatternExample
{
    public partial class Main : Form
    {
        

        //0 = null
        //1 = log in
        private static byte runProcessId = 0;
        public static byte RunProcess
        {
            get { return runProcessId; }
            set { runProcessId = value; }
        }


        public Main()
        {
            InitializeComponent();
            //welcome text
            tbxProgram.AppendText("Welcome to Berlin Bank. Please insert your bank account card.." + Environment.NewLine);
            

        }

        //USE Card button 
        private void btnPutCardIn_Click(object sender, EventArgs e)
        {   
            //do nothing if card has been inserted
            if(CardSystem.getCardStatus() == CardSystem.Card.OK)
            {
                tbxProgram.AppendText("...card is already in use." + Environment.NewLine);
                return;
            }


            tbxProgram.AppendText("reading...please wait.." + Environment.NewLine);
            System.Threading.Thread.Sleep(3250);
            CardSystem.setCardStatus(true);
            setStatusGreen();
            tbxProgram.AppendText("..done" + Environment.NewLine);
            
            tbxProgram.AppendText("please type in your pin code and confirm.." + Environment.NewLine);
            
            RunProcess = 1;





        }

        //set panel colour green
        private void setStatusGreen()
        {
            panelStatusCard.BackColor = Color.Green;
        }
        //set panel colour black
        private void setStatusBlack()
        {
            panelStatusCard.BackColor = Color.Black;
        }

        //abled or enabled the numeric keypad
        private void isBlockNb(bool blocked)
        {
            btnNB0.Enabled = blocked;
            btnNB1.Enabled = blocked;
            btnNB2.Enabled = blocked;
            btnNB3.Enabled = blocked;
            btnNB4.Enabled = blocked;
            btnNB5.Enabled = blocked;
            btnNB6.Enabled = blocked;
            btnNB7.Enabled = blocked;
            btnNB8.Enabled = blocked;
            btnNB9.Enabled = blocked;
            btnClear.Enabled = blocked;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PIN: 3749","Note",MessageBoxButtons.OK);
        }
    }
}
