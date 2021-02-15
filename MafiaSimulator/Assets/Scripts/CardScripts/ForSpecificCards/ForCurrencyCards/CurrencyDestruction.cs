using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyDestruction : MonoBehaviour
{
    private TimePasses timePasses;
    private CardPositioning TPasses, VerbA, VerbI, VerbS;
    private CurrencyList cList;
    private CardTimer cTimer;
    private VerbAutoTimer AutoTimer;
    public bool inCurrencyList, removed;
    private void Awake()
    {
        //finding script reference objects
        cTimer = GetComponent<CardTimer>();
        AutoTimer = GameObject.Find("TimePasses").GetComponent<VerbAutoTimer>();
        timePasses = GameObject.Find("TimePasses").GetComponent<TimePasses>();
        TPasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbA = GameObject.Find("ActionButton").GetComponent<CardPositioning>();
        VerbI  = GameObject.Find("InvestigateButton").GetComponent<CardPositioning>();
        VerbS  = GameObject.Find("SpeakButton").GetComponent<CardPositioning>();
        cList = GameObject.Find("NarrativeController").GetComponent<CurrencyList>();
    }
    private void Update()
    {
        if (timePasses.lastInSnap == gameObject && AutoTimer.timeLeft <= 0)
        {
            ToDestroy();
            timePasses.lastInSnap = null;
        }
        if(removed == true)
        {
            Destroy(gameObject);
        }
    }
    void ToDestroy()
    {
       if(timePasses.Destroyed == false)
        {
            timePasses.Destroyed = true;
            timePasses.cardInSnap = false;
        }
    }
    public void RemoveFromLists()
    {
        cList.Currency.Remove(gameObject);
        TPasses.Card.Remove(gameObject);
        VerbA.Card.Remove(gameObject);
        VerbI.Card.Remove(gameObject);
        VerbS.Card.Remove(gameObject);
        removed = true;
    }
}
