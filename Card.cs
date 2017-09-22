using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    public class Card
    {
        // Card class defines all parts of a card
        public string suit { get; set; }
        public int value { get; set; }
        public int card_number { get; set; }

        public Card()
        {
            value = 0;
            suit = "";
            card_number = 0;
        }

    }// end class Card
}
