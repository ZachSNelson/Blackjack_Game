using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    public class Dealer_turn
    {
        public string result { get; set; }


        //Determine if there is a winner or loser
        public void end_game(Hand player_hand1, Hand dealer_hand, Deck currentdeck, int numcards, frmBlackjack form, Card current_card)
        {
            //deal cards to dealer
            dealer_hand.deal_cards(currentdeck, numcards, player_hand1, dealer_hand, form);
            dealer_hand.evaluate_hand();

            //If any player has a value greater than their current value, the dealer must continue to hit. E.g. if a player has 20, the dealer must hit until they have 20 or greater
            if (player_hand1.sumCards > dealer_hand.sumCards)
            {
                //dealer must hit below 17
                while (dealer_hand.sumCards < 17)
                {
                    dealer_hand.add_card(currentdeck, 1);
                    dealer_hand.evaluate_hand();
                }
            }
            else if (dealer_hand.itsAce == 11)// if they have a ace make them hit till 18
            {
                while (dealer_hand.sumCards < 18)
                {
                    dealer_hand.add_card(currentdeck, 1);
                    dealer_hand.evaluate_hand();
                }
            }


            if (player_hand1.sumCards > 21)
            {
                result = "BUST";
                dealer_hand.score += 1;
            }
            else if (dealer_hand.sumCards > 21)
            {
                result = "Dealer BUST";
                player_hand1.score += 1;
            }
            else if (player_hand1.sumCards >= dealer_hand.sumCards && player_hand1.sumCards <= 21)
            {
                result = "You win!";
                player_hand1.score += 1;
            }
            else if (dealer_hand.sumCards >= player_hand1.sumCards && dealer_hand.sumCards <= 21)
            {
                result = "Dealer wins!";
                dealer_hand.score += 1;
            }
            else if (player_hand1.sumCards == 21)
            {
                result = "BLACKJACK";
                player_hand1.score += 1;
            }
            else
            {
                result = "Dealer BLACKJACK!";
                dealer_hand.score += 1;
            }

            // enable deal, disable hit and hold // reset title.
            form.resetForm();
        }
    }
}
