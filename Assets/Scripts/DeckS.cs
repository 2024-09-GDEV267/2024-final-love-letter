using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckS : MonoBehaviour
{
    public List<Card> cards;
    public List<string> cardNames;

    public GameObject prefabCard;
    public Transform deckAnchor;


    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.Find("_Deck") == null)
        {
            GameObject anchorGO = new GameObject("_Deck");
            deckAnchor = anchorGO.transform;
        }
        MakeDeck();
    }

    private void MakeDeck()
    {


    }

    public void MakeCards()
    {
        // 1 princess v8
        // 1 countess v7
        // 1 King   v6
        // 2 Prince v5
        // 2 Handmaid v4
        // 2 Barron v3
        // 2 Priest v2
        // 5 Guard v1
        cardNames = new List<string>();
        string[] letters = new string[] { "P", "C", "K","Prin","H","B","Priest","G"}; //add more for each card
        foreach (string s in letters)
        {
            if (s =="Prin" || s == "H" || s == "B" || s == "Priest")
            {
                cardNames.Add(s+1);
                cardNames.Add(s + 2);
            }
            if (s == "G")
            {
                // should be a loop but im lazy
                cardNames.Add(s + 1);
                cardNames.Add(s + 2);
                cardNames.Add(s + 3);
                cardNames.Add(s + 4);
                cardNames.Add(s + 5);
            }
            else
            {
                cardNames.Add(s);
            }
        }
        int TNum;
        Sprite tS = null;
        GameObject tGO = null;
        SpriteRenderer tSR = null;

        cards = new List<Card>();
        for (int i = 0; i < cardNames.Count; i++)
        {
            //cgo is a local variable

            GameObject cgo = new GameObject(prefabCard) as GameObject;
            cgo.transform.parent = deckAnchor;
            Card card = cgo.GetComponent<Card>();
        }



    }
    private void Suffle(ref List<Card> oCards)
    {
        List<Card> tCards = new List<Card>();
        int ndx;
        while (oCards.Count >0)
        {
            ndx = Random.Range(0, oCards.Count);
            tCards.Add(oCards[ndx]);   
            oCards.RemoveAt(ndx);
        }

        oCards = tCards;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
