using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbExplore : MonoBehaviour
{
    private CardPositioning verbExplore;
    private VerbTimer exploreTimer;
    public GameObject inSlot1, inSlot2, inSlot3, inSlot4, LastinSnap, Empty;
    public Vector3 SpawnPoint;
    public bool cardInPos, OneTime, locked;
    public void Awake()
    {
        inSlot1 = Empty;
        inSlot2 = Empty;
        inSlot3 = Empty;
        inSlot4 = Empty;
        verbExplore = GetComponent<CardPositioning>();
        exploreTimer = GetComponent<VerbTimer>();
        SpawnPoint = new Vector3(verbExplore.SnapPosition.x, (verbExplore.SnapPosition.y - 200f), verbExplore.SnapPosition.z);
    }
    private void Update()
    {
        foreach(GameObject card in verbExplore.Card)
        {
            if(card.transform.position == verbExplore.S1_Snap)
            {
                cardInPos = true;
                if(exploreTimer.currentState == VerbTimer.GameState.Start)
                {
                    exploreTimer.timeLeft = inSlot1.GetComponent<CardTimer>().cardAsset.eTimer;
                    exploreTimer.startTime = exploreTimer.timeLeft;
                }
            }
            
        }
   ///locking  of the card into positon during any state but start state///
        if(exploreTimer.currentState != VerbTimer.GameState.Start)
        {
            locked = true;
            verbExplore.locked = true;
        }
        else
        {
            locked = false;
            verbExplore.locked = false;
        }
///if i used a while loop, Unity crashed///
        if(locked == true)
        {
            inSlot1.GetComponent<CardDragging>().dragging = false;
            inSlot2.GetComponent<CardDragging>().dragging = false;
            inSlot3.GetComponent<CardDragging>().dragging = false;
            inSlot4.GetComponent<CardDragging>().dragging = false;
        }
    }
}
