//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        private Card[] deck;
        public Deck()
        {
            deck = new Card[36];
            Card card;
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    card.Suit = (Suit)i;
                    card.Value = (Value)j;
                    card.IsDealt = false;
                    deck[index] = card;
                    index++;
                }
            }
        }
        public Card DealCard()
        {
            Random generator = new Random();
            do
            {
                int index = generator.Next(35);
                if (!deck[index].IsDealt)
                {
                    deck[index].IsDealt = true;
                    return deck[index];
                }
            }
            while (true);
        }
    }
}