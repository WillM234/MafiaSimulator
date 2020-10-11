using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveCustomFamily : MonoBehaviour
{   [Header("Script References")]
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
            if(N_Control.StartingJob.wasBouncer == true)
            {
                N_Control.OpportunityCard = cardList.cards[7].gameObject;
                N_Control.SetOneTime(1);
                N_Control.spawnO_Card(1, N_Control.OpportunityCard);
            }
            N_Control.startingJobsDone = true;
        }
      ///First major decision, Spawns second Opportunity, first in the actual route///
      if (N_Control.Decision1Made == true && N_Control.SpawnedDecision2 == false)
        {
            if(N_Control.DidntJoinFamily == true)
            {
                N_Control.OpportunityCard = cardList.cards[10].gameObject;
                N_Control.SetOneTime(1);
                N_Control.spawnO_Card(1, N_Control.OpportunityCard);
            }
            N_Control.SpawnedDecision2 = true;
        }
      ///
    }
}
