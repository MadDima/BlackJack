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
            //ConsoleKeyInfo cki;
            Deck MainDeck = new Deck();
            Deck DealerDeck = new Deck();
            Card card;
            Player Dima = new Player();
            Player Dealer = new Player();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Dima");
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < 2; i++)
            {
                card = MainDeck.DealCard();
                Dima.AddCard(card);
                Console.WriteLine(card.Value + " of " + card.Suit/* + " " + card.IsDealt*/);
            }
            Console.WriteLine("Points: " + Dima.GetPoints());
            if (Dima.GetPoints() == 21)
            {
                Console.WriteLine("Dima Won");
            }
            else if (Dima.GetPoints() > 21)
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
                        card = MainDeck.DealCard();
                        Dima.AddCard(card);
                        Console.WriteLine(card.Value + " of " + card.Suit/* + " " + card.IsDealt*/);
                        Console.WriteLine("Points: " + Dima.GetPoints());
                        if (Dima.GetPoints() > 21)
                        {
                            Console.WriteLine("Dima Lose");
                            endOfGame = true;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Dealer");
                        Console.ForegroundColor = ConsoleColor.Gray;
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
                        }
                        else if (Dealer.GetPoints() > 21)
                        {
                            Console.WriteLine("Dima Win");
                        }
                        else if (Dealer.GetPoints() < Dima.GetPoints())
                        {
                            Console.WriteLine("Dima Win");
                        }
                        else if (Dealer.GetPoints() > Dima.GetPoints())
                        {
                            Console.WriteLine("Dima Loose");
                        }
                        endOfGame = true;
                        break;
                }
            }

        }

    }
}