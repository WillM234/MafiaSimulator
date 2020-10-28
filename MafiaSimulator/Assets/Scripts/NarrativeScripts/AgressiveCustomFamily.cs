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
                OpportunityCard = cardList.cards[10].gameObject;
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
    if(N_Control.DidntJoinFamily == true && N_Control.StartingJob.wasBouncer == true)
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
