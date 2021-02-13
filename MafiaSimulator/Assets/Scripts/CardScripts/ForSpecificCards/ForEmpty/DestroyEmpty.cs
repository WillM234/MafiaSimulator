using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEmpty : MonoBehaviour
{
    private CardPositioning Tpasses, VerbA, VerbI, VerbS;
    private void Awake()
    {
        Tpasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbA = GameObject.Find("ActionButton").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("InvestigateButton").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("SpeakButton").GetComponent<CardPositioning>();
        Tpasses.Card.Remove(gameObject);
        VerbA.Card.Remove(gameObject);
        VerbI.Card.Remove(gameObject);
        VerbS.Card.Remove(gameObject);
        if(gameObject.name == "emptyCard(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
