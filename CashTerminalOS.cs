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
            //ProcessID = 0;
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
                getCash();
            }
            else if(processID == 3)
            {
                //get acc balance
                ProcessID = 3;
                getUserAccBalance();
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
                processMain();

            }
            else if(processID == 7)
            {
                //check pin
                checkPinCode();

            }
            else if(processID == 8)
            {
                //check user value
                ProcessID = 8;
                checkGetCashUser();
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
            System.Threading.Thread.Sleep(1250);
            CardSystem.setCardStatus(true);
            mainGui.setStatusGreen();
            mainGui.setView("..done", false);
            System.Threading.Thread.Sleep(800);
            setBankTitle();
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
                //run main process
                useProgram(6);
            }
            else if (!ok)
            {
                setBankTitle();
                mainGui.setView("wrong pin. Please try again..", false);
                mainGui.setViewUserInput("");
            }

        }

        //get cash
        private void getCash()
        {
            setBankTitle();
            mainGui.setView("Please choose an amount for your account operation..", false);
            mainGui.setViewUserInput("");
            mainGui.isAvailableConfirm(true);
                     
            
        }

        //get cash - check user value
        private void checkGetCashUser()
        {
            //validate user input
            String cashWanted = mainGui.getUserInput();
            Double cash = Double.Parse(cashWanted);

            bool isOrderOk = proxy.checkOrder(cash);
            if (isOrderOk)
            {
                proxy.getMoney(cash);
                mainGui.setView("Transaction was successful..", false);
                System.Threading.Thread.Sleep(500);
                useProgram(6);
            }
            else
            {
                setBankTitle();
                mainGui.setView("You have not enough money, or the value is above 1500€", false);
                System.Threading.Thread.Sleep(2000);
                useProgram(6);
            }
        }

        //get acc balance
        private void getUserAccBalance()
        {
            mainGui.isAvailableConfirm(false);
            setBankTitle();
            mainGui.setView(proxy.getAccountBalance(), false);
        }

       

        //exit
        private void processExit()
        {
            mainGui.clearView();
            setBankTitle();
            mainGui.setViewUserInput("");
            mainGui.setView("please wait a moment. you get your card back soon..", false);
            System.Threading.Thread.Sleep(3250);
            CardSystem.setCardStatus(false);
            mainGui.setStatusBlack();
            System.Threading.Thread.Sleep(100);
            setBankTitle();
            mainGui.setView("Thank you and we wish you a very nice day..".ToUpper(), false);
            System.Threading.Thread.Sleep(5000);
            mainGui.isAvailableNB(false);
            mainGui.isAvailableUseCardBtn(true);
            useProgram(0);
            

        }

        //main
        private void processMain()
        {
            mainGui.setViewUserInput("");
            setBankTitle();
            System.Threading.Thread.Sleep(500);
            setMainMenu();
            mainGui.isAvailableAbort(true);
            mainGui.isAvailableConfirm(false);
            mainGui.isAvailableNB(true);
            mainGui.isAvailableUseCardBtn(false);


        }

        //helping methods
        private void setBankTitle()
        {
            mainGui.setView("$BERLIN BANK - your partner around the world$", true);
            setBlank();
        }

        private void setBlank()
        {
            mainGui.setView(" ", false);
        }

        private void setMainMenu()
        {
            setBankTitle();
            mainGui.setView("Choose any options:", false);
            mainGui.setView("- get cash out - Press <1>", false);
            mainGui.setView("- show account balance - Press <2> ", false);
            mainGui.setView("- print account history - Press <3> ", false);
            mainGui.setView("- exit - Press <4>", false);

        }

        
    }
}
