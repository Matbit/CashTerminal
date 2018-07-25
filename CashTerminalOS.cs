using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class CashTerminalOS
    {

        Main mainGui;

        public CashTerminalOS(Main mainGui)
        {
            this.mainGui = mainGui;
        }

        public void useProgram(byte processID)
        {
            if(processID == 0)
            {
                mainGui.setView("Welcome to Berlin Bank. Please insert your bank account card..", false);
                    
                     
            }
            else if(processID == 1) 
            {
                //login
                processLogin();

            }
            else if(processID == 2)
            {
                //get money
            }
            else if(processID == 3)
            {
                //get acc balance
            }
            else if(processID == 4)
            {
                //print acc history
            }
            else if(processID == 5)
            {
                //exit
            }
            //else error message
        }




        //login
        private void processLogin()
        {
            //do nothing if card has been inserted
            if (CardSystem.getCardStatus() == CardSystem.Card.OK)
            {
                mainGui.setView("...card is already in use.", false);
                return;
            }


            mainGui.setView("reading...please wait..", false);
            System.Threading.Thread.Sleep(3250);
            CardSystem.setCardStatus(true);
            mainGui.setStatusGreen();
            mainGui.setView("..done", false);
            mainGui.setView("please type in your pin code and confirm..", false);
            mainGui.isAvailableUseCardBtn(false);
        }




    }
}
