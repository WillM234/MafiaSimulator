using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePasses : MonoBehaviour
{
    private CardTimer c_Timer;
    private VerbAutoTimer AutoTimer;
    private CardPositioning timePasses, VerbA, VerbE, VerbI, VerbS;
    private CurrencyList currentCurrency;
    private CardPositioning cardPos;
    public CardTimer c_timer;
    public bool cardInSnap;
    private void Awake()
    {
        timePasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbA = GameObject.Find("Verb_Action").GetComponent<CardPositioning>();
        VerbE = GameObject.Find("Verb_Explore").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("Verb_Investigate").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("Verb_Speak").GetComponent<CardPositioning>();
        AutoTimer = GetComponent<VerbAutoTimer>();
        cardPos = GetComponent<CardPositioning>();
        currentCurrency = GameObject.Find("NarrativeController").GetComponent<CurrencyList>();
    }
    void Update()
    {
        foreach (GameObject card in currentCurrency.Currency)
        {
            if(AutoTimer.timeLeft <= 0 && cardInSnap == true)
            {
                    card.GetComponent<CurrencyDestruction>().inCurrencyList = false;
                    currentCurrency.Currency.RemoveRange(0, 1);
                    timePasses.Card.RemoveRange(1, 1);
                    VerbA.Card.RemoveRange(1, 1);
                    VerbE.Card.RemoveRange(1, 1);
                    VerbI.Card.RemoveRange(1, 1);
                    VerbS.Card.RemoveRange(1, 1);
                    cardInSnap = false;
            }
        }
        if (c_timer.in_tSnap == true)
        {
            cardInSnap = true;
        }
        else
            cardInSnap = false;
        if (!cardInSnap)
        {
            currentCurrency.Currency[0].gameObject.transform.position = timePasses.SnapPosition;
        }  
    }
}