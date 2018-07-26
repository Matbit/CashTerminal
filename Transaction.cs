using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class Transaction
    {
        private String date;
        private double amount;
        private String referenceLine;

        public Transaction(String date, double amount, String referenceLine)
        {
            this.date = date;
            this.amount = amount;
            this.referenceLine = referenceLine;
        }

        public String getDate()
        {
            return date;
        }
        public double getAmount()
        {
            return amount;
        }
        public String getReferenceLine()
        {
            return referenceLine;
        }
    }
}
