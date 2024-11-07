using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int score;
    Card[] hand;
    int handSize;

    public void Start()
    {
        score = 0;
        handSize = 0;
    }
    public Deck Draw(Deck drawingFrom)
    {
        hand[handSize] = (drawingFrom.deal());
        return drawingFrom;
    }
}
