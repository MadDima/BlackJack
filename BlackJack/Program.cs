using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{

    public enum Suit { Clubs, Diamonds, Spades, Hearts }
    public enum Value { Two = 2, Three = 3, Four = 4, Five = 5, Six = 5, Seven = 6, Eight = 7, Nine = 8, Ten = 9, Jack = 10, Queen = 10, King = 10, Ace = 11 }

    struct Card
    {
        public Suit Suit;
        public Value Value;
        public bool IsDealt;
    }

    class Player
    {
        public readonly Card[] Pcards = new Card[52];
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
            Deck mainDeck = new Deck();
            Deck dealerDeck = new Deck();
            Card card;
            Player dima = new Player();
            Player dealer = new Player();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Dima");
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < 2; i++)
            {
                card = mainDeck.DealCard();
                dima.AddCard(card);
                Console.WriteLine(card.Value + " of " + card.Suit);
            }
            Console.WriteLine("Points: " + dima.GetPoints());
            if (dima.GetPoints() == 21)
            {
                Console.WriteLine("Dima Won");
            }
            else if (dima.GetPoints() > 21)
            {
                Console.WriteLine("Dima Lost");
            }

            Console.WriteLine("Press 'Enter' to take Card");

            bool endOfGame = false;

            while (!endOfGame)
            {
                ConsoleKey keyInfo = Console.ReadKey(true).Key;
                switch (keyInfo)
                {
                    case ConsoleKey.Enter:
                        card = mainDeck.DealCard();
                        dima.AddCard(card);
                        Console.WriteLine(card.Value + " of " + card.Suit);
                        Console.WriteLine("Points: " + dima.GetPoints());
                        if (dima.GetPoints() > 21)
                        {
                            Console.WriteLine("Dima Lose");
                            endOfGame = true;
                        }
                        if (dima.GetPoints() == 21)
                        {
                            Console.WriteLine("Dima Won");
                            endOfGame = true;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Dealer");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        while (dealer.GetPoints() < 17)
                        {
                            card = dealerDeck.DealCard();
                            dealer.AddCard(card);
                            Console.WriteLine(card.Value + " of " + card.Suit);
                        }
                        Console.WriteLine(dealer.GetPoints());
                        if (dealer.GetPoints() == dima.GetPoints())
                        {
                            Console.WriteLine("1:1 Draw");
                        }
                        else if (dealer.GetPoints() > 21)
                        {
                            Console.WriteLine("Dima Won");
                        }
                        else if (dealer.GetPoints() < dima.GetPoints())
                        {
                            Console.WriteLine("Dima Won");
                        }
                        else if (dealer.GetPoints() > dima.GetPoints())
                        {
                            Console.WriteLine("Dima Lose");
                        }
                        endOfGame = true;
                        break;
                }
            }

        }

    }
}