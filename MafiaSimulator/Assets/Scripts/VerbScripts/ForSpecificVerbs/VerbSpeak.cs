using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbSpeak : MonoBehaviour
{
    private CardPositioning verbSpeak;
    private VerbTimer speakTimer;
    public GameObject LastinSnap;
    public Vector3 SpawnPoint;
    public bool cardInPos, OneTime, locked;
    public void Awake()
    {
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
            LastinSnap.transform.position = verbSpeak.SnapPosition;
        }
    }
}
