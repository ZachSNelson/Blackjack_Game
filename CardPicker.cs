using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    public class CardPicker
    {
        // randomly pick cards from the deck

        public static int NumberBetween(int minimum, int maximum)
        {
            Random rnd = new Random();
            int randomValue;

            randomValue = rnd.Next(minimum, maximum);

            // adds minvalue to randomvalue(0 to max)
            return (minimum + randomValue); 
        }

    } // end CardPicker class
}
