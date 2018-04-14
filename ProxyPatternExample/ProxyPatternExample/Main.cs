using System;
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
                tbxProgram.AppendText("Can not read Card. Card is still in progress." + Environment.NewLine);
                return;
            }
            

        }
    }
}
