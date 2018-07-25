using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class BankSafe
    {
        public const int ACCID = 23590881;
        private static Double accountBalance;
        
        public BankSafe()
        {
           
            accountBalance = 1240.87;
        }

        


        private static string formatInEuro(double d)
        {
            string euroValue = d.ToString();
            euroValue = string.Format("{0:0.00} €", d);
            return euroValue;
        }

        public static bool checkPinCode(int code)
        {
            throw new NotImplementedException();
        }

        public static bool getMoney(double money)
        {
            if (checkOrder(money).Equals("ok"))
            {
                accountBalance -= money;
                return true;
            }
            else return false;
        }

        public static string checkOrder(double money)
        {
            if(accountBalance > money)
            {
                return "not enough money";
            }
            else if(accountBalance <= money)
            {
                return "ok";
            }

            return "error..";
        }

        public static string getAccountBalance()
        {
            return formatInEuro(accountBalance);
        }

        public List<string> getAccOrders()
        {
            throw new NotImplementedException();
        }
    }
}
