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

        private List<Transaction> accHistory = new List<Transaction>();
        private  List<int> pinCodeList = new List<int>();


        //constructor
        public BankBerlin()
        {
            pinCodeList.Add(3749);
            
            for (int i = 0; i <= 2; i++)
            {
                pinCodeList.Add(getRandomPin());
            }
            setHistoryList();
            
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
                DateTime today = DateTime.Now;
                int day = today.Day;
                string dayS = string.Format("{0:00}", day);
                int month = today.Month;
                string monthS = string.Format("{0:00}", month);


                int year = today.Year;
                String output = dayS + "." + monthS + "." + year.ToString();
                bankAccValue -= money;
                money = money * (-1);
                accHistory.Add(new Transaction(output, money,"CT-HH, get hardcash"));
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

        //get acc history
        public List<Transaction> getAccHistory()
        {
            return accHistory;
        }
        
        //helping methods
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

        private void setHistoryList()
        {
            accHistory.Add(new Transaction("18.06.2018", -20.05,"Ebay"));
            accHistory.Add(new Transaction("30.06.2018", +2000,"Salary 06-2018"));
        }

    }
}
