using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class CashTerminalOS
    {
        private byte processID;
        public byte ProcessID { get; set; }
        readonly Main mainGui;

        ProxyCashTerminal proxy;

        public CashTerminalOS(Main mainGui)
        {
            this.mainGui = mainGui;
            proxy = new ProxyCashTerminal();
            ProcessID = 0;
        }

        public void useProgram(byte processID)
        {
            ProcessID = 0;
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
                ProcessID = 1;
                processLogin();

            }
            else if(processID == 2)
            {
                //get money
                ProcessID = 2;
            }
            else if(processID == 3)
            {
                //get acc balance
                ProcessID = 3;
            }
            else if(processID == 4)
            {
                //print acc history
                ProcessID = 4;
            }
            else if(processID == 5)
            {
                //exit
                ProcessID = 5;
                processExit();
            }
            else if(processID == 6)
            {
                //main menu
                ProcessID = 6;

            }
            else if(processID == 7)
            {
                //check pin
                checkPinCode();

            }
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

        //login - check pin code
        private void checkPinCode()
        {
            String pin = mainGui.getUserInput();
            int pinCode = Int32.Parse(pin);
            bool ok = proxy.checkPinCode(pinCode);
            if (ok)
            {
                ProcessID = 6;
                //run main process
            }
            if (!ok)
            {
                setBankTitle();
                mainGui.setView("wrong pin. Please try again..", false);
                mainGui.setViewUserInput("");
            }

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
