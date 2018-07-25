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
                //start
                mainGui.isAvailableNB(false);
                mainGui.isAvailableAbort(false);
                mainGui.isAvailableConfirm(false);
                setBankTitle();
                mainGui.setView("Please insert your bank account card..", false);
                    
                     
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
                processExit();
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
            mainGui.isAvailableNB(true);
            mainGui.isAvailableConfirm(true);
            mainGui.isAvailableAbort(true);
            mainGui.useUserInputFielAsPassword(false);





        }

        //exit
        private void processExit()
        {
            mainGui.setViewUserInput("");
            setBankTitle();
            mainGui.setView("please wait a moment. you get your card back soon..", false);
            System.Threading.Thread.Sleep(3250);
            CardSystem.setCardStatus(false);
            mainGui.setStatusBlack();
            mainGui.setView("Thank you and we wish you a very nice day..".ToUpper(), false);
            System.Threading.Thread.Sleep(5000);
            mainGui.isAvailableNB(false);
            mainGui.isAvailableUseCardBtn(true);
            useProgram(0);
            

        }

        //helping methods
        private void setBankTitle()
        {
            mainGui.setView("$BERLIN BANK - your partner around the world$", true);
            setBlank();
        }

        private void setBlank()
        {
            mainGui.setView("", false);
        }




    }
}
