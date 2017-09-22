using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    public class Deck
    {
        //Deck class defines a list of cards
        public List<Card> cards { get; set; }

        //The deck
        public Deck()
        {
            cards = new List<Card>();
            loaddeck();
        }

        public void loaddeck()
        {
            cards.Clear();
            int cardnum = 1;

            // for loop for 4 suits
            for (int index = 1; index < 5; index++)
            {
                // for loop for 13 cards to each suit (total 52 cards), (4 suits)
                for (int card_count = 1; card_count < 14; card_count++)
                {
                    //create a new card
                    Card currentcard = new Card();

                    //assign suit
                    currentcard.card_number = cardnum;

                    switch (index)
                    {
                        case 1:
                            currentcard.suit = "spades";
                            break;
                        case 2:
                            currentcard.suit = "clubs";
                            break;
                        case 3:
                            currentcard.suit = "hearts";
                            break;
                        case 4:
                            currentcard.suit = "diamonds";
                            break;
                    }

                    // assign value
                    currentcard.value = card_count;

                    // add card to deck
                    cards.Add(currentcard);

                    //next card
                    cardnum++;
                }
            }
        }

    } // end deck class
}
