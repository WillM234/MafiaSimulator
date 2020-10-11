using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleRouteController : MonoBehaviour
{
    [Header("Script References")]
    private NarrativeController N_Control;
    private ListOfCards cardList;
    private void Awake()
    {
        N_Control = GetComponent<NarrativeController>();
        cardList = GetComponent<ListOfCards>();
    }
    void Update()
    {
    ///Events that happen during the game///
        ///Starting Job, spawing of first Opportunity///
        if(N_Control.JobsDone >= 3 && N_Control.startingJobsDone == false)
        {
            if(N_Control.StartingJob.wasAccountant == true)
            {
                N_Control.OpportunityCard = cardList.cards[5].gameObject;
                N_Control.SetOneTime(1);
                N_Control.spawnO_Card(1, N_Control.OpportunityCard);
            }
            N_Control.startingJobsDone = true;
        }
        //First major decision, Spawns second Opportunity, first in the actual route///
        if(N_Control.Decision1Made == true && N_Control.SpawnedDecision2 == false)
        {
            if(N_Control.BecameMole == true)
            {
                N_Control.OpportunityCard = cardList.cards[9].gameObject;
                N_Control.SetOneTime(1);
                N_Control.spawnO_Card(1, N_Control.OpportunityCard);
            }
            ///Game-Over condition///
            if(N_Control.BecameMole == false)
            {
                if(N_Control.refusedDeal == false && N_Control.DidntJoinFamily == false)
                {
                    N_Control.refusedMole = true;
                }
            }
            N_Control.SpawnedDecision2 = true;
        }
        ///
    }
}