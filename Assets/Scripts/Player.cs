using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player //MonoBehaviour
{
    public int score = 0;
    public Card[] hand = new Card[2];
    public int handSize = 0;
    public int playerNum;
    public bool alive = true;
    public GameObject handAnchor;
    private Vector3 rightShift = new Vector3(5, 0, 0);
    public bool immune = false;

    public Player(int number)
    {
        playerNum = number;
    }
    //Drawing from the deck
    public void draw(Deck drawingFrom)
    {
        if (handSize == 0)
        {
            hand[handSize] = (drawingFrom.deal(handAnchor.transform.position));
        }
        else
        {
            hand[handSize] = (drawingFrom.deal(handAnchor.transform.position + rightShift));
        }
        Debug.Log("The card that was dealt to Player " + playerNum + " was " + hand[handSize].getValue());
        handSize++;
    }

    //Discarding the leftmost card in your hand
    public Card discardLeft()
    {
        Debug.Log("The card that was discarded was " + hand[0].getValue());
        Card tempCard = hand[0];
        if (hand[1] != null)
        {
            hand[0] = hand[1];
            hand[1] = null;
        }
        else
        {
            hand[0] = null;
        }
        if(tempCard.getValue() == 8)
        {
            this.killPlayer();
        }
        handSize--;
        hand[0].GetComponent<Transform>().position = handAnchor.transform.position;
        return tempCard;

    }
    //Discarding the rightmost card in your hand
    public Card discardRight()
    {
        Debug.Log("The card that was discarded was " + hand[1].getValue());
        Card tempCard = hand[1];
        hand[1] = null;
        handSize--;
        return tempCard;
    }
    public Card getLeftCard()
    {
        return hand[0];
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

    public void killPlayer()
    {
        this.discardLeft();
        alive = false;
    }

    public void toggleProtection()
    {
        if (immune)
        {
            immune = false;
        }
        else
        {
            immune = true;
        }
    }

    public Card getCard()
    {
        return hand[0];
    }

    public void setCard(Card passedCard)
    {
        hand[0] = passedCard;
    }

    public bool isProtected()
    {
        return immune;
    }

    public bool isAlive()
    {
        return alive;
    }
}
