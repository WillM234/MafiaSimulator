using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleDestruction : MonoBehaviour
{
    public bool removed;
    private VerbAction vAction;
    private VerbTimer aTimer;
    private NarrativeController N_Control;
    private CardPositioning Tpasses, VerbA, VerbI, VerbS;
    private void Awake()
    {
        aTimer = GameObject.Find("ActionButton").GetComponent<VerbTimer>();
        vAction = GameObject.Find("ActionButton").GetComponent<VerbAction>();
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        Tpasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbA = GameObject.Find("ActionButton").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("InvestigateButton").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("SpeakButton").GetComponent<CardPositioning>();
    }
    void Update()
    {if(vAction.inSlot1 == gameObject && aTimer.timeLeft <= 0 && aTimer.currentState == VerbTimer.GameState.ReadyToCollect)
        {
            whichCard();
        }
        if (removed)
        {
            vAction.inSlot1 = vAction.Empty;
            Destroy(gameObject);
        }
    }
    void whichCard()
    {
        if(gameObject.name == "Card_O_(Clone)")
        {
            N_Control.cFamDecision3 = true;
        }
        if (gameObject.name == "Card_O_(Clone)")
        {
            N_Control.cFamDecision4 = true;
        }
        if (gameObject.name == "Card_O_(Clone)")
        {
            N_Control.cFamDecision5 = true;
        }
        if (gameObject.name == "Card_O_(Clone)")
        {
            N_Control.cFamDecision6 = true;
        }
    }
    public void removeFromList()
    {
        Tpasses.Card.Remove(gameObject);
        VerbA.Card.Remove(gameObject);
        VerbI.Card.Remove(gameObject);
        VerbS.Card.Remove(gameObject);
        removed = true;
    }
}
