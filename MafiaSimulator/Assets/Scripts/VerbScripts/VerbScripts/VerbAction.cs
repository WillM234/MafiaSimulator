using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbAction : MonoBehaviour
{
    private CardPositioning verbAction;
    private VerbTimer actionTimer;
    public GameObject CurrencyPrefab;
    public Vector3 SpawnPoint;
    public int rewardAmount;
    public bool cardInPos, OneTime;
    public void Awake()
    {
        verbAction = GetComponent<CardPositioning>();
        actionTimer = GetComponent<VerbTimer>();
        SpawnPoint = new Vector3(verbAction.SnapPosition.x, (verbAction.SnapPosition.y - 100f), verbAction.SnapPosition.z);
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
                    actionTimer.timeLeft = card.GetComponent<CardTimer>().cardAsset.Timer;
                    actionTimer.startTime = actionTimer.timeLeft;
                }
            }
        }
        if (actionTimer.timeLeft > 0)
        {
            OneTime = false;
        }
        if (actionTimer.timeLeft <= 0)
        {
            if (!OneTime)
            { SpawnReward(rewardAmount); }
        }
    }
    public void SpawnReward(int amount)
    {
        for(int i = 0; i < amount; i ++)
        {
            Instantiate(CurrencyPrefab, SpawnPoint, Quaternion.identity);
            OneTime = true;
        }
    }
}
