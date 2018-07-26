using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    interface IBankAPI
    {   
        //check pin code
        bool checkPinCode(int code);

        //withdraw money
        bool getMoney(double money);

        //check if order is ok
        bool checkOrder(double money);

        //get account balance
        String getAccountBalance();

        //get account history
        List<Transaction> getAccHistory();


       
    }
}
