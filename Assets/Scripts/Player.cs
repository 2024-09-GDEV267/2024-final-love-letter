using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour 
{
    public int score = 0;
    public Card[] hand = new Card[2];
    public int handSize = 0;
    public int playerNum;
    public bool alive = true;
    public GameObject handAnchor;
    private Vector3 rightShift = new Vector3(5, 0, 0);
    public Quaternion playerRotation = Quaternion.Euler(0, 0, 0);
    public bool immune = false;
    public GameObject discardAnchor;
    public int discardCount = 0;

    public void Awake ()
    {
        switch (playerNum)
        {
            case 0:
                break;
            case 1:
                rightShift = new Vector3(0, -5, 0);
                playerRotation = Quaternion.Euler(0, 0, -90);
                break;
            case 2:
                rightShift = new Vector3(5, 0, 0);
                playerRotation = Quaternion.Euler(0, 0, 180);
                break;
            case 3:
                rightShift = new Vector3(0, -5, 0);
                playerRotation = Quaternion.Euler(0, 0, 90);
                break;
        }
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
        hand[handSize].transform.rotation = playerRotation;
        
        Debug.Log("The card that was dealt to Player " + playerNum + " was " + hand[handSize].getValue());
        handSize++;
    }

    //Discarding the leftmost card in your hand
    public Card discardLeft()
    {
        Debug.Log("The card that was discarded was " + hand[0].getValue());
        Card tempCard = hand[0];
        hand[0].discarded = true;
        switch(playerNum)
        {
            case 0:
                hand[0].GetComponent<Transform>().position = discardAnchor.transform.position + new Vector3(2 * discardCount, 0, 0);
                break;
            case 1:
                hand[0].GetComponent<Transform>().position = discardAnchor.transform.position + new Vector3(0,-2* discardCount, 0);
                break;
            case 2:
                hand[0].GetComponent<Transform>().position = discardAnchor.transform.position + new Vector3(-2 * discardCount, 0, 0);
                break;
            case 3:
                hand[0].GetComponent<Transform>().position = discardAnchor.transform.position + new Vector3(0, -2* discardCount, 0);
                break;
        }
        if (hand[1] != null)
        {
            hand[1].GetComponent<Transform>().position = handAnchor.transform.position;
            hand[0] = hand[1];
            hand[1] = null;
        }
        else
        {
            hand[0] = null;
        }
        if(tempCard.getValue() == 8)
        {
            LoveLetter.S.deadCount++;
            discardCount++;
            killPlayer();
        }
        discardCount++;
        handSize--;
        return tempCard;
    }
    //Discarding the rightmost card in your hand
    public Card discardRight()
    {
        Debug.Log("The card that was discarded was " + hand[1].getValue());
        Card tempCard = hand[1];
        switch (playerNum)
        {
            case 0:
                hand[1].GetComponent<Transform>().position = discardAnchor.transform.position + new Vector3(2 * discardCount, 0, 0);
                break;
            case 1:
                hand[1].GetComponent<Transform>().position = discardAnchor.transform.position + new Vector3(0, -2 * discardCount, 0);
                break;
            case 2:
                hand[1].GetComponent<Transform>().position = discardAnchor.transform.position + new Vector3(-2 * discardCount, 0, 0);
                break;
            case 3:
                hand[1].GetComponent<Transform>().position = discardAnchor.transform.position + new Vector3(0, -2 * discardCount, 0);
                break;
        }
        hand[1] = null;
        if (tempCard.getValue() == 8)
        {
            LoveLetter.S.deadCount++;
            discardCount++;
            killPlayer();
        }
        discardCount++;
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

    //Gets the player's score
    public int getScore()
    {
        return score;
    }

    //Increases this player's score
    public void increaseScore()
    {
        Debug.Log("scoreup");
        score++;
    }

    //Prints that hand (for testing purposes)
    public void printHand()
    {
        //Debug.Log("This is Player " + playerNum + "'s hand:");
        foreach (Card card in hand)
        {
            Debug.Log(card.getValue());
        }
    }
    public void Active()
    {
        hand[0].active = true;
        hand[1].active= true;
    }
    public void deActive()
    {
        hand[0].active = false;
    }

    public int getPlayerNum()
    {
        return playerNum;
    }

    public void killPlayer()
    {
        alive = false;
        if (hand[0] != null)
        {
            hand[0].discarded = true;
        }
        if(hand[1] != null)
        {
            hand[1].discarded = true;
        }
        if (hand[0] != null)
        {
            this.discardLeft();
        }
        
    }

    public void revivePlayer()
    {
        alive = true;
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
        hand[0].transform.position = handAnchor.transform.position;
        hand[0].transform.rotation = playerRotation;

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
