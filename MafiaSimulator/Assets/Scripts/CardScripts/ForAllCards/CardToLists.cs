using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToLists : MonoBehaviour
{
    public CardPositioning TimePasses, VerbAction, VerbSpeak, VerbInstestigate;
    public TimePasses T_Pass;
    public CurrencyList Currency;
    private CardAsset cardAsset;
    private void Awake()
    {
        ///reference scripts, grabbing them through code instead of through inspector///
        T_Pass = GameObject.Find("TimePasses").GetComponent<TimePasses>();
        TimePasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbAction = GameObject.Find("ActionButton").GetComponent<CardPositioning>();
        VerbSpeak = GameObject.Find("SpeakButton").GetComponent<CardPositioning>();
        VerbInstestigate = GameObject.Find("InvestigateButton").GetComponent<CardPositioning>();
        Currency = GameObject.Find("NarrativeController").GetComponent<CurrencyList>();
        cardAsset = this.gameObject.GetComponent<CardTimer>().cardAsset;
        ///Adding the card to the lists so they can be tracked///
        ///These Lists track all the cards
        TimePasses.Card.Add(gameObject);
        VerbAction.Card.Add(gameObject);
        VerbSpeak.Card.Add(gameObject);
        VerbInstestigate.Card.Add(gameObject);
        //These Lists are for specific things
        if(cardAsset.is_Currency == true)
        {
            Currency.Currency.Add(gameObject);
            GetComponent<CurrencyDestruction>().inCurrencyList = true;
        }
    }
}
