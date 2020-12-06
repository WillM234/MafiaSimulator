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
            if (cList.AthleticsSpawns.Count == 3)
            {
                if (randNum == 0)
                {
                    CardtoSpawn = cList.AthleticsSpawns[0].gameObject;
                }
                else if (randNum == 1)
                {
                    CardtoSpawn = cList.AthleticsSpawns[1].gameObject;
                }
                else if (randNum == 2)
                {
                    CardtoSpawn = cList.AthleticsSpawns[2].gameObject;
                }
                else
                {
                    CardtoSpawn = Empty;
                }
            }
            else if (cList.AthleticsSpawns.Count == 2)
            {
                if (randNum == 0)
                {
                    CardtoSpawn = cList.AthleticsSpawns[0].gameObject;
                }
                else if (randNum == 1 || randNum == 2)
                {
                    CardtoSpawn = cList.AthleticsSpawns[1].gameObject;
                }
                else
                {
                    CardtoSpawn = Empty;
                }
            }
            else if (cList.AthleticsSpawns.Count == 1)
            {
                if (randNum == 0 || randNum == 1 || randNum == 2)
                {
                    CardtoSpawn = cList.AthleticsSpawns[0].gameObject;
                }
                else
                {
                    CardtoSpawn = Empty;
                }
            }
            else
            {
                CardtoSpawn = Empty;
            }
        }
        if (vSpeak.inSlot1.gameObject.name == "Card_S_Mobility(Clone)")
        {
            if (cList.MobilitySpawns.Count == 3)
            {
                if (randNum == 0)
                {
                    CardtoSpawn = cList.MobilitySpawns[0].gameObject;
                }
                else if (randNum == 1)
                {
                    CardtoSpawn = cList.MobilitySpawns[1].gameObject;
                }
                else if (randNum == 2)
                {
                    CardtoSpawn = cList.MobilitySpawns[2].gameObject;
                }
                else
                {
                    CardtoSpawn = Empty;
                }
            }
            else if (cList.MobilitySpawns.Count == 2)
            {
                if (randNum == 0)
                {
                    CardtoSpawn = cList.MobilitySpawns[0].gameObject;
                }
                else if (randNum == 1 || randNum == 2)
                {
                    CardtoSpawn = cList.MobilitySpawns[1].gameObject;
                }
                else
                {
                    CardtoSpawn = Empty;
                }
            }
            else if (cList.MobilitySpawns.Count == 1)
            {
                if (randNum == 0 || randNum == 1 || randNum == 2)
                {
                    CardtoSpawn = cList.MobilitySpawns[0].gameObject;
                }
                else
                {
                    CardtoSpawn = Empty;
                }
            }
            else
            {
                CardtoSpawn = Empty;
            }
        }
        if (vSpeak.inSlot1.gameObject.name == "Card_S_Persuasion(Clone)")
        {

            if(cList.PersuasionSpawns.Count == 2)
            {
                if(randNum == 0)
                {
                    CardtoSpawn = cList.PersuasionSpawns[0].gameObject;
                }
                else if(randNum == 1)
                {
                    CardtoSpawn = cList.PersuasionSpawns[1].gameObject;
                }
                else
                {
                    CardtoSpawn = Empty;
                }
            }
            else if(cList.PersuasionSpawns.Count == 1)
            {
                if (randNum == 0)
                {
                    CardtoSpawn = cList.PersuasionSpawns[0].gameObject;
                }
                else if (randNum == 1)
                {
                    CardtoSpawn = Empty;
                }
                else
                {
                    CardtoSpawn = Empty;
                }
            }
            else
            {
                CardtoSpawn = Empty;
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
            removeCard();
            CardtoSpawn = Empty;
            oneTime = true;
        }
    }
    public void choseRandNum()
    {
        if (vSpeak.inSlot1.gameObject.name == "Card_S_Athletics(Clone)" || vSpeak.inSlot1.gameObject.name == "Card_S_Mobility(Clone)")
        {
            randNum = Mathf.Round(Random.Range(0, 3));
        }
        else
        {
            randNum = Mathf.Round(Random.Range(0, 2));
        }
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
    void removeCard()
    {
        if (vSpeak.inSlot1.gameObject.name == "Card_S_Athletics(Clone)")
        {
            if (cList.AthleticsSpawns.Count == 3)
            {
                if(randNum == 2)
                {
                    cList.AthleticsSpawns.RemoveAt(2);
                }
                if(randNum == 1)
                {
                    cList.AthleticsSpawns.RemoveAt(1);
                }
                if (randNum == 0)
                {
                    cList.AthleticsSpawns.RemoveAt(0);
                }
            }
            else if(cList.AthleticsSpawns.Count == 2)
            {
                if (randNum == 1)
                {
                    cList.AthleticsSpawns.RemoveAt(1);
                }
                if (randNum == 0)
                {
                    cList.AthleticsSpawns.RemoveAt(0);
                }
                else
                {
                    Debug.Log("Nothing Removed");
                }
            }
            else if (cList.AthleticsSpawns.Count == 1)
            {
                if (randNum == 0)
                {
                    cList.AthleticsSpawns.RemoveAt(0);
                }
                else
                {
                    Debug.Log("Nothing Removed");
                }
            }
            else
            {
                Debug.Log("Nothing Removed");
            }
        }
        if (vSpeak.inSlot1.gameObject.name == "Card_S_Mobility(Clone)")
        {
            if (cList.MobilitySpawns.Count == 3)
            {
                if (randNum == 2)
                {
                    cList.MobilitySpawns.RemoveAt(2);
                }
                if (randNum == 1)
                {
                    cList.MobilitySpawns.RemoveAt(1);
                }
                if (randNum == 0)
                {
                    cList.MobilitySpawns.RemoveAt(0);
                }
            }
            else if (cList.MobilitySpawns.Count == 2)
            {
                if (randNum == 1)
                {
                    cList.MobilitySpawns.RemoveAt(1);
                }
                if (randNum == 0)
                {
                    cList.MobilitySpawns.RemoveAt(0);
                }
                else
                {
                    Debug.Log("Nothing Removed");
                }
            }
            else if (cList.MobilitySpawns.Count == 1)
            {
                if (randNum == 0)
                {
                    cList.MobilitySpawns.RemoveAt(0);
                }
                else
                {
                    Debug.Log("Nothing Removed");
                }
            }
            else
            {
                Debug.Log("Nothing Removed");
            }
        }
        if (vSpeak.inSlot1.gameObject.name == "Card_S_Persuasion(Clone)")
        {
            if (cList.PersuasionSpawns.Count == 1)
            {
                if (randNum == 1)
                {
                    cList.PersuasionSpawns.RemoveAt(1);
                }
                if (randNum == 0)
                {
                    cList.PersuasionSpawns.RemoveAt(0);
                }
            }
            else if (cList.PersuasionSpawns.Count == 0)
            {
                if (randNum == 0)
                {
                    cList.PersuasionSpawns.RemoveAt(0);
                }
                else
                {
                    Debug.Log("Nothing Removed");
                }
            }
            else
            {
                Debug.Log("Nothing Removed");
            }
        }
    }
}
