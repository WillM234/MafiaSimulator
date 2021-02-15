using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision1Destroy : MonoBehaviour
{
    public bool removed;
    private VerbAction vAction;
    private VerbTimer aTimer;
    private NarrativeController N_Control;
    private CardPositioning Tpasses, VerbA, VerbI, VerbS;
    private void Awake()
    {///references to other scripts
        aTimer = GameObject.Find("ActionButton").GetComponent<VerbTimer>();
        vAction = GameObject.Find("ActionButton").GetComponent<VerbAction>();
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
    ///References for list scripts
        Tpasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbA = GameObject.Find("ActionButton").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("InvestigateButton").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("SpeakButton").GetComponent<CardPositioning>();
    }
    void Update()
    {
        if(vAction.inSlot1 == gameObject && aTimer.timeLeft <= 0 && aTimer.currentState == VerbTimer.GameState.ReadyToCollect)
        {
            whichChoice();
        }
        if (removed)
        {
            vAction.inSlot1 = vAction.Empty;
            Destroy(gameObject);//destroys attached gameObject
        }
    }
    public void removeFromLists()//removes card from the lists
    {
        Tpasses.Card.Remove(gameObject);
        VerbA.Card.Remove(gameObject);
        VerbI.Card.Remove(gameObject);
        VerbS.Card.Remove(gameObject);
        removed = true;//sets removed to true if function is run
    }
    void whichChoice()
    {
        if (N_Control.StartingJob.wasFarmer == true)
        {
            N_Control.TookDeal = true;
        }
        else if (N_Control.StartingJob.wasBouncer == true)
        {
            N_Control.JoinedFamily = true;
        }
        else
            N_Control.BecameMole = true;
        N_Control.Decision1Made = true;
    }
}
