using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    interface IBankSecurityService
    {   
        //check pin code
        bool checkPinCode(int code);
       
    }
}
