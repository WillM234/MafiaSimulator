using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePasses : MonoBehaviour
{
    public GameObject lastInSnap, Empty;
    private CardTimer c_Timer;
    private VerbAutoTimer AutoTimer;
    private CardPositioning timePasses, VerbA, VerbI, VerbS;
    private CurrencyList currentCurrency;
    public bool cardInSnap, Destroyed;
    private void Awake()
    {
        timePasses = GetComponent<CardPositioning>();
        VerbA = GameObject.Find("ActionButton").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("InvestigateButton").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("SpeakButton").GetComponent<CardPositioning>();
        AutoTimer = GetComponent<VerbAutoTimer>();
        currentCurrency = GameObject.Find("NarrativeController").GetComponent<CurrencyList>();
    }
    void Update()
    {
        if(currentCurrency.Currency.Count > 0)
        {
            if (currentCurrency.Currency[0].GetComponent<CardsInSlots>().in_tSnap == true)
            {
                cardInSnap = true;
                lastInSnap = currentCurrency.Currency[0].gameObject;
            }
            else
            {
                cardInSnap = false;
                Destroyed = false;
            }
            if (!cardInSnap && Destroyed)
            {
                currentCurrency.Currency[0].GetComponent<Transform>().position = timePasses.SnapPosition;
                lastInSnap = currentCurrency.Currency[0].gameObject;
            }
            else if(cardInSnap && Destroyed)
            {
                Destroyed = false;
                cardInSnap = false;
            }
            else if(!cardInSnap && !Destroyed)
            {
                currentCurrency.Currency[0].GetComponent<Transform>().position = timePasses.SnapPosition;
                lastInSnap = Empty;
            }
        }
        else if(currentCurrency.Currency.Count < 1)
        {
            cardInSnap = false;
            Destroyed = false;
        }
    }
}