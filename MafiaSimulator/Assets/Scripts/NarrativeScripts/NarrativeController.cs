using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    //Referenced Scripts
    private ListOfCards listAllCards;
    public PlayerClass StartingJob;
    //Game Conditions
    public bool GameWon, GameLost;
    //won by:
    public bool BecameTheDon, BecameImportant_toFamily;
    //lost by:
    public bool byLackofFunds, refusedMole, bySentToPrison, byKickedOut;
    //Decision 1 flags,routes split with these
    public bool BecameMole, TookDeal, JoinedFamily;
    public bool refusedDeal, DidntJoinFamily;
    public bool Decision1Made;
    //Decision 2 flags
    public bool participateRaid;
    public bool raidFinished;
    public bool spawnPlace;
    public bool Decision2Made;
    //Decision 3 flags
    public bool assassinatedRDon;
    public bool Decision3Made;
    //Decision 4 flags
    public bool Decision4Made;
    //Flags for spawning cards
    public bool OneTime;
    public bool startingJobsDone, SpawnedDecision2,SpawnedDecision3,SpawnedDecision4;
    //Stuff needed for Instantiation
    public GameObject empty;
    public GameObject OpportunityCard;
    public Vector3 SpawnPont;
    //floats for tracking progress
    public float JobsDone, NoCurrency,AngryFamily;
    private void Awake()
    {
        OneTime = true;
        listAllCards = GetComponent<ListOfCards>();
    }
    void Update()
    {
    ///Game Won conditions///
        ///Became import to an existing family
        if(BecameImportant_toFamily == true)
            {
            GameWon = true;
            }
        //Became the Don of an existing family
        if(BecameTheDon == true)
        {
            GameWon = true;
        }
    ///Game Lose conditions///
         ///No currency game over///
        if(NoCurrency >= 4)
        {
            byLackofFunds = true;
            GameLost = true;
        }
        ///refused to become a mole///
        if(refusedMole)
        {
            GameLost = true;

        }
        ///Kicked out of Family///
        if(AngryFamily >= 2)
        {
            byKickedOut = true;
            GameLost = true;
        }
    }
   public void spawnO_Card(int times, GameObject card)
    {
            for (int i = 0; i < times; i++)
            {
                Instantiate(card, SpawnPont, Quaternion.identity);
                Debug.Log("Spawned Card");
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