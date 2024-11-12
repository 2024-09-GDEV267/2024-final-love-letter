using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player //MonoBehaviour
{
    public int score = 0;
    public Card[] hand = new Card[2];
    public int handSize = 0;

    public void draw(Deck drawingFrom)
    {
        hand[handSize] = (drawingFrom.deal());
        handSize++;
        //return drawingFrom;
    }

    public void discardLeft()
    {
        hand[0] = hand[1];
        hand[1] = null;
        handSize--;
    }

    public void discardRight()
    {
        hand[1] = null;
        handSize--;
    }

    public int getHandValue()
    {
        return hand[0].getValue();
    }

    public void increaseScore()
    {
        score++;
    }

    public void printHand()
    {
        Debug.Log("This is this player's hand:");
        foreach (Card card in hand)
        {
            Debug.Log(card.getValue());
        }
    }
}
