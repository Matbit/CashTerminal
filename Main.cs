using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProxyPatternExample
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnPutCardIn_Click(object sender, EventArgs e)
        {
            if(CardSystem.getCardStatus() == CardSystem.Card.OK)
            {
                tbxProgram.AppendText("Cannot read Card. Card is still in progress." + Environment.NewLine);
                return;
            }


            tbxProgram.AppendText("reading...please wait.." + Environment.NewLine);
            System.Threading.Thread.Sleep(3250);
            CardSystem.setCardStatus(true);
            setStatusGreen();



        }

        private void setStatusGreen()
        {
            panelStatusCard.BackColor = Color.Green;
        }
        private void setStatusBlack()
        {
            panelStatusCard.BackColor = Color.Black;
        }
    }
}
