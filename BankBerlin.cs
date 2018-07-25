using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class BankBerlin : IBankAPI
    {
        private  List<int> pinCodeList = new List<int>();

        public BankBerlin()
        {
            pinCodeList.Add(3749);

            for (int i = 0; i <= 25; i++)
            {
                pinCodeList.Add(getRandomPin());
            }
            
        }

        public bool checkPinCode(int code)
        {
            try
            {
                return pinCodeList.Contains(code);
            }
            catch
            {
                return false;
            }
        }

       

        private static int getRandomPin()
        {
            Random r = new Random();
            return r.Next(1000, 9999);
        }

        public bool getMoney(double money)
        {
            return true;
        }

        public String checkOrder(double money)
        {
            
        }

        public string getAccountBalance()
        {
           return BankSafe.getAccountBalance();
        }

        public List<string> getAccOrders()
        {
            throw new NotImplementedException();
        }
    }
}
