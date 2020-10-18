using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbSpeak : MonoBehaviour
{
    private CardPositioning verbSpeak;
    private VerbTimer speakTimer;
    public GameObject inSlot1, inSlot2, inSlot3, inSlot4, LastinSnap, Empty;
    public Vector3 SpawnPoint;
    public bool cardInPos, OneTime, locked;
    public void Awake()
    {
        inSlot1 = Empty;
        inSlot2 = Empty;
        inSlot3 = Empty;
        inSlot4 = Empty;
        verbSpeak = GetComponent<CardPositioning>();
        speakTimer = GetComponent<VerbTimer>();
        SpawnPoint = new Vector3(verbSpeak.SnapPosition.x, (verbSpeak.SnapPosition.y - 200f), verbSpeak.SnapPosition.z);
    }
    private void Update()
    {
        foreach (GameObject card in verbSpeak.Card)
        {
            if (card.transform.position == verbSpeak.SnapPosition)
            {
                cardInPos = true;
                if (speakTimer.currentState == VerbTimer.GameState.Start)
                {
                    speakTimer.timeLeft = card.GetComponent<CardTimer>().cardAsset.eTimer;
                    speakTimer.startTime = speakTimer.timeLeft;
                }
            }
            ///Tracking whichever card is in the slot
            ///Tracking card that is in Slot 1
            if (card.GetComponent<CardsInSlots>().sS1_Snap == true)
            {
                inSlot1 = card.gameObject;
            }
            if(inSlot1.GetComponent<CardsInSlots>().sS1_Snap == false)
            {
                inSlot1 = Empty;
            }
            ///Tracking card that is in Slot 2
            if (card.GetComponent<CardsInSlots>().sS2_Snap == true)
            {
                inSlot2 = card.gameObject;
            }
            if(inSlot2.GetComponent<CardsInSlots>().sS2_Snap == false)
            {
                inSlot2 = Empty;
            }
            ///Tracking card that is in Slot 3
            if (card.GetComponent<CardsInSlots>().sS3_Snap == true)
            {
                inSlot3 = card.gameObject;
            }
            if (inSlot3.GetComponent<CardsInSlots>().sS3_Snap == false)
            {
                inSlot3 = Empty;
            }
            ///Tracking card that is in Slot 4
            if (card.GetComponent<CardsInSlots>().sS4_Snap == true)
            {
                inSlot4 = card.gameObject;
            }
            if (inSlot4.GetComponent<CardsInSlots>().sS4_Snap == false)
            {
                inSlot4 = Empty;
            }
        }
        ///locking  of the card into positon during any state but start state///
        if (speakTimer.currentState != VerbTimer.GameState.Start)
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
            inSlot1.GetComponent<CardDragging>().dragging = false;
            inSlot2.GetComponent<CardDragging>().dragging = false;
            inSlot3.GetComponent<CardDragging>().dragging = false;
            inSlot4.GetComponent<CardDragging>().dragging = false;
        }
    }
}
