using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class BankSecurity : IBankSecurityService
    {
        private  List<int> pinCodeList = new List<int>();

        public BankSecurity()
        {
            pinCodeList.Add(3674);

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
    }
}
