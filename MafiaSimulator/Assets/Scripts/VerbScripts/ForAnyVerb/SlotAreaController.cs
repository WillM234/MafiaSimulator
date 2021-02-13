﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotAreaController : MonoBehaviour
{
    #region Script References
    private VerbAction vAction;
    private VerbInvestigate vInvest;
    private VerbSpeak vSpeak;
    private TimePasses tPass;
    private CardPositioning VerbA, VerbE, VerbI, VerbS, TPasses;
    #endregion
    #region Other Stuff
    [Header("Set in Inspector")]
    public GameObject slotArea;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;
    public AudioSource aSource;
    public AudioClip buttonClick;
    public bool sAreaActive;
    public bool slot2Active;
    public bool slot3Active;
    public bool slot4Active;
    #endregion
    private void Awake()
    {
        #region Script references
        //references for scripts
        //references for lists scripts, used for checking/snapping to position
        VerbA = GameObject.Find("ActionButton").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("InvestigateButton").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("SpeakButton").GetComponent<CardPositioning>();
        TPasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        //references to individual verb scripts
        vAction = GameObject.Find("ActionButton").GetComponent<VerbAction>();
        vInvest = GameObject.Find("InvestigateButton").GetComponent<VerbInvestigate>();
        vSpeak = GameObject.Find("SpeakButton").GetComponent<VerbSpeak>();
        #endregion
    }
    void Update()
    {
    //stuff that happens only of this gameObject's name is Verb_Action
        if (gameObject.name == "ActionButton")
        {
            foreach (GameObject card in VerbA.Card)
            {
                if (vAction.inSlot1 != vAction.Empty)
                {
                    if (vAction.inSlot1.GetComponent<CardTimer>().cardAsset.aSlotsNeeded == 2)
                    {
                        slot2Active = true;
                    }
                    if (vAction.inSlot1.GetComponent<CardTimer>().cardAsset.aSlotsNeeded == 3)
                    {
                        slot2Active = true;
                        slot3Active = true;
                    }
                    if (vAction.inSlot1.GetComponent<CardTimer>().cardAsset.aSlotsNeeded == 4)
                    {
                        slot2Active = true;
                        slot3Active = true;
                        slot4Active = true;
                    }
                }
                else
                {
                    slot2Active = false;
                    slot3Active = false;
                    slot4Active = false;
                }
            }
        }
    //stuff that happens only of this gameObject's name is Verb_Investigate
        if (gameObject.name == "InvestigateButton")
        {
            foreach (GameObject card in VerbI.Card)
            {
                if (vInvest.inSlot1 != vInvest.Empty)
                {
                    if (vInvest.inSlot1.GetComponent<CardTimer>().cardAsset.iSlotsNeeded == 2)
                    {
                        slot2Active = true;
                    }
                    if (vInvest.inSlot1.GetComponent<CardTimer>().cardAsset.iSlotsNeeded == 3)
                    {
                        slot2Active = true;
                        slot3Active = true;
                    }
                    if (vInvest.inSlot1.GetComponent<CardTimer>().cardAsset.iSlotsNeeded == 4)
                    {
                        slot2Active = true;
                        slot3Active = true;
                        slot4Active = true;
                    }
                }
                else
                {
                    slot2Active = false;
                    slot3Active = false;
                    slot4Active = false;
                }
            }
        }
    //stuff that happens only of this gameObject's name is Verb_Speak
        if (gameObject.name == "SpeakButton")
        {
            foreach(GameObject card in VerbS.Card)
            {
                if(vSpeak.inSlot1 != vSpeak.Empty)
                {
                    if (vSpeak.inSlot1.GetComponent<CardTimer>().cardAsset.sSlotsNeeded == 2)
                    {
                        slot2Active = true;
                    }
                    if (vSpeak.inSlot1.GetComponent<CardTimer>().cardAsset.sSlotsNeeded == 3)
                    {
                        slot2Active = true;
                        slot3Active = true;
                    }
                    if(vSpeak.inSlot1.GetComponent<CardTimer>().cardAsset.sSlotsNeeded == 4)
                    {
                        slot2Active = true;
                        slot3Active = true;
                        slot4Active = true;
                    }
                }
                else
                {
                    slot2Active = false;
                    slot3Active = false;
                    slot4Active = false;
                }
            }
        }
    //setting area and slots active or deactive
    //slot area active
    if(sAreaActive)
        {
            slotArea.SetActive(true);
            if(gameObject.name == "ActionButton")
            {
                vAction.inSlot1.SetActive(true);
                vAction.inSlot2.SetActive(true);
                vAction.inSlot3.SetActive(true);
                vAction.inSlot4.SetActive(true);
            }
            if(gameObject.name == "InvestigateButton")
            {
                vInvest.inSlot1.SetActive(true);
                vInvest.inSlot2.SetActive(true);
                vInvest.inSlot3.SetActive(true);
                vInvest.inSlot4.SetActive(true);
            }
            if(gameObject.name == "SpeakButton")
            {
                vSpeak.inSlot1.SetActive(true);
                vSpeak.inSlot2.SetActive(true);
                vSpeak.inSlot3.SetActive(true);
                vSpeak.inSlot4.SetActive(true);
            }  
        }
    //slot area deactive
    else if(!sAreaActive)
        {
            slotArea.SetActive(false);
            if (gameObject.name == "ActionButton")
            {
                vAction.inSlot1.SetActive(false);
                vAction.inSlot2.SetActive(false);
                vAction.inSlot3.SetActive(false);
                vAction.inSlot4.SetActive(false);
            } 
            if (gameObject.name == "InvestigateButton")
            {
                vInvest.inSlot1.SetActive(false);
                vInvest.inSlot2.SetActive(false);
                vInvest.inSlot3.SetActive(false);
                vInvest.inSlot4.SetActive(false);
            }
            if (gameObject.name == "SpeakButton")
            {
                vSpeak.inSlot1.SetActive(false);
                vSpeak.inSlot2.SetActive(false);
                vSpeak.inSlot3.SetActive(false);
                vSpeak.inSlot4.SetActive(false);
            }
        }
    //slot 2 active
    if(slot2Active)
        {
            Slot2.SetActive(true);
        }
    //slot 2 deactive
    else
        {
            Slot2.SetActive(false);
        }
    //slot 3 active
    if (slot3Active)
        {
            Slot3.SetActive(true);
        }
    //slot 2 deactive
    else
        {
            Slot3.SetActive(false);
        }
    //slot 4 active
    if (slot4Active)
        {
            Slot4.SetActive(true);
        }
    //slot 4 deactive
    else
        {
            Slot4.SetActive(false);
        }
    }
    public void activateSlotArea()
    {
        sAreaActive = true;
        aSource.PlayOneShot(buttonClick);
        
    }
    public void deactivateSlotArea()
    {
        slot2Active = false;
        slot3Active = false;
        slot4Active = false;
        sAreaActive = false;
    }
}
