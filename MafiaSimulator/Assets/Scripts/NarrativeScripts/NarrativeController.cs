using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    //Referenced Scripts
    private ListOfCards listAllCards;
    public PlayerClass StartingJob;
    [Header("Game Conditions")]
    public bool GameWon, GameLost;
    [Header("won by:")]
    public bool BecameTheDon;
    public bool BecameImportant_toFamily;
    [Header("lost by:")]
    public bool byLackofFunds;
    public bool refusedMole;
    public bool bySentToPrison;
    public bool byKickedOut;
    [Header("Decision 1 flags,routes split with these")]
    public bool BecameMole;
    public bool TookDeal;
    public bool JoinedFamily;
    public bool refusedDeal;
    public bool DidntJoinFamily;
    public bool Decision1Made;
    [Header("Decision 2 flags")]
    public bool participateRaid;
    public bool raidFinished;
    public bool spawnPlace;
    public bool moleDecision2;
    public bool cFamDecision2;
    public bool Decision2Made;
    [Header("Decision 3 flags")]
    public bool assassinatedRDon;
    public bool moleDecision3;
    public bool cFamDecision3;
    public bool Decision3Made;
    [Header("Decision 4 flags")]
    public bool moleDecision4;
    public bool cFamDecision4;
    public bool Decision4Made;
    [Header("Decision 5 Flags")]
    public bool moleDecision5;
    public bool cFamDecision5;
    public bool Decision5made;
    [Header("Decision 6 Flags")]
    public bool moleDecision6;
    public bool cFamDecision6;
    public bool Decision6made;
    [Header("Decision 7 flags")]
    public bool cFamDecision7;
    [Header("Flags for spawning cards")]
    public bool OneTime;
    public bool startingJobsDone;
    public bool SpawnedDecision2;
    public bool SpawnedDecision3;
    public bool SpawnedDecision4;
    public bool SpawnedDecision5;
    public bool SpawnedDecision6;
    public bool SpawnedDecision7;
    [Header("Stuff needed for Instantiation")]
    public GameObject empty;
    public GameObject OpportunityCard;                                          
    public Vector3 SpawnPont;
    [Header("floats for tracking progress")]
    public float JobsDone;
    public float NoCurrency;
    public float AngryFamily;
    public bool afamOnce = true;
    public bool debtOnce = true;
    public GameObject debtWarningPanel;
    public GameObject aFamWarningPanel;
    public PlayerActions pActions;
    private void Awake()
    {
        OneTime = true;
        afamOnce = true;
        debtOnce = true;
        pActions = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
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
        if(NoCurrency == 2 && debtOnce)
        {
            if (debtOnce)
            {
                openDebtWarning();
 
            }
        }
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
        ///Warning for the family being angry
        if(AngryFamily == 1 && afamOnce)
        {
            if(afamOnce)
            {
                openAFamWarning();
            }
        }
        //actually being kicked out of the family
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
    public void openDebtWarning()
    {
        debtWarningPanel.SetActive(true);
        pActions.currentState = PlayerActions.GameState.Paused;
        debtOnce = false;
    }
    public void openAFamWarning()
    {
        aFamWarningPanel.SetActive(true);
        pActions.currentState = PlayerActions.GameState.Paused;
        afamOnce = false;
    }
    public void closeDebtWarning()
    {
        debtWarningPanel.SetActive(false);
        pActions.currentState = PlayerActions.GameState.Active;
        
    }
    public void closeAFamWarning()
    {
        aFamWarningPanel.SetActive(false);
        pActions.currentState = PlayerActions.GameState.Active;
       
    }
}