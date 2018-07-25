using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class BankBerlin : IBankAPI
    {

        private double bankAccValue = 3590;
        public double BankAccValue { get; set; }

        private  List<int> pinCodeList = new List<int>();


        //constructor
        public BankBerlin()
        {
            pinCodeList.Add(3749);
            
            for (int i = 0; i <= 2; i++)
            {
                pinCodeList.Add(getRandomPin());
            }
            
        }

        //login
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

       
        //get money 
        public bool getMoney(double money)
        {
            if (checkOrder(money))
            {
                bankAccValue -= money;
                return true;
            }
            else return false;
        }

        //check acc balance
        public bool checkOrder(double money)
        {
            if (money > bankAccValue)
            {
                return false;
            }
            else if(money > 1500)
            {
                return false;
            }
            else return true;
        }

        //get acc balance (formated in euro)
        public string getAccountBalance()
        {
            return formatInEuro(bankAccValue);
        }

        public List<string> getAccOrders()
        {
            throw new NotImplementedException();
        }


        private static int getRandomPin()
        {
            Random r = new Random();
            return r.Next(1000, 9999);
        }


        private static string formatInEuro(double d)
        {
            string euroValue = d.ToString();
            euroValue = string.Format("{0:0.00} €", d);
            return euroValue;
        }

     }
}
