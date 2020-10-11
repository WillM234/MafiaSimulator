using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbExplore : MonoBehaviour
{
    private CardPositioning verbExplore;
    private VerbTimer exploreTimer;
    public GameObject LastinSnap;
    public Vector3 SpawnPoint;
    public bool cardInPos, OneTime, locked;
    public void Awake()
    {
        verbExplore = GetComponent<CardPositioning>();
        exploreTimer = GetComponent<VerbTimer>();
        SpawnPoint = new Vector3(verbExplore.SnapPosition.x, (verbExplore.SnapPosition.y - 200f), verbExplore.SnapPosition.z);
    }
    private void Update()
    {
        foreach(GameObject card in verbExplore.Card)
        {
            if(card.transform.position == verbExplore.SnapPosition)
            {
                cardInPos = true;
                if(exploreTimer.currentState == VerbTimer.GameState.Start)
                {
                    exploreTimer.timeLeft = card.GetComponent<CardTimer>().cardAsset.eTimer;
                    exploreTimer.startTime = exploreTimer.timeLeft;
                }
            }
        }
   ///locking  of the card into positon during any state but start state///
        if(exploreTimer.currentState != VerbTimer.GameState.Start)
        {
            locked = true;
        }
        else
        {
            locked = false;
        }
///if i used a while loop, Unity crashed///
        if(locked == true)
        {
            LastinSnap.transform.position = verbExplore.SnapPosition;
        }
    }
}
