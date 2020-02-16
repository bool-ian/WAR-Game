using System;
using System.Collections.Generic;
using System.Text;

namespace WAR_Game
{
    class Deck
    {
        List<Card> Cards { get; set; }

        public int NumCards { get => Cards.Count; }
        public Deck()
        {
            Cards = new List<Card>();
        }

        public Deck(List<Card> input)
        {
            Cards = input; 
        }

        public void AddCard(Card newCard)
        {
            Cards.Add(newCard);
        }

        public Card RemoveTopCard()
        {
            Card cardToRemove = Cards[0];
            Cards.RemoveAt(0);
            return cardToRemove;
        }

        public void PrintDeck()
        {
            foreach(Card c in Cards)
            {
                System.Console.WriteLine(c);
            }
        }

        public void SortDeck()
        {
            Cards.Sort();
        }

        public void ShuffleDeck(Deck d)
        {
            for (int i = 1; i <= 100000; i++)
            {
                Random r = new Random();
                int rInt = r.Next(Cards.Count);
                Card randomCard = Cards[rInt];
                Cards.RemoveAt(rInt);
                d.AddCard(randomCard);
            }
        }

        public void DealCards(Deck Player1Deck, Deck Player2Deck)
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Card newCard = Cards[i];
                    Player1Deck.AddCard(newCard);
                }
                else
                {
                    Card newCard = Cards[i];
                    Player2Deck.AddCard(newCard);
                }
            }

        }

    }
}
