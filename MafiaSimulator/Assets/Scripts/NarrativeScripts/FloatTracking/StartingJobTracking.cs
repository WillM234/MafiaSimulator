using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingJobTracking : MonoBehaviour
{
    public bool OneTime;
    private VerbTimer actionTimer;
    private CardTimer C_Timer;
    private NarrativeController N_Control;
    private void Awake()
    {
        actionTimer = GameObject.Find("Verb_Action").GetComponent<VerbTimer>();
        C_Timer = GetComponent <CardTimer>();
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
    }
    private void Update()
    {
        if(actionTimer.currentState == VerbTimer.GameState.ReadyToCollect && C_Timer.in_aSnap == true)
        {
            if(!OneTime)
            {
                N_Control.JobsDone += 1;//adds one to Job Tracking in NarrativeController
                OneTime = true;//sets OneTime to true so it doesn't add more than 1 to narrative controller
            }//this stuff only happens when OneTime is false, the card is in Action's SnapPosition, and Verb_Action's gamestate is ReadyToCollect
        }
        if(actionTimer.currentState == VerbTimer.GameState.Start)
        {
            OneTime = false;//resets OneTime tp false when Verb_Action's gamestate is Start
        }
    }
}
