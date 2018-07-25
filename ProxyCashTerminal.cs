using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class ProxyCashTerminal : IBankAPI
    {
        BankBerlin secure;

        public bool checkOrder(double money)
        {
            throw new NotImplementedException();
        }

        public bool checkPinCode(int code)
        {
            if(secure == null)
            {
                secure = new BankBerlin();
            }

            return secure.checkPinCode(code);
        }

        public List<string> getAccOrders()
        {
            throw new NotImplementedException();
        }

        public string getAccountBalance()
        {
            throw new NotImplementedException();
        }

        public bool getMoney(double money)
        {
            throw new NotImplementedException();
        }

        public bool logIn(int code)
        {
            bool ok = checkPinCode(code);
            if (!ok)
            {
                throw new Exception("UnknownKey");
                
            }
            else return true;
            

        }



    }
}
