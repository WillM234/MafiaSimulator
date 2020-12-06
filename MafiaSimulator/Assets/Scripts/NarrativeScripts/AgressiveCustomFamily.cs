using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveCustomFamily : MonoBehaviour
{   [Header("Script References")]
    private NarrativeController N_Control;
    private ListOfCards cardList;
    private O_FeedBackController FBackControl;
    public GameObject OpportunityCard, Empty;
    public Vector3 SpawnPoint;
    public bool OneTime, tempEnd;
    private void Awake()
    {
        N_Control = GetComponent<NarrativeController>();
        cardList = GetComponent<ListOfCards>();
        FBackControl = GameObject.Find("MainCamera").GetComponent<O_FeedBackController>();
        OneTime = true;
        OpportunityCard = Empty;
    }
    void Update()
    {
        if(!OneTime)
        {
            spawnO_Card(1, OpportunityCard);
        }
///Events that happen during the game///
      ///Starting Job, spawing of first Opportunity///
      if(N_Control.JobsDone >= 3 && N_Control.startingJobsDone == false)
        {
            if(N_Control.StartingJob.wasBouncer == true)
            {
                OpportunityCard = cardList.cards[7].gameObject;
                FBackControl.SetOneTime(1);
                N_Control.startingJobsDone = true;
            }
        }
      ///First major decision, Spawns second Opportunity, first in the actual route///
      if (N_Control.Decision1Made == true && N_Control.SpawnedDecision2 == false)
        {
            if(N_Control.DidntJoinFamily == true)
            {
                OpportunityCard = cardList.cards[10].gameObject;// spawns create a family
                FBackControl.SetOneTime(1);
                N_Control.SpawnedDecision2 = true;
            }
            if(N_Control.JoinedFamily == true)
            {
                OpportunityCard = cardList.cards[8].gameObject;//Spawns RaidRival card
                FBackControl.SetOneTime(1);
                N_Control.SpawnedDecision2 = true;
            }
        }
       ///Family Specialization
       if(N_Control.cFamDecision2 == true && N_Control.SpawnedDecision3 == false)
         {
            tempEnd = true;
            //OpportunityCard = cardList.cards[24].gameObject;//Spawns Specialization Card, only agressiveness for now
            FBackControl.SetOneTime(1);
            N_Control.SpawnedDecision3 = true;
         }
       ///Enforcement of protection tax, Opportunity
       if (N_Control.cFamDecision3 == true && N_Control.SpawnedDecision4 == false)
         {
            OpportunityCard = cardList.cards[25].gameObject;//opportnity to spawn
            FBackControl.SetOneTime(1); //spawns opportunity card one time
            N_Control.SpawnedDecision4 = true;//flags that the card was spawned
         }
       ///Drug deal protection
       if (N_Control.cFamDecision4 == true && N_Control.SpawnedDecision5 == false)
       {
            OpportunityCard = cardList.cards[26].gameObject; //opportnity to spawn
            FBackControl.SetOneTime(1); //spawns opportunity card one time
            N_Control.SpawnedDecision5 = true;//flags that the card was spawned
       }
       ///Assassinate Rival enforcer 
       if (N_Control.cFamDecision5 == true && N_Control.SpawnedDecision6 == false)
        {
            OpportunityCard = cardList.cards[27].gameObject; //opportnity to spawn
            FBackControl.SetOneTime(1); //spawns opportunity card one time
            N_Control.SpawnedDecision6 = true;//flags that the card was spawned
        }
       ///raid a rivial family
       if(N_Control.cFamDecision6 == true && N_Control.SpawnedDecision7 == false)
        {
            tempEnd = true;
        }
    }
    public void spawnO_Card(int times, GameObject card)
    {
        for(int i = 0; i < times; i++)
        {
            Instantiate(card, SpawnPoint, Quaternion.identity);
            OneTime = true;
            OpportunityCard = Empty;
        }       
    }
    public void SetOneTime(int times)
    {
        if(N_Control.StartingJob.wasBouncer == true)
        {
            for(int i = 0; i < times; i++)
            {
                OneTime = false;
            }
        }
    }
}
