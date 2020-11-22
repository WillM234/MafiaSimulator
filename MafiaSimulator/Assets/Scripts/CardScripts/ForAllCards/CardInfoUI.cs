using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardInfoUI : MonoBehaviour
{
    private CardHover cHover;
    private GameObject thisCard;
    void Awake()    
    {
        cHover = GetComponent<CardHover>();
        thisCard = gameObject;
    }

    private void OnMouseUp()
    {
        if(cHover.mouseIsOver == true)
        {
            Debug.Log("This card, " + thisCard.name + " was clicked.");
        }
    }
}
