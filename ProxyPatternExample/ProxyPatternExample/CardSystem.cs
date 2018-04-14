using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternExample
{
    class CardSystem
    {
        private static Card cardIn = Card.NO_Card;

        //no instances
        private CardSystem()
        {

        }


        public enum Card
        {
            NO_Card, OK
        }

        public static Card getCardStatus()
        {
            return cardIn;
        }

        public static void setCardStatus(bool isThere)
        {
            if (isThere)
                cardIn = Card.OK;
            else cardIn = Card.NO_Card;
        }

    }
}
