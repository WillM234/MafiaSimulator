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
            ///tracking whichever card is in the slot
            ///Tracking card that is in slot 1
            if (card.GetComponent<CardsInSlots>().eS1_Snap == true)
            {
                inSlot1 = card.gameObject;
            }
            if (inSlot1.GetComponent<CardsInSlots>().eS1_Snap == false)
            {
                inSlot1 = Empty;
            }
            ///Tracking card that is in slot 2
            if (card.GetComponent<CardsInSlots>().eS2_Snap == true)
            {
                inSlot2 = card.gameObject;
            }
            if (inSlot1.GetComponent<CardsInSlots>().eS2_Snap == false)
            {
                inSlot2 = Empty;
            }
            ///Tracking card that is in slot 3
            if (card.GetComponent<CardsInSlots>().eS3_Snap == true)
            {
                inSlot3 = card.gameObject;
            }
            if (inSlot3.GetComponent<CardsInSlots>().eS3_Snap == false)
            {
                inSlot3 = Empty;
            }
            ///Tracking card that is in slot 4
            if (card.GetComponent<CardsInSlots>().eS4_Snap == true)
            {
                inSlot4 = card.gameObject;
            }
            if (inSlot4.GetComponent<CardsInSlots>().eS4_Snap == false)
            {
                inSlot4 = Empty;
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
