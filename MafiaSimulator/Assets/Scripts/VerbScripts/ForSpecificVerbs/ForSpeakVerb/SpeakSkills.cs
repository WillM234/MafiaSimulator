using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakSkills : MonoBehaviour
{
    #region referenced scripts
    private ListOfCards cList;
    private VerbTimer sTimer;
    private VerbSpeak vSpeak;
    #endregion
    #region Stuff for card Spawn
    [Header("Stuff for Card Spawn")]
    public bool oneTime, oneRand;
    public float randNum;
    public Vector3 SpawnPoint;
    public GameObject CardtoSpawn;
    public GameObject Empty;
    #endregion
    private void Awake()
    {
        cList = GameObject.Find("NarrativeController").GetComponent<ListOfCards>();
        vSpeak = GetComponent<VerbSpeak>();
        sTimer = GetComponent <VerbTimer>();
        CardtoSpawn = Empty;
        oneTime = true;
        oneRand = true;
    }
    void Update()
    {
        if (!oneRand)
        {
            choseRandNum();
        }
        if (vSpeak.inSlot1.gameObject.name == "Card_S_Athletics(Clone)")
        {
            if(randNum == 1)
            {
                CardtoSpawn = cList.cards[17].gameObject;
            }
            if(randNum == 2)
            {
                CardtoSpawn = cList.cards[18].gameObject;
            }
        }
        if (vSpeak.inSlot1.gameObject.name == "Card_S_Mobility(Clone)")
        {
            if (randNum == 1)
            {
                CardtoSpawn = cList.cards[19].gameObject;
            }
            if (randNum == 2)
            {
                CardtoSpawn = cList.cards[20].gameObject;
            }
        }
        if (vSpeak.inSlot1.gameObject.name == "Card_S_Persuasion(Clone)")
        {
            if(randNum == 1 || randNum == 2)
            {
                CardtoSpawn = cList.cards[21].gameObject;
            }
        }
        if (!oneTime)
        {
            SpawnCard(1, CardtoSpawn);
            oneTime = true;
        }
    }
    public void setOneTime(int times)
    {
        for (int i = 0; i < times; i++)
        {
            oneTime = false;
        }
    }
    public void setRandNum(int times)
    {
        for (int i = 0; i < times; i++)
        {
            oneRand = false;
        }
    }
    public void SpawnCard(int times, GameObject card)
    {
        for(int i = 0; i < times; i ++)
        {
            Instantiate(card, SpawnPoint, Quaternion.identity);
            CardtoSpawn = Empty;
            oneTime = true;
        }
    }
    public void choseRandNum()
    {
        randNum = Mathf.Round(Random.Range(1, 2));
        oneRand = true;
    }
    public void OnButtonPress()
    {
       if(sTimer.currentState == VerbTimer.GameState.Start)
        {
            setRandNum(1);
        }
       else if(sTimer.currentState == VerbTimer.GameState.ReadyToCollect)
        {
            setOneTime(1);
        }
    }
}
