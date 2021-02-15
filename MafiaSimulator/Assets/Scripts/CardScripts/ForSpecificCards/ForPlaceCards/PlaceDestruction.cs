using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDestruction : MonoBehaviour
{
    private bool removed;
    private MoleRouteController moleRoute;
    private VerbAction vAction;
    private VerbInvestigate vInvest;
    private VerbTimer aTimer, iTimer;
    private NarrativeController N_Control;
    private CardPositioning Tpasses, VerbA, VerbI, VerbS;
    private void Awake()
    {
        moleRoute = GameObject.Find("NarrativeController").GetComponent<MoleRouteController>();
        aTimer = GameObject.Find("ActionButton").GetComponent<VerbTimer>();
        iTimer = GameObject.Find("InvestigateButton").GetComponent<VerbTimer>();
        vAction = GameObject.Find("ActionButton").GetComponent<VerbAction>();
        vInvest = GameObject.Find("InvestigateButton").GetComponent<VerbInvestigate>();
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        Tpasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbA = GameObject.Find("ActionButton").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("InvestigateButton").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("SpeakButton").GetComponent<CardPositioning>();
    }
    void Update()
    {
        if(vInvest.inSlot1 == gameObject && iTimer.timeLeft <= 0 && iTimer.currentState == VerbTimer.GameState.ReadyToCollect)
        {
            whichCard();    
        }
        if (removed)
        {
            vInvest.inSlot1 = vInvest.Empty;
            Destroy(gameObject);
        }
    }
    void whichCard()
    {
        if(this.gameObject.name == "Card_P_TheDocks(Clone)")
        {
            N_Control.moleDecision4 = true;
        }
        if(this.gameObject.name == "Card_P_Warehouse(Clone)")
        {
            N_Control.moleDecision2 = true;
        }
        if(this.gameObject.name == "Card_P_Headquarters(Clone)")
        {
            N_Control.moleDecision6 = true;
        }
    }
    public void removeFromLists()
    {
        Tpasses.Card.Remove(gameObject);
        VerbA.Card.Remove(gameObject);
        VerbI.Card.Remove(gameObject);
        VerbS.Card.Remove(gameObject);
        removed = true;
    }
}
