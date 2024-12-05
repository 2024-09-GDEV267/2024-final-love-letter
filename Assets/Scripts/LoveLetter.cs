using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class LoveLetter : MonoBehaviour
{
    public static LoveLetter S;
    [SerializeField]
    public Deck loveLetterDeck;// = new Deck(); Need to instantiate the deck script in Start or Awake, not the constructor
    public int numPlayers = 4;
    public Player[] players = new Player[4];
    public Player activePlayer;
    public Card[] discardPile = new Card[16]; // should be a list

    // create an ancorpoint for discardpile (vector3)
    public int activePlayerIndex;
    public Vector3 mousePos;
    void Start()
    {
        //Find the deck object as a peer component on this object, call method to instantiate it
        loveLetterDeck = GetComponent<Deck>();
        loveLetterDeck.InstantiateDeck();

        for (int i = 0; i < numPlayers; i++)
        {
            players[i] = new Player(i + 1);
        }
        startRound();
    }

    public void startRound()
    {
        //Deals a card to each player
        for (int i = 0; i < numPlayers; i++)
        {
            players[i].draw(loveLetterDeck);
        }

        //Determines an active player and draws them a card
        activePlayer = players[0];
        activePlayerIndex = 0;
        activePlayer.draw(loveLetterDeck);
        activePlayer.printHand();
        activePlayer.Active();
    }
    public void playCard(Card clickedCard)
    {
        if (clickedCard == activePlayer.getLeftCard())
        {
            Card dCard = activePlayer.discardLeft();
            effects(dCard.getValue());

        }
        else 
        {
            Card dCard = activePlayer.discardRight();
            effects(dCard.getValue());
        }
        activePlayer.deActive();

        //Changes the active player
        if (activePlayerIndex == 3)
        {
            activePlayerIndex = 0;
            //do math to move camera
        }
        else
        {
            activePlayerIndex++;
            //do math to move camera
        }
        activePlayer = players[activePlayerIndex];
        //check game end
        if (loveLetterDeck.getDeckLength() == 0)
        {
            endRound();
        }
        else
        {
            activePlayer.draw(loveLetterDeck);
            activePlayer.printHand();
            activePlayer.Active();
        }
    }
   // void OnMouseDown()
   // {
   //     Chooses a card to discard (This didn't work - might need help)-
   //     if (mousePos.x < 0)
   //     {
   //         Card dCard = activePlayer.discardLeft();
   //         effects(dCard.getValue());
   //         //move dcard to discardpile
   //         //activePlayer.discardLeft(true);
   //     }
   //     else
   //     {
   //         Card dCard = activePlayer.discardRight();
   //         effects(dCard.getValue());
   //         //move dcard to discardpile
   //         //activePlayer.discardRight();
   //     }
   //
   //     Changes the active player
   //     if(activePlayerIndex == 3)
   //     {
   //         activePlayerIndex = 0;
   //         //do math to move camera
   //     }
   //     else
   //     {
   //         activePlayerIndex++;
   //         //do math to move camera
   //     }
   //     activePlayer = players[activePlayerIndex];
   // 
   //     Ends the round if the deck is empty
   //     if (loveLetterDeck.getDeckLength() == 0)
   //     {
   //         endRound();
   //     }
   //     else
   //     {
   //         activePlayer.draw(loveLetterDeck);
   //         activePlayer.printHand();
   //     }
   //     
   // }

    //Ends the round and increses the score of the winning player
    void endRound()
    {
        int currentMax = 0;
        int leadingIndex = 0;
        for (int i = 0; i < numPlayers; i++)
        {
            if (players[i].getHandValue() > currentMax)
            {
                currentMax = players[i].getHandValue();
                leadingIndex = i;
            }
        }
        players[leadingIndex].increaseScore();
        //Debug.Log("Player " + players[leadingIndex].getPlayerNum());
        if (players[leadingIndex].getScore() > 4)
        {
            for (int i = 0; i < numPlayers; i++)
            {
                if (!players[i].isAlive())
                {
                    players[i].revivePlayer();
                }
                players[i].discardLeft();
            }
            startRound();
        }
        else
        {
            Debug.Log("Player " + players[leadingIndex].getPlayerNum() + " has won the game!");
        }
        
    }
    void effects(int value)
    {
        int chosenPlayer;
        Player targetPlayer;
        switch (value)
        {
            case 1:
                chosenPlayer = Random.Range(0, numPlayers - 1);
                int chosenCard = Random.Range(1, 8);
                targetPlayer = players[chosenPlayer];

                if (targetPlayer.getHandValue() == chosenCard)
                {
                    targetPlayer.killPlayer();
                }
                break;

            case 2:
                //Let's come back to this one
                break;

            case 3:
                chosenPlayer = Random.Range(0, numPlayers - 1);
                targetPlayer = players[chosenPlayer];

                if (activePlayer.getHandValue() > targetPlayer.getHandValue())
                {
                    targetPlayer.killPlayer();
                }
                else if (activePlayer.getHandValue() < targetPlayer.getHandValue())
                {
                    activePlayer.killPlayer();
                }
                break;

            case 4:
                activePlayer.toggleProtection();
                break;

            case 5:
                chosenPlayer = Random.Range(0, numPlayers - 1);
                targetPlayer = players[chosenPlayer];

                targetPlayer.discardLeft();
                if (targetPlayer.isAlive())
                {
                    targetPlayer.draw(loveLetterDeck);
                }
                break;

            case 6:
                chosenPlayer = Random.Range(0, numPlayers - 1);
                targetPlayer = players[chosenPlayer];

                Card swappedCard = targetPlayer.getCard();
                targetPlayer.setCard(activePlayer.getCard());
                activePlayer.setCard(swappedCard);
                break;
        }
    }

}
