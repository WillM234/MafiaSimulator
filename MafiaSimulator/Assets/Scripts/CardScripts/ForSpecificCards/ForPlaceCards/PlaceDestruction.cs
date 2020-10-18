using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDestruction : MonoBehaviour
{
    private bool removed;
    private VerbAction vAction;
    private VerbTimer aTimer;
    private NarrativeController N_Control;
    private CardPositioning Tpasses, VerbA, VerbE, VerbI, VerbS;
    private void Awake()
    {
        aTimer = GameObject.Find("Verb_Action").GetComponent<VerbTimer>();
        vAction = GameObject.Find("Verb_Action").GetComponent<VerbAction>();
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        Tpasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbA = GameObject.Find("Verb_Action").GetComponent<CardPositioning>();
        VerbE = GameObject.Find("Verb_Explore").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("Verb_Investigate").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("Verb_Speak").GetComponent<CardPositioning>();
    }
    void Update()
    {
        if(vAction.inSlot1 == gameObject && aTimer.timeLeft <= 0)
        {
            whichCard();
            if(N_Control.raidFinished == true)
            {
                //removeFromLists();
                if (removed)
                {
                    vAction.inSlot1 = vAction.Empty;
                    Destroy(gameObject);
                }
            } 
        }
    }
    void whichCard()
    {
        if(this.gameObject.name == "Card_P_TheDocks(Clone)")
        {
            N_Control.raidFinished = true;
        }
    }
    public void removeFromLists()
    {
        Tpasses.Card.Remove(gameObject);
        VerbA.Card.Remove(gameObject);
        VerbE.Card.Remove(gameObject);
        VerbI.Card.Remove(gameObject);
        VerbS.Card.Remove(gameObject);
        removed = true;
    }
}
