using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbInvestigate : MonoBehaviour
{
    private CardPositioning verbInvestigate;
    private VerbTimer investigateTimer;
    public GameObject inSlot1, inSlot2, inSlot3, inSlot4, LastinSnap, Empty;
    public Vector3 SpawnPoint;
    public bool cardInPos, OneTime, locked;
    public void Awake()
    {
        inSlot1 = Empty;
        inSlot2 = Empty;
        inSlot3 = Empty;
        inSlot4 = Empty;
        verbInvestigate = GetComponent<CardPositioning>();
        investigateTimer = GetComponent<VerbTimer>();
        SpawnPoint = new Vector3(verbInvestigate.SnapPosition.x, (verbInvestigate.SnapPosition.y - 200f), verbInvestigate.SnapPosition.z);
    }
    private void Update()
    {
        #region for every card in Investigate's Card List
        foreach (GameObject card in verbInvestigate.Card)
        {
            if (card.transform.position == verbInvestigate.S1_Snap)
            {
                cardInPos = true;
                if (investigateTimer.currentState == VerbTimer.GameState.Start)
                {
                    investigateTimer.timeLeft = inSlot1.GetComponent<CardTimer>().cardAsset.iTimer;
                    investigateTimer.startTime = investigateTimer.timeLeft;
                }
            }
            ///tracking whichever card is in the slot
            ///Tracking card that is in slot 1
            if (card.GetComponent<CardsInSlots>().iS1_Snap == true)
            {
                inSlot1 = card.gameObject;
            }
            if (inSlot1.GetComponent<CardsInSlots>().iS1_Snap == false)
            {
                inSlot1 = Empty;
            }
            ///Tracking card that is in slot 2
            if (card.GetComponent<CardsInSlots>().iS2_Snap == true)
            {
                inSlot2 = card.gameObject;
            }
            if (inSlot2.GetComponent<CardsInSlots>().iS2_Snap == false)
            {
                inSlot2 = Empty;
            }
            ///Tracking card that is in slot 3
            if (card.GetComponent<CardsInSlots>().iS3_Snap == true)
            {
                inSlot3 = card.gameObject;
            }
            if (inSlot3.GetComponent<CardsInSlots>().iS3_Snap == false)
            {
                inSlot3 = Empty;
            }
            ///Tracking card that is in slot 4
            if (card.GetComponent<CardsInSlots>().iS4_Snap == true)
            {
                inSlot4 = card.gameObject;
            }
            if (inSlot4.GetComponent<CardsInSlots>().iS4_Snap == false)
            {
                inSlot4 = Empty;
            }
        }
        #endregion
        ///locking  of the card into positon during any state but start state///
        if (investigateTimer.currentState != VerbTimer.GameState.Start)
        {
            locked = true;
            verbInvestigate.locked = true;
        }
        else
        {
            locked = false;
            verbInvestigate.locked = false;
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
