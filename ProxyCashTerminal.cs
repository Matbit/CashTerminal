using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class ProxyCashTerminal : IBankAPI
    {
        BankBerlin bankBerlin;


        //constructor
        public ProxyCashTerminal()
        {
            
        }





        public bool checkOrder(double money)
        {
            initProxy();
           return bankBerlin.checkOrder(money);
        }

        public bool checkPinCode(int code)
        {
            initProxy();
            return bankBerlin.checkPinCode(code);
        }

        public List<Transaction> getAccHistory()
        {
            throw new NotImplementedException();
        }

        public string getAccountBalance()
        {
            initProxy();
            return bankBerlin.getAccountBalance();
        }

        public bool getMoney(double money)
        {
            initProxy();
            return bankBerlin.getMoney(money);
        }

       
        private void initProxy()
        {
            if(bankBerlin == null)
            {
                bankBerlin = new BankBerlin();
            }
        }





    }
}
