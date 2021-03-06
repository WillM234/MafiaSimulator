﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision2Destroy : MonoBehaviour
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
        VerbI = GameObject.Find("Verb_Investigate").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("Verb_Speak").GetComponent<CardPositioning>();
    }
    void Update()
    {
        if(vAction.inSlot1 == gameObject && aTimer.timeLeft <= 0 && aTimer.currentState == VerbTimer.GameState.ReadyToCollect)
        {
            whichRoute();
        }
        if (removed)
        {
            vAction.inSlot1 = vAction.Empty;
            Destroy(gameObject);
        }
    }
    void whichRoute()
    {
        if((N_Control.TookDeal == true || N_Control.JoinedFamily == true))
        {
            N_Control.participateRaid = true;
            N_Control.raidFinished = true;
        }
        if(N_Control.StartingJob.wasAccountant == true)
        {
            N_Control.moleDecision3 = true;
        }
        N_Control.Decision2Made = true;
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