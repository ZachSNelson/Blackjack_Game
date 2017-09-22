using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_Game
{
    /*  
     *  Blackjack Rules and Requirements
        There is a permanent dealer which will deal all cards.
        There will be one standard deck of 52 cards used, however the number of decks should be configurable for a future release. The deck is shuffled before each game.
        The dealer will be dealt 2 cards, one face up, one face down to begin the game.
        Each player will be dealt 2 cards, face up, to begin the game.
        For this release we’re only supporting one human player vs. the dealer/computer, but code in such a way that adding a second player is a future requirement.
        The objective is to get as close to the number 21 as possible, without going over. The card values are the value of the card for 2 thru 10. Jack, Queen, and King are each worth 10. Aces can be valued at either 1 or 11. A player's hand may have multiple aces, and each may be worth either 1 or 11.
        If the player has 21 resulting from a combination of the original two cards dealt, and the dealer does not have 21 from his original two cards dealt the player wins automatically. If the dealer also has a total of 21 from two cards, then each are given a point.
        If the player and dealer end up with the same value, the player loses the hand.
        The player may request additional cards by asking for a “hit”. At which point the dealer will provide a card, face up. The player may “hit” as many times as he likes until he “busts” with a total over 21.
        The player signals they are done taking cards by calling “hold”
        The dealer / computer takes their turn after all of the players have finished with their turns. When the dealer holds, their hidden card is then shown.
        Scoring should happen as follows:
        A player win over the dealer is worth 1 point
        A dealer win over a player is worth 1 point
        A player or dealer win with two cards that total 21 is worth 2 points
        A player and dealer each with two cards that total 21 are both awarded 1 point
        The dealer will be controlled by the following rules:
        The dealer must hit if his total is below 17
        If the dealer has any high aces (counted as 11) as part of his total, he must hit while his count is below 18.
        If any player has a value greater than their current value, the dealer must continue to hit. E.g. if a player has 20, the dealer must hit until they have 20 or greater.
     */

    public partial class frmBlackjack : Form
    {
        public Deck currentdeck { get; set; }
        public Hand player_hand1 { get; set; }
        public Hand player_hand2 { get; set; } //** This is for player two. I am not using it for this release.
        public Hand dealer_hand { get; set; }
        public Dealer_turn dealer_turn { get; set; }
        public Card current_card { get; set; }
        public frmBlackjack form { get; set; }
        public int numcards { get; set; }


        public frmBlackjack()
        {
            InitializeComponent();
        }


        //BUTTONS
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            Score(dealer_hand, player_hand1); // gets score
            dealer_turn.end_game(player_hand1, dealer_hand, currentdeck, numcards, form, current_card);

            lblTitle.Text = dealer_turn.result;
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            Score(dealer_hand, player_hand1); // gets score
            player_hand1.add_card(currentdeck, 1);
            display_hand(player_hand1, dealer_hand);
            player_hand1.evaluate_hand();
   
            lblTitle.Text = player_hand1.result;
           
            if (player_hand1.sumCards >= 21)
                dealer_turn.end_game(player_hand1, dealer_hand, currentdeck, numcards, form, current_card);

            lblTitle.Text = dealer_turn.result;
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            Score(dealer_hand, player_hand1); // gets score
            player_hand1.deal_cards(currentdeck, numcards, player_hand1, dealer_hand, form);
            display_hand(player_hand1, dealer_hand);
            lblTitle.Text = player_hand1.result;

            //hide deal button, show hit and hold
            btnDeal.Visible = false;
            btnHold.Visible = true;
            btnHit.Visible = true;
        }
        //END of buttons


        public void Score(Hand dealer, Hand Player1)
        {
            lblCpuScore.Text = dealer.score.ToString();
            lblPlayer1Score.Text = Player1.score.ToString();
        }

        public void resetForm()
        {
            // deal button is visible
            btnDeal.Visible = true;
            // hit button hidden
            btnHit.Visible = false;
            //hold  button hidden
            btnHold.Visible = false;

            //Reset title
            lblTitle.Text = "Blackjack";
        }


        // display the dealer and player hand
        public void display_hand(Hand playerhand1, Hand dealerhand)
        {
            /* Set card values to card pictures
             * Display the player and dealers card
            */
        }
    }
}
