using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    public bool GameWon, GameLost;
    public bool byLackofFunds, refusedMole, bySentToPrison;
    public bool BecameMole, TookDeal, JoinedFamily;
    private bool OneTime;
    public bool Decision1Made;
    private bool startingJobsDone, SpawnedDecision2;
    private ListOfCards listAllCards;
    public GameObject OpportunityCard;
    public float JobsDone, NoCurrency;
    public PlayerClass StartingJob;
    public Vector3 SpawnPont;
    private void Awake()
    {
        OneTime = true;
        listAllCards = GetComponent<ListOfCards>();
    }
    void Update()
    {
    ///insatntiation of new opportunities///
    if(!OneTime)
        {
            spawnO_Card(1, OpportunityCard);
        }
    /// events that happen during the game///
        /// Starting Jobs, first Opportunity/// 
        if (JobsDone >= 3 && startingJobsDone == false)
        {
            if (StartingJob.wasAccountant == true)
            {
                OpportunityCard = listAllCards.cards[5].gameObject;
                SetOneTime(1);
            }
            else if (StartingJob.wasFarmer == true)
            {
                OpportunityCard = listAllCards.cards[6].gameObject;
                SetOneTime(1);
            }
            else
            {
                OpportunityCard = listAllCards.cards[7].gameObject;
                SetOneTime(1);
            }
            startingJobsDone = true;
        }
        ///First Major Decision
        if(Decision1Made && SpawnedDecision2 == false)
        {
            ///Starts to split here, "To Be or Not To Be, A Mole"//
            if(BecameMole == true)//Starts Player is Mole Route
            {
                OpportunityCard = listAllCards.cards[9].gameObject;
                SetOneTime(1);
            }
            else
            {
                ///If player takes deal, they join an existing family, not as a mole//
                if (TookDeal)
                {
                    OpportunityCard = listAllCards.cards[8].gameObject;
                    SetOneTime(1);
                }
                ///If player does not take the deal, nothing planned yet, dead end///
                else if (!TookDeal)
                {
                    //OpportunityCard = listAllCards.cards[].gameObject;
                    //SetOneTime(1);
                }
                ///if player doesn't take recruiter's offer, starts "Create Family" Route///
                else if (!JoinedFamily)
                {
                    OpportunityCard = listAllCards.cards[10].gameObject;
                    SetOneTime(1);
                }
                ///If player joined a family, not as a mole///
                else if (JoinedFamily)
                {
                    OpportunityCard = listAllCards.cards[8].gameObject;
                    SetOneTime(1);
                }
                ///Player refuses to become a mole, they lose and go to prision///
                else
                {
                    refusedMole = true;
                    GameLost = true;
                }
            }
            SpawnedDecision2 = true;
        }
    ///Game Won conditions/// 
    ///Game Lose conditions///
         ///No currency game over///
        if(NoCurrency >= 4)
        {
            byLackofFunds = true;
            GameLost = true;
        }
    }
   public void spawnO_Card(int times, GameObject card)
    {
        for(int i = 0; i < times; i++)
        {
            Instantiate(card, SpawnPont, Quaternion.identity);
            OneTime = true;
            OpportunityCard = null;
        }
    }
    public void SetOneTime(int times)
    {
        for(int i = 0; i < times; i++)
        {
            OneTime = false;
        }
    }
}