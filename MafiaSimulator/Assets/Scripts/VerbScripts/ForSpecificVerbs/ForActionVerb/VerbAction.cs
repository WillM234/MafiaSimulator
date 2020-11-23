using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbAction : MonoBehaviour
{
    private NarrativeController N_Control;
    private CardPositioning verbAction;
    private ListOfCards cardList;
    private VerbTimer actionTimer;
    public GameObject CurrencyPrefab, Empty;
    public GameObject inSlot1, inSlot2, inSlot3, inSlot4, LastinSnap;
    public Vector3 SpawnPoint;
    public AudioSource aSource;
    public AudioClip moneySound;
    public int rewardAmount;
    public bool cardInPos, OneTime, locked;
    public void Awake()
    {
        inSlot1 = Empty;
        inSlot2 = Empty;
        inSlot3 = Empty;
        inSlot4 = Empty;
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        verbAction = GetComponent<CardPositioning>();
        actionTimer = GetComponent<VerbTimer>();
        cardList = GameObject.Find("NarrativeController").GetComponent<ListOfCards>();
        SpawnPoint = new Vector3(verbAction.SnapPosition.x, (verbAction.SnapPosition.y - 300f), verbAction.S1_Snap.z);
    }
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject card in verbAction.Card)
        {
            if (card.transform.position == verbAction.S1_Snap)
            {
                if (actionTimer.currentState == VerbTimer.GameState.Start)
                {
                    actionTimer.timeLeft = inSlot1.GetComponent<CardTimer>().cardAsset.aTimer;
                    actionTimer.startTime = actionTimer.timeLeft;
                }
            }
            ///tracking whichever card is in the slot
            ///Tracking card that is in slot 1
            if (card.GetComponent<CardsInSlots>().aS1_Snap == true)
            {
                inSlot1 = card.gameObject;
            }
            if(inSlot1.GetComponent<CardsInSlots>().aS1_Snap == false)
            {
                inSlot1 = Empty;
            }
            ///Tracking card that is in slot 2
            if (card.GetComponent<CardsInSlots>().aS2_Snap == true)
            {
                inSlot2 = card.gameObject;
            }
            if (inSlot2.GetComponent<CardsInSlots>().aS2_Snap == false)
            {
                inSlot2 = Empty;
            }
            ///Tracking card that is in slot 3
            if (card.GetComponent<CardsInSlots>().aS3_Snap == true)
            {
                inSlot3 = card.gameObject;
            }
            if (inSlot3.GetComponent<CardsInSlots>().aS3_Snap == false)
            {
                inSlot3 = Empty;
            }
            ///Tracking card that is in slot 4
            if (card.GetComponent<CardsInSlots>().aS4_Snap == true)
            {
                inSlot4 = card.gameObject;
            }
            if (inSlot4.GetComponent<CardsInSlots>().aS4_Snap == false)
            {
                inSlot4 = Empty;
            }
        }
        //fetching && setting reward amount
        //rewardAmount = inSlot1.GetComponent<CardTimer>().cardAsset.CurrencyReward;
///locking  of the card into positon during any state but start state///
        if (actionTimer.currentState != VerbTimer.GameState.Start)
        {
            locked = true;
            verbAction.locked = true;
        }
        else
        {
            locked = false;
            verbAction.locked = false;
        }
///used for controlling spawn rate, if not used just spawned infinately///
        if (actionTimer.timeLeft > 0)
        {
            OneTime = false;
        }
        /*if (actionTimer.timeLeft <= 0 && actionTimer.currentState == VerbTimer.GameState.reSet)
        {
            if (!OneTime)
            {
                SpawnReward(rewardAmount);
            }
        }*/
 ///if i used a while loop, Unity crashed///
        if (locked == true)
        {
            inSlot1.GetComponent<CardDragging>().dragging = false;
            inSlot2.GetComponent<CardDragging>().dragging = false;
            inSlot3.GetComponent<CardDragging>().dragging = false;
            inSlot4.GetComponent<CardDragging>().dragging = false;
        }
    }
///used for spawing currency when job is done///
    public void SpawnReward(int amount)
    {
        aSource.PlayOneShot(moneySound);
        for (int i = 0; i < amount; i ++)
        {
            Instantiate(CurrencyPrefab, SpawnPoint, Quaternion.identity);
            OneTime = true;
        }
    }
}