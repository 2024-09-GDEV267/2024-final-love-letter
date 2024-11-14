using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetter : MonoBehaviour
{
    public Deck loveLetterDeck = new Deck();
    public int numPlayers = 4;
    public Player[] players = new Player[4];
    public Player activePlayer;
    public int activePlayerIndex;
    public Vector3 mousePos;
    void Start()
    {
        //Deals a card to each player
        for(int i = 0; i < numPlayers; i++) {
            players[i] = new Player(i + 1);
            players[i].draw(loveLetterDeck);
        }
        //Determines an active player and draws them a card
        activePlayer = players[0];
        activePlayerIndex = 0;
        activePlayer.draw(loveLetterDeck);
        activePlayer.printHand();
    }

    void OnMouseDown()
    {
        //Chooses a card to discard (This didn't work - might need help)
        Debug.Log("X Position: " + mousePos.x);
        if (mousePos.x < 0)
        {
            activePlayer.discardLeft();
        }
        else
        {
            activePlayer.discardRight();
        }

        //Changes the active player
        if(activePlayerIndex == 3)
        {
            activePlayerIndex = 0;
        }
        else
        {
            activePlayerIndex++;
        }
        activePlayer = players[activePlayerIndex];

        //Ends the round if the deck is empty
        if (loveLetterDeck.getDeckLength() == 0)
        {
            endRound();
        }
        else
        {
            activePlayer.draw(loveLetterDeck);
            activePlayer.printHand();
        }
        
    }

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
    }
}
