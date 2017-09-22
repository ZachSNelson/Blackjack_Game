using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    public class Hand
    {
        public List<Card> cards { get; set; }
        public int number_of_cards { get; set; }
        public int sumCards { get; set; }
        public int score { get; set; }
        public string result { get; set; }
        public int itsAce = 0;


        //constructor creates list and places empty cards in it
        public Hand(int numcards) 
        {
            //number of cards in a hand
            number_of_cards = numcards;

            // list to hold cards
            cards = new List<Card>();

            // blank card
            Card emptycard = new Card();

            // adding blank cards to list
            for (int index = 0; index < numcards; index++)
                cards.Add(emptycard); 
        }

        // picks random card from deck and puts it in one of the blank card spots created
        public void add_card(Deck currentdeck, int number_cards)  
        {
            bool added = false;
            int pickedcard = 0;

            if (currentdeck.cards.Count <= 2)
                currentdeck.loaddeck();
 
            pickedcard = CardPicker.NumberBetween(2, currentdeck.cards.Count - 1);
            Card currentcard = currentdeck.cards.ElementAt(pickedcard);
            Card toBeReplaced = new Card();

            while (!added)
            {
                foreach (Card temp in cards)
                    if (temp.suit == "") 
                        toBeReplaced = temp;

                if (toBeReplaced != null)
                {
                    cards.Remove(toBeReplaced);
                    cards.Add(currentcard);
                    added = true;
                    currentdeck.cards.Remove(currentcard);
                }
           
            }

        }

    
        public void deal_cards(Deck currentdeck, int numcards, Hand player_hand1, Hand dealer_hand, frmBlackjack form)
        {
            numcards = cards.Count;

            for (int index = 0; index < numcards; index++)
                add_card(currentdeck, numcards);

            if (player_hand1.sumCards == 21 && dealer_hand.sumCards < 21)
            {
                result = "You won!";
                player_hand1.score += 2; // won on a deal ( 2 cards)
                form.resetForm();
            }
            else if (player_hand1.sumCards == 21 && dealer_hand.sumCards == 21)
            {
                result = "Tie, Score: " + player_hand1.sumCards;
                player_hand1.score += 1;
                dealer_hand.score += 1;
            }
            else if (player_hand1.sumCards == dealer_hand.sumCards)
            {
                result = "Player lost the hand";
                player_hand1.sumCards = 0;
            }
            else
            {
                result = "You lost!";
                dealer_hand.score += 1;
            }
                
        }

       
        public void evaluate_hand()
        {
            sumCards = 0;

            foreach (Card temp in cards)
                 if (temp.value < 10)
                    sumCards = sumCards + temp.value;
                else
                    sumCards = sumCards + 10; // assigning face cards a value of 10


            // adjust for aces
            foreach (Card temp in cards)
                if (temp.value == 1 && sumCards + 10 <= 21)
                {
                    sumCards = sumCards + 10; //Ace is scored at 11
                    itsAce = 11;
                }
                    

            if (sumCards > 21)
                result = "Sorry you bust";
            else
                result = "You have " + sumCards;
        }

    } // end class Hand
}
