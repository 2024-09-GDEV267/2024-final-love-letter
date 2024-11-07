using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetter : MonoBehaviour
{
    Deck loveLetterDeck = new Deck();
    int numPlayers = 4;
    Player[] players;
    // Start is called before the first frame update
    void Start()
    { 
        for(int i = 0; i < numPlayers; i++) {
            players[i] = instantiate(Player);
            players[i].Draw(loveLetterDeck);
        }
        loveLetterDeck.printDeck();
    }
}
