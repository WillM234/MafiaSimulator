using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbInvestigate : MonoBehaviour
{
    private CardPositioning verbInvestigate;
    private VerbTimer investigateTimer;
    public GameObject LastinSnap;
    public Vector3 SpawnPoint;
    public bool cardInPos, OneTime, locked;
    public void Awake()
    {
        verbInvestigate = GetComponent<CardPositioning>();
        investigateTimer = GetComponent<VerbTimer>();
        SpawnPoint = new Vector3(verbInvestigate.SnapPosition.x, (verbInvestigate.SnapPosition.y - 200f), verbInvestigate.SnapPosition.z);
    }
    private void Update()
    {
        #region for every card in Investigate's Card List
        foreach (GameObject card in verbInvestigate.Card)
        {
            if (card.transform.position == verbInvestigate.SnapPosition)
            {
                cardInPos = true;
                if (investigateTimer.currentState == VerbTimer.GameState.Start)
                {
                    investigateTimer.timeLeft = card.GetComponent<CardTimer>().cardAsset.eTimer;
                    investigateTimer.startTime = investigateTimer.timeLeft;
                }
            }
        }
        #endregion
        ///locking  of the card into positon during any state but start state///
        if (investigateTimer.currentState != VerbTimer.GameState.Start)
        {
            locked = true;
        }
        else
        {
            locked = false;
        }
        ///if i used a while loop, Unity crashed///
        if (locked == true)
        {
            LastinSnap.transform.position = verbInvestigate.SnapPosition;
        }
    }
}
