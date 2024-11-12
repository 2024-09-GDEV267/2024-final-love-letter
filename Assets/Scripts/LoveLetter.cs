using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetter : MonoBehaviour
{
    [Header("Inscribed")]
    public Deck loveLetterDeck = new Deck();
    public int numPlayers = 4;
    public GameObject player;
    public Player[] players;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject deck = Instantiate<GameObject>(loveLetterDeck);
        for(int i = 0; i < numPlayers; i++) {
            players[i] = new Player();
            players[i].Draw(loveLetterDeck);
        }
        //deck.printDeck();
    }
}
