using System;
using System.Collections.Generic;

namespace WAR_Game
{
    class Program
    {
        //public List<Card> TableCards = new List<Card>();

        static void Main(string[] args)
        {
            MainMenu();                     

        }

        static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     ---------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     ---MAIN MENU---");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("     ---------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please Select An Option Below:");
            Console.WriteLine("  1) Play a game of WAR!!");
            Console.WriteLine("  2) Exit the game");
            int userInput = int.Parse(Console.ReadLine());

            Deck d = new Deck();
            foreach (CardSuit cs in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue cv in Enum.GetValues(typeof(CardValue)))
                {
                    d.AddCard(new Card(cs, cv));
                }
            }

            if (userInput == 1)
            {
                GamePlay(d);
            }
            else if (userInput == 2)
            {
                return;
            }
        }

        static void GamePlay(Deck d)
        {
            Console.WriteLine("Welcome to....");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WAR");
            Console.ForegroundColor = ConsoleColor.White;
            d.ShuffleDeck(d);

            Deck Player1Deck = new Deck();
            Deck Player2Deck = new Deck();

            d.DealCards(Player1Deck, Player2Deck);

        game:
            while (Player1Deck.NumCards > 0 && Player2Deck.NumCards > 0)
            {
                Console.WriteLine("Press any key to draw...");
                char playerDraw = Console.ReadKey().KeyChar;

                Card P1Card = Player1Deck.RemoveTopCard();
                Card P2Card = Player2Deck.RemoveTopCard();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Player 1 card: {P1Card}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Player 2 card: {P2Card}");

                P1Card.CompareTo(P2Card);
                while (P1Card != P2Card)
                {
                    if (P1Card < P2Card)
                    {
                        Console.WriteLine("Player 2 has the higher card!");
                        Player2Deck.AddCard(P1Card);
                        Player2Deck.AddCard(P2Card);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Player 1 deck: {Player1Deck.NumCards}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Player 2 deck: {Player2Deck.NumCards}");
                    }
                    else if (P1Card > P2Card)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Player 1 has the higher card!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Player1Deck.AddCard(P1Card);
                        Player1Deck.AddCard(P2Card);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Player 1 deck: {Player1Deck.NumCards}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Player 2 deck: {Player2Deck.NumCards}");
                    }
                    goto game;
                }

                if (P1Card == P2Card)
                {
                    if (Player1Deck.NumCards >= 2 && Player2Deck.NumCards >= 2)
                    {
                        Console.WriteLine($"{P1Card} and {P2Card}, It's a Draw! This Means...");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("WAR!");
                        Console.ForegroundColor = ConsoleColor.White;
                    war:
                        Console.WriteLine("Press any key to go to war...");
                        char tieContinue = Console.ReadKey().KeyChar;

                        Card unkPCard = Player1Deck.RemoveTopCard();
                        Card unkCCard = Player2Deck.RemoveTopCard();
                        Card P1Card2 = Player1Deck.RemoveTopCard();
                        Card P2Card2 = Player2Deck.RemoveTopCard();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Player 1 card: {P1Card2}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Player 2 card: {P2Card2}");

                        if (P1Card2 < P2Card2)
                        {
                            Console.WriteLine($"{P2Card2} beats {P1Card2}. Player 1 lost the war!");
                            Player2Deck.AddCard(P1Card);
                            Player2Deck.AddCard(P2Card);
                            Player2Deck.AddCard(P1Card2);
                            Player2Deck.AddCard(P2Card2);
                            Player2Deck.AddCard(unkPCard);
                            Player2Deck.AddCard(unkCCard);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Player 1 deck: {Player1Deck.NumCards}");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Player 2 deck: {Player2Deck.NumCards}");
                        }

                        else if (P1Card2 > P2Card2)
                        {
                            Console.WriteLine($"{P1Card2} beats {P2Card2}. Player 2 lost the war!");
                            Player1Deck.AddCard(P1Card);
                            Player1Deck.AddCard(P2Card);
                            Player1Deck.AddCard(P1Card2);
                            Player1Deck.AddCard(P2Card2);
                            Player1Deck.AddCard(unkPCard);
                            Player1Deck.AddCard(unkCCard);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Player 1 deck: {Player1Deck.NumCards}");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Player 2 deck: {Player2Deck.NumCards}");
                        }

                        else if (P1Card2 == P2Card2 && Player1Deck.NumCards >= 2 && Player2Deck.NumCards >= 2)
                        {
                            Console.WriteLine("War again!");
                            Player1Deck.AddCard(P1Card2);
                            Player2Deck.AddCard(P2Card2);
                            Player1Deck.AddCard(unkPCard);
                            Player2Deck.AddCard(unkCCard);
                            goto war;
                        }

                        else if (P1Card2 == P2Card2 && (Player1Deck.NumCards < 2 || Player2Deck.NumCards < 2))
                        {
                            Console.WriteLine("You don't have enough cards to go to War.");
                            Player1Deck.AddCard(P1Card2);
                            Player2Deck.AddCard(P2Card2);
                            Player1Deck.AddCard(unkPCard);
                            Player2Deck.AddCard(unkCCard);
                            goto game;
                        }
                    }

                    else if (Player1Deck.NumCards < 2)
                    {
                        Console.WriteLine("Player 1 doesn't have enough cards to go to war");
                        Player1Deck.AddCard(P1Card);
                        Player2Deck.AddCard(P2Card);
                        goto game;
                    }

                    else if (Player2Deck.NumCards < 2)
                    {
                        Console.WriteLine("Player 2 doesn't have enough cards to go to war");
                        Player1Deck.AddCard(P1Card);
                        Player2Deck.AddCard(P2Card);
                        goto game;
                    }
                }
            }

            if (Player1Deck.NumCards == 0)
            {
                Console.WriteLine("Player 2 Wins! VICTORY!!");
            }

            else if (Player2Deck.NumCards == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player 1 Wins! VICTORY!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

