using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class CashTerminalOS
    {

        Main mainGui;

        public CashTerminalOS(Main mainGui)
        {
            this.mainGui = mainGui;
        }

        public void useProgram(byte processID)
        {
            if(processID == 0)
            {
                //opening program
            }
            else if(processID == 1)
            {
                //login
            }
            else if(processID == 2)
            {
                //get money
            }
            else if(processID == 3)
            {
                //get acc balance
            }
            else if(processID == 4)
            {
                //print acc history
            }
            else if(processID == 5)
            {
                //exit
            }
            //else error message
        }



    }
}
