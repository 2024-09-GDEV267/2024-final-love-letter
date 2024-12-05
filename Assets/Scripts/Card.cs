using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int value ;
    public string name;
    public bool active ;
    public bool discarded = false;
    public GameObject cardBack;
    
    public void Start()
    {
        //makeCard(1);
        //this.gameObject.name = name;
    }

    /// <summary>
    /// MakeCard acts like the constructor for the card 
    /// </summary>
    /// <param name="cardValue"></param>
    public void makeCard(int cardValue)
    {
        value = cardValue;
        name = decideName(value);
    }

    public string decideName(int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                return "Guard";
            case 2:
                return "Priest";
            case 3:
                return "Baron";
            case 4:
                return "Handmaiden";
            case 5:
                return "Prince";
            case 6:
                return "King";
            case 7:
                return "Countess";
            case 8:
                return "Princess";
            default:
                return null;
        }
    }
    public void Update()
    {
        if (active)
        {
            cardBack.SetActive(false);
        }
        else if (active && discarded)
        {
            cardBack.SetActive(false);
        }
        else
        {
            cardBack.SetActive(true);
        }
    }

    //Gets the value of the card
    public int getValue()
    {
        return value;
    }

    public void setValue(int newValue)
    {
        value = newValue;
        name = decideName(value);
    }

    public void OnMouseUpAsButton()
    {
        print("Card Value is : " +  this.getValue() + " - " + this.name);
    }
    void OnMouseDown()
    {
        
        if (active)
        {
            Debug.Log("Clicked");
            active = false;
            discarded = true;
            LoveLetter.S.playCard(this);
        }
        else
        {
            Debug.Log("not active");
        }
    }
}
