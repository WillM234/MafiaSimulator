﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinedFamilyController : MonoBehaviour
{
    [Header("Script References")]
    private NarrativeController N_Control;
    private ListOfCards cardList;
    public bool OneTime;
    public Vector3 SpawnPoint;
    public GameObject OpportunityCard;
    private void Awake()
    {
        N_Control = GetComponent<NarrativeController>();
        cardList = GetComponent<ListOfCards>();
        OneTime = true;
        OpportunityCard = null;
    }
    private void Update()
    {
        if(!OneTime)
        {
            spawnO_Card(1, OpportunityCard);
        }
        ///Events that happen during the game///
        ///Starting Job, spawing of first Opportunity///
        if (N_Control.JobsDone >= 3 && N_Control.startingJobsDone == false)
        {
            if (N_Control.StartingJob.wasFarmer == true)
            {
                OpportunityCard = cardList.cards[6].gameObject;
                SetOneTime(1);
                N_Control.startingJobsDone = true;
            }
        }
        ///First major decision, Spawns second Opportunity, first in the actual route///
        if (N_Control.Decision1Made == true && N_Control.SpawnedDecision2 == false)
        {
            if (N_Control.TookDeal == true || N_Control.JoinedFamily == true)
            {
                OpportunityCard = cardList.cards[8].gameObject;
                SetOneTime(1);
                N_Control.SpawnedDecision2 = true;
            }
        }
        ///Second opportunity, spawns The Docks for raid
        if (N_Control.Decision2Made == true && N_Control.spawnPlace == false)
        {
            if (N_Control.participateRaid == true)
            {
                OpportunityCard = cardList.cards[11].gameObject;
                SetOneTime(1);
                N_Control.spawnPlace = true;
            }
        }
        ///after spawning Docks and taking an Action on it, spawns next opportunity///
        if (N_Control.Decision2Made == true && N_Control.SpawnedDecision3 == false)
        {
            if (N_Control.raidFinished == true)
            {
                OpportunityCard = cardList.cards[12].gameObject;
                SetOneTime(1);
                N_Control.SpawnedDecision3 = true;
            }
        }
        //Spawning of final Decision for this route, to be or not to be, the Don
        if(N_Control.Decision3Made == true && N_Control.SpawnedDecision4 == false)
        {
            if(N_Control.assassinatedRDon == true)
            {
                OpportunityCard = cardList.cards[13].gameObject;
                SetOneTime(1);
                N_Control.SpawnedDecision4 = true;
            }
        }
    }
    public void spawnO_Card(int times, GameObject card)
    {
        for (int i = 0; i < times; i++)
        {
            Instantiate(card, SpawnPoint, Quaternion.identity);
            Debug.Log("Spawned Card");
            OneTime = true;
            OpportunityCard = null;
        }
    }
    public void SetOneTime(int times)
    {
        for (int i = 0; i < times; i++)
        {
            OneTime = false;
        }
    }
}