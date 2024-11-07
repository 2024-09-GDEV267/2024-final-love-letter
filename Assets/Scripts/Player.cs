using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int score = 0;
    Card[] hand;
    int handSize = 0;

    public Deck Draw(Deck drawingFrom)
    {
        hand[handSize] = (drawingFrom.deal());
        return drawingFrom;
    }
}
