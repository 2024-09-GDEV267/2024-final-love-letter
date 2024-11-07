using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeckS : MonoBehaviour
{
    public List<Card> cards;
    public List<int> cardValues;

    public GameObject Card;
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
        Suffle(ref cards);
    }

    private void MakeDeck()
    {
        // 1 princess v8
        // 1 countess v7
        // 1 King   v6
        // 2 Prince v5
        // 2 Handmaid v4
        // 2 Barron v3
        // 2 Priest v2
        // 5 Guard v1

        int[] cardValues = new int[] { 1, 1, 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 7, 8 }; //add more for each card
        foreach (int v in cardValues)
        {
            if (v == 1)
            {
                //instanices a new card thing = new game object
                GameObject cgo = new GameObject(Card) as GameObject;
                //MakeCards(v, "guard");
                cgo.transform.parent = deckAnchor;
                cgo.setValue(v);
                cgo.setName("guard");
                
            }
            if (v == 2)
            {

            }
            if (v == 3)
            {

            }
            if (v == 4)
            {

            }
            cards.Add(cgo);

        }


    }

    public void Draw()
    {
        //take the top card from cards list
        //return that card?
    }

    //public void MakeCards()
    //{

       //cardValues = new List<int>();

       // int TNum;
       //Sprite tS = null;
       // GameObject tGO = null;
       // SpriteRenderer tSR = null;

       //cards = new List<Card>();
       //for (int i = 0; i < cards.Count; i++)
       //{
           //cgo is a local variable

           // GameObject cgo = new GameObject(prefabCard) as GameObject;
           // cgo.transform.parent = deckAnchor;
           // Card card = cgo.GetComponent<Card>();
       // }

    //}
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
