using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [Header("Inscribed")]
    [SerializeField]
    public Card[] cards = new Card[16];
    public GameObject[] cardPrefab = new GameObject[8];
    public int deckLength = 16;
    public GameObject deckAnchor;
    
    /// <summary>
    ///  this is the equivalent of the constructor for the Deck, but must be called explicitly
    /// </summary>
    public void InstantiateDeck()
    {
        GameObject tgo;
        for(int i = 0; i < deckLength; i++)
        {
            if (i < 5)
            {
                tgo = GameObject.Instantiate(cardPrefab[0]);
                tgo.GetComponent<Card>().setValue(1);
                tgo.GetComponent<Transform>().position = deckAnchor.transform.position;
                cards[i] = tgo.GetComponent<Card>();
            }
            else if (i < 7)
            {
                tgo = GameObject.Instantiate(cardPrefab[1]);
                tgo.GetComponent<Card>().setValue(2);
                cards[i] = tgo.GetComponent<Card>();
                
            }
            else if (i < 9)
            {
                tgo = GameObject.Instantiate(cardPrefab[2]);
                tgo.GetComponent<Card>().setValue(3);
                cards[i] = tgo.GetComponent<Card>();
            }
            else if (i < 11)
            {
                tgo = GameObject.Instantiate(cardPrefab[3]);
                tgo.GetComponent<Card>().setValue(4);
                cards[i] = tgo.GetComponent<Card>();
            }
            else if (i < 13)
            {
                tgo = GameObject.Instantiate(cardPrefab[4]);
                tgo.GetComponent<Card>().setValue(5);
                cards[i] = tgo.GetComponent<Card>();
            }
            else if (i < 14)
            {
                tgo = GameObject.Instantiate(cardPrefab[5]);
                tgo.GetComponent<Card>().setValue(6);
                cards[i] = tgo.GetComponent<Card>();
            }
            else if (i < 15)
            {
                tgo = GameObject.Instantiate(cardPrefab[6]);
                tgo.GetComponent<Card>().setValue(7);
                cards[i] = tgo.GetComponent<Card>();
            }
            else
            {
                tgo = GameObject.Instantiate(cardPrefab[7]);
                tgo.GetComponent<Card>().setValue(8);
                cards[i] = tgo.GetComponent<Card>();
            }
            //print(cards[i]);
        } 
    }


    //Gets a card from the deck to give to the player
    public Card deal(Vector3 playerPos)
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
        cardDelt.GetComponent<Transform>().position = playerPos;
        //lerp myposition to playPos
        deckLength--;
        //Debug.Log("The card that was dealt to Player X was " + cardDelt.getValue());
        return cardDelt;
    }

    //Gets the length of the deck
    public int getDeckLength()
    {
        return deckLength;
    }
    public void deleteDeck()
    {
        foreach (Card C in cards)
        {
            GameObject.Destroy(C.gameObject);
        }
    }
    //Prints the deck for testing purposes
    public void printDeck()
    {
        for (int i = 0; i < deckLength; i++)
        {
            Debug.Log(cards[i].getValue());
        }
    }
}
