using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySpawner : MonoBehaviour
{
    private VerbTimer aTimer;
    private VerbAction vAction;
    [Header("Stuff for Spawning")]
    public GameObject cPrefab;
    public Vector3 SpawnPoint;
    public int RewardAmount;
    public bool OneTime;
    public AudioSource aSource;
    public AudioClip moneySound;
    private void Awake()
    {
        vAction = GetComponent<VerbAction>();
        aTimer = GetComponent<VerbTimer>();
        OneTime = true;
    }
    void Update()
    {
        RewardAmount = vAction.inSlot1.GetComponent<CardTimer>().cardAsset.CurrencyReward;
        if (!OneTime)
        {
            SpawnReward(RewardAmount);
        }
    }
    public void setOneTime()
    {
        if(aTimer.currentState == VerbTimer.GameState.reSet)
        {
           if(RewardAmount > 0)
            {
                aSource.PlayOneShot(moneySound);
            }    
           OneTime = false;
        }
    }
    public void SpawnReward(int Amount)
    {
        for(int i = 0; i < Amount; i ++)
        {
           
            Instantiate(cPrefab, SpawnPoint, Quaternion.identity);
            OneTime = true;
        }
    }
}
