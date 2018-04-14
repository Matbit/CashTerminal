using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class ProxyCashTerminal : IBankSecurityService
    {
        BankSecurity secure;


        public bool checkPinCode(int code)
        {
            if(secure == null)
            {
                secure = new BankSecurity();
            }

            return secure.checkPinCode(code);
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
