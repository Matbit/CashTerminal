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
            throw new NotImplementedException();
        }

        public bool checkPinCode(int code)
        {
            if(bankBerlin == null)
            {
                bankBerlin = new BankBerlin();
            }

            return bankBerlin.checkPinCode(code);
        }

       
        public string getAccountBalance()
        {
            throw new NotImplementedException();
        }

        public bool getMoney(double money)
        {
            throw new NotImplementedException();
        }

        public List<string> getAccOrders()
        {
            throw new NotImplementedException();
        }





    }
}
