using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class UserInputSystem
    {
        private  bool isAvailable = false;

        //no instances
        public UserInputSystem()
        {

        }

        public bool getStatus()
        {
            return isAvailable;
        }

        public void setStatus(bool newStatus)
        {
            isAvailable = newStatus;
        }


    }
}
