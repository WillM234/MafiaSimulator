using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEmpty : MonoBehaviour
{
    private CardPositioning Tpasses, VerbA, VerbE, VerbI, VerbS;
    private void Awake()
    {
        Tpasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbA = GameObject.Find("Verb_Action").GetComponent<CardPositioning>();
        VerbE = GameObject.Find("Verb_Explore").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("Verb_Investigate").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("Verb_Speak").GetComponent<CardPositioning>();
        Tpasses.Card.Remove(gameObject);
        VerbA.Card.Remove(gameObject);
        VerbE.Card.Remove(gameObject);
        VerbI.Card.Remove(gameObject);
        VerbS.Card.Remove(gameObject);
        if(gameObject.name == "emptyCard(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
