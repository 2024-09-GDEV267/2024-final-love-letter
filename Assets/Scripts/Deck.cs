using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck // MonoBehaviour
{
     public Card[] cards = new Card[16];
     public int deckLength = 16;
    
    public Deck()
    {
        for(int i = 0; i < deckLength; i++)
        {
            if (i < 5)
            {
                cards[i] = new Card(1);
            }
            else if (i < 7)
            {
                cards[i] = new Card(2);
            }
            else if (i < 9)
            {
                cards[i] = new Card(3);
            }
            else if (i < 11)
            {
                cards[i] = new Card(4);
            }
            else if (i < 13)
            {
                cards[i] = new Card(5);
            }
            else if (i < 14)
            {
                cards[i] = new Card(6);
            }
            else if (i < 15)
            {
                cards[i] = new Card(7);
            }
            else
            {
                cards[i] = new Card(8);
            }
            //print(cards[i]);
        } 
    }


    //Gets a card from the deck to give to the player
    public Card deal()
    {
        int cardNum = (int)(Random.value * deckLength);
        Card cardDelt = cards[cardNum];
        for(int i = cardNum; i < deckLength; i++)
        {
            if ( i != deckLength - 1)
            {
                cards[i] = cards[i + 1];
            }
        }
        deckLength--;
        //Debug.Log("The card that was dealt to Player X was " + cardDelt.getValue());
        return cardDelt;
    }

    //Gets the length of the deck
    public int getDeckLength()
    {
        return deckLength;
    }

    //Prints the deck (For testing purposes
    public void printDeck()
    {
        for (int i = 0; i < deckLength; i++)
        {
            Debug.Log(cards[i].getValue());
        }
    }
}
