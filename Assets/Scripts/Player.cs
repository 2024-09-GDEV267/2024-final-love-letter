using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player //MonoBehaviour
{
    public int score = 0;
    public Card[] hand = new Card[2];
    public int handSize = 0;
    public int playerNum;

    public Player(int number)
    {
        playerNum = number;
    }
    //Drawing from the deck
    public void draw(Deck drawingFrom)
    {
        hand[handSize] = (drawingFrom.deal());
        Debug.Log("The card that was dealt to Player " + playerNum + " was " + hand[handSize].getValue());
        handSize++;
    }

    //Discarding the leftmost card in your hand
    public void discardLeft()
    {
        Debug.Log("The card that was discarded was " + hand[0].getValue());
        hand[0] = hand[1];
        hand[1] = null;
        handSize--;
    }

    //Discarding the rightmost card in your hand
    public void discardRight()
    {
        Debug.Log("The card that was discarded was " + hand[1].getValue());
        hand[1] = null;
        handSize--;
    }

    //Returns the value of the card in the hand
    public int getHandValue()
    {
        return hand[0].getValue();
    }

    //Increases this player's score
    public void increaseScore()
    {
        score++;
    }

    //Prints that hand (for testing purposes)
    public void printHand()
    {
        Debug.Log("This is Player " + playerNum + "'s hand:");
        foreach (Card card in hand)
        {
            Debug.Log(card.getValue());
        }
    }

    public int getPlayerNum()
    {
        return playerNum;
    }
}
