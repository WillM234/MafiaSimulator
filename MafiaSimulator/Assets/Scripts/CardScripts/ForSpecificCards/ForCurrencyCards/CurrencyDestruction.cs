using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyDestruction : MonoBehaviour
{
    private TimePasses timePasses;
    private CardPositioning TPasses, VerbA, VerbE, VerbI, VerbS;
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
        VerbA = GameObject.Find("Verb_Action").GetComponent<CardPositioning>();
        VerbE = GameObject.Find("Verb_Explore").GetComponent<CardPositioning>();
        VerbI  = GameObject.Find("Verb_Investigate").GetComponent<CardPositioning>();
        VerbS  = GameObject.Find("Verb_Speak").GetComponent<CardPositioning>();
        cList = GameObject.Find("NarrativeController").GetComponent<CurrencyList>();
    }
    private void Update()
    {
        if (removed && timePasses.Destroyed == false)
        {
            timePasses.Destroyed = true;
            timePasses.cardInSnap = false;
            Destroy(gameObject);
        }
    }
    public void RemoveFromLists()
    {
        cList.Currency.Remove(gameObject);
        TPasses.Card.Remove(gameObject);
        VerbA.Card.Remove(gameObject);
        VerbE.Card.Remove(gameObject);
        VerbI.Card.Remove(gameObject);
        VerbS.Card.Remove(gameObject);
        removed = true;
    }
}
