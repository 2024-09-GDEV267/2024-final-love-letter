using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetter : MonoBehaviour
{
    public Deck loveLetterDeck = new Deck();
    //public Deck loveLetterDeck = new Deck();
    public int numPlayers = 4;
   // public GameObject player;
    public Player[] players = new Player[4];
    public Player activePlayer;
    public int activePlayerIndex;
    public Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject deck = Instantiate<GameObject>(loveLetterDeck);
        for(int i = 0; i < numPlayers; i++) {
            players[i] = new Player();
            players[i].draw(loveLetterDeck);
        }
        //Debug.Log("This is the Deck:");
        //loveLetterDeck.printDeck();

        activePlayer = players[0];
        activePlayerIndex = 0;
        activePlayer.draw(loveLetterDeck);
        activePlayer.printHand();
    }

    void OnMouseDown()
    {
        if(mousePos.x < 0)
        {
            activePlayer.discardLeft();
        }
        else
        {
            activePlayer.discardRight();
        }

        if(activePlayerIndex == 3)
        {
            activePlayerIndex = 0;
        }
        else
        {
            activePlayerIndex++;
        }
        activePlayer = players[activePlayerIndex];

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
