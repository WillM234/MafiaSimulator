using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleRouteController : MonoBehaviour
{
    [Header("Script References")]
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
            if(N_Control.StartingJob.wasAccountant == true)
            {
                tempEnd = true;
                OpportunityCard = cardList.cards[5].gameObject;
                FBackControl.SetOneTime(1);
                N_Control.startingJobsDone = true;
            }
        }
        //First major decision, Spawns second Opportunity, first in the actual route///
        if(N_Control.Decision1Made == true && N_Control.SpawnedDecision2 == false)
        {
            if(N_Control.BecameMole == true)
            {
                
                OpportunityCard = cardList.cards[22].gameObject;//investigate warehouse
                FBackControl.SetOneTime(1);
                N_Control.SpawnedDecision2 = true;
            }
            ///Game-Over condition///
            if(N_Control.BecameMole == false)
            {
                if(N_Control.refusedDeal == false && N_Control.DidntJoinFamily == false)
                {
                    N_Control.refusedMole = true;
                }
            }
        }
        //first blending with family decision, raid rival 
        if(N_Control.Decision2Made == true && N_Control.SpawnedDecision3 == false)
        {
            OpportunityCard = cardList.cards[8].gameObject;//raid rival
            FBackControl.SetOneTime(1);
            N_Control.SpawnedDecision3 = true;
        }
        //investigate the docks
        if (N_Control.Decision3Made == true && N_Control.SpawnedDecision4 == false)
        {
            OpportunityCard = cardList.cards[9].gameObject;//investigate docks
            FBackControl.SetOneTime(1);
            N_Control.SpawnedDecision4 = true;
        }
        //2nd blending with family decision, assassinate rival head
        if (N_Control.Decision4Made == true && N_Control.SpawnedDecision5 == false)
        {
            OpportunityCard = cardList.cards[12].gameObject;//Spawns AssassinateRDon Card
            FBackControl.SetOneTime(1);
            N_Control.SpawnedDecision5 = true;
        }
        //investigate headquarters, temp end
        if(N_Control.Decision5made == true && N_Control.SpawnedDecision6 == false)
        {
            tempEnd = true;
            //OpportunityCard = cardList.cards[23].gameObject;//investigate HeadQuarters
            FBackControl.SetOneTime(1);
            N_Control.SpawnedDecision6 = true;
        }
    }
    public void spawnO_Card(int times, GameObject card)
    {
        for (int i = 0; i < times; i++)
        {
            Instantiate(card, SpawnPoint, Quaternion.identity);
            OneTime = true;
            OpportunityCard = Empty;
        }
    }
    public void SetOneTime(int times)
    {
        if(N_Control.StartingJob.wasAccountant == true)
        {
            for (int i = 0; i < times; i++)
            {
                OneTime = false;
            }
        }
    }
}