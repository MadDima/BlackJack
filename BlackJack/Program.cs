using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{

    public enum Suit { Clubs, Diamonds, Spades, Hearts }
    public enum Value { Six = 5, Seven = 6, Eight = 7, Nine = 8, Ten = 9, Jack = 10, Queen = 10, King = 10, Aces = 11 }

    struct Card
    {
        public Suit Suit;
        public Value Value;
        public bool IsDealt;
    }

    class Player
    {
        public readonly Card[] Pcards = new Card[36];
        private int CurrentIndex = 0;
        public int GetPoints()
        {
            int summ = 0;
            for (int i = 0; i < Pcards.Length; i++)
            {
                summ += (int)Pcards[i].Value;
            }
            return summ;
        }
        public void AddCard(Card card)
        {
            Pcards[CurrentIndex] = card;
            CurrentIndex++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleKeyInfo cki;
            Deck MainDeck = new Deck();
            Deck DealerDeck = new Deck();
            Card card;
            Player Dima = new Player();
            Player Dealer = new Player();
            Console.WriteLine("Cards: Dima");
            for (int i = 0; i < 2; i++)
            {
                card = MainDeck.DealCard();
                Dima.AddCard(card);
                Console.WriteLine(card.Value + " of " + card.Suit/* + " " + card.IsDealt*/);
            }
            Console.WriteLine("Points: " + Dima.GetPoints());
            if (Dima.GetPoints() == 21)
            {
                Console.WriteLine("Dima Win");
            }
            else if (Dima.GetPoints() > 21)
            {
                Console.WriteLine("Dima Loose");
            }

            Console.WriteLine("Press 'Enter' to take Card");

            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                for (int i = 0; i < 1; i++)
                {
                    card = MainDeck.DealCard();
                    Dima.AddCard(card);
                    Console.WriteLine(card.Value + " of " + card.Suit/* + " " + card.IsDealt*/);
                }
                Console.WriteLine("Points: " + Dima.GetPoints());
                if (Dima.GetPoints() > 21)
                {
                    Console.WriteLine("Dima Loose");
                    break;
                }

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Dealer");
                    while (Dealer.GetPoints() < 17)
                    {
                        card = DealerDeck.DealCard();
                        Dealer.AddCard(card);
                        Console.WriteLine(card.Value + " of " + card.Suit/* + " " + card.IsDealt*/);
                    }
                    Console.WriteLine(Dealer.GetPoints());
                    if (Dealer.GetPoints() == 21 & Dima.GetPoints() == 21)
                    {
                        Console.WriteLine("1:1 Draw");
                        break;
                    }
                    else if (Dealer.GetPoints() > 21)
                    {
                        Console.WriteLine("Dima Win");
                        break;
                    }
                    else if (Dealer.GetPoints() < Dima.GetPoints())
                    {
                        Console.WriteLine("Dima Win");
                        break;
                    }
                    else if (Dealer.GetPoints() > Dima.GetPoints())
                    {
                        Console.WriteLine("Dima Loose");
                        break;
                    }
                }
            }
        }

    }
}
