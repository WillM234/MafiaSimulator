﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartMenuController : MonoBehaviour
{
    public Text ClassBackground, ClassBackground2;
    public Button TheFarmer, TheBouncer, TheAccountant, GameStart;
    public PlayerClass Farmer, Accountant, Bouncer;
    public GameObject Currency;
    public GameObject StartingJob;
    public Vector3 JobSpawn, CurrencySpawn;
    public int NumCurrency;
    private NarrativeController N_Control;
    private ListOfCards cardList;
    private PlayerActions pActions;
    private void Awake()
    {
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        cardList = GameObject.Find("NarrativeController").GetComponent<ListOfCards>();
        pActions = GetComponent<PlayerActions>();
        GameStart.interactable = false;
    }
    private void Update()
    {
        if(TheAccountant.interactable == false || TheBouncer.interactable == false || TheFarmer.interactable == false)
        {
            GameStart.interactable = true;
        }
        if(TheFarmer.interactable == false)
        {
            ClassBackground.text = "You are a farmer who has hit hard times. So you have turned to something more lucrative: running moonshine.";
            ClassBackground2.text = "Starting currency is 4.";
        }
        if(TheAccountant.interactable == false)
        {
            ClassBackground.text = "You are an Accountant who has broken into the money laundering buisness. I wonder how long you will survive.";
            ClassBackground2.text = "Starting currency is 8.";
        }
        if(TheBouncer.interactable == false)
        {
            ClassBackground.text = "You are a bouncer at a popular club. Someone has taken notice of your efforts. I wonder what they have planned for you.";
            ClassBackground2.text = "Starting currency is 6.";
        }
    }
    public void ButtonPressSpawn()
    {
        pActions.currentState = PlayerActions.GameState.Active;
        SpawningStartingJob(1, StartingJob);
        SpawnStartingCurrency(NumCurrency, Currency);
    }
    void SpawningStartingJob(int times, GameObject card)
    {
        for(int i = 0; i < times; i++)
        {
            Instantiate(card, JobSpawn, Quaternion.identity);
        }
    }
    void SpawnStartingCurrency(int times, GameObject card)
    {
        for (int i = 0; i < times; i++)
        {
            Instantiate(card, CurrencySpawn, Quaternion.identity);
        }
    }
    public void setPClassFarmer()
    {
        N_Control.StartingJob = Farmer;
        StartingJob = cardList.cards[2].gameObject;
        NumCurrency = Farmer.starting_Currency;
        TheFarmer.interactable = false;
        TheAccountant.interactable = true;
        TheBouncer.interactable = true;
    }
    public void setPClassAccountant()
    {
        N_Control.StartingJob = Accountant;
        StartingJob = cardList.cards[1].gameObject;
        NumCurrency = Accountant.starting_Currency;
        TheFarmer.interactable = true;
        TheAccountant.interactable = false;
        TheBouncer.interactable = true;
    }
    public void setPClassBouncer()
    {
        N_Control.StartingJob = Bouncer;
        StartingJob = cardList.cards[0].gameObject;
        NumCurrency = Bouncer.starting_Currency;
        TheFarmer.interactable = true;
        TheAccountant.interactable = true;
        TheBouncer.interactable = false;
    }
}