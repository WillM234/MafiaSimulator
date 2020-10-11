using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbAction : MonoBehaviour
{
    private NarrativeController N_Control;
    private CardPositioning verbAction;
    private ListOfCards cardList;
    private VerbTimer actionTimer;
    public GameObject CurrencyPrefab;
    public GameObject LastinSnap;
    public Vector3 SpawnPoint;
    public int rewardAmount;
    public bool cardInPos, OneTime, locked;
    public void Awake()
    {
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        verbAction = GetComponent<CardPositioning>();
        actionTimer = GetComponent<VerbTimer>();
        cardList = GameObject.Find("NarrativeController").GetComponent<ListOfCards>();
        SpawnPoint = new Vector3(verbAction.SnapPosition.x, (verbAction.SnapPosition.y - 200f), verbAction.SnapPosition.z);
    }
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject card in verbAction.Card)
        {
            if (card.transform.position == verbAction.SnapPosition)
            {
                cardInPos = true;
                rewardAmount = card.GetComponent<CardTimer>().cardAsset.CurrencyReward;
                if (actionTimer.currentState == VerbTimer.GameState.Start)
                {
                    actionTimer.timeLeft = card.GetComponent<CardTimer>().cardAsset.aTimer;
                    actionTimer.startTime = actionTimer.timeLeft;
                }
            }
        }
///locking  of the card into positon during any state but start state///
        if (actionTimer.currentState != VerbTimer.GameState.Start)
        {
            locked = true;
        }
        else
        {
            locked = false;
        }
///used for controlling spawn rate, if not used just spawned infinately///
        if (actionTimer.timeLeft > 0)
        {
            OneTime = false;
        }
        if (actionTimer.timeLeft <= 0)
        {
            if (!OneTime)
            {
                SpawnReward(rewardAmount);
            }
        }
 ///if i used a while loop, Unity crashed///
        if (locked == true)
        {
            LastinSnap.transform.position = verbAction.SnapPosition;
        }
    }
///used for spawing currency when job is done///
    public void SpawnReward(int amount)
    {
        for(int i = 0; i < amount; i ++)
        {
            Instantiate(CurrencyPrefab, SpawnPoint, Quaternion.identity);
            OneTime = true;
        }
    }
}