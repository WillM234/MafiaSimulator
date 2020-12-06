using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsInSlots : MonoBehaviour
{
    #region Script References
    private PlayerActions pActions;
    private CardAsset cAsset;
    private CardTimer cTimer;
    private CardPositioning VerbA, VerbE, VerbI, VerbS, TPasses;
    private VerbAction vAction;
    private VerbExplore vExplore;
    private VerbInvestigate vInvest;
    private VerbSpeak vSpeak;
    private TimePasses T_Pass;
    private SlotAreaController aSlot_Control,eSlot_Control,iSlot_Control,sSlot_Control;
    #endregion
    #region Positioning Flags
    [Header("Action Verb Slots")]
    public bool aS1_Snap;
    public bool aS2_Snap;
    public bool aS3_Snap;
    public bool aS4_Snap;
    [Header("Explore Verb  Slots")]
    public bool eS1_Snap;
    public bool eS2_Snap;
    public bool eS3_Snap;
    public bool eS4_Snap;
    [Header("Investigate Verb Slots")]
    public bool iS1_Snap;
    public bool iS2_Snap;
    public bool iS3_Snap;
    public bool iS4_Snap;
    [Header("Speak Verb Slots")]
    public bool sS1_Snap;
    public bool sS2_Snap;
    public bool sS3_Snap;
    public bool sS4_Snap;
    [Header("In Time Passes Slot")]
    public bool in_tSnap;
    #endregion
    #region other Things
    public GameObject empty;
    private Vector3 cardPos;
    public AudioClip rightSlot;
    public AudioClip wrongSlot;
    public AudioSource aSource;
    #endregion
    private void Awake()
    {
        #region Script references
        //references for scripts
        //references for lists scripts, used for checking/snapping to position
        VerbA = GameObject.Find("Verb_Action").GetComponent<CardPositioning>();
        VerbE = GameObject.Find("Verb_Explore").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("Verb_Investigate").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("Verb_Speak").GetComponent<CardPositioning>();
        TPasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        //Verb script references, used for puttin cards into LastInSlot/InSlot
        vAction = GameObject.Find("Verb_Action").GetComponent<VerbAction>();
        vExplore = GameObject.Find("Verb_Explore").GetComponent<VerbExplore>();
        vInvest = GameObject.Find("Verb_Investigate").GetComponent<VerbInvestigate>();
        vSpeak = GameObject.Find("Verb_Speak").GetComponent<VerbSpeak>();
        T_Pass = GameObject.Find("TimePasses").GetComponent<TimePasses>();
        //references for SlotAreaController
        aSlot_Control = GameObject.Find("Verb_Action").GetComponent<SlotAreaController>();
        eSlot_Control = GameObject.Find("Verb_Explore").GetComponent<SlotAreaController>();
        iSlot_Control = GameObject.Find("Verb_Investigate").GetComponent<SlotAreaController>();
        sSlot_Control = GameObject.Find("Verb_Speak").GetComponent<SlotAreaController>();
        //reference to PlayerActions Script
        pActions = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        //reference for card timer, used to change gamestate of the card
        cTimer = GetComponent<CardTimer>();
        cAsset = cTimer.cardAsset;
        //reference for the audio source
        aSource = GetComponent<AudioSource>();
        ///finding the gameObject for Empty
        empty = GameObject.Find("emptyCard");
        #endregion
    }
    void Update()
    {
        //tracking card position
        cardPos = transform.position;
        //while the game is not paused, things happen
        if(pActions.currentState == PlayerActions.GameState.Active)
        {
            #region Flaging which slot the card is in
        ///if the card is in any of Action Verb's slots while the object is active
            if(aSlot_Control.sAreaActive == true)
            {
                //if the card's position is in Slot 1
                if (cardPos == VerbA.S1_Snap)
                {
                    aS1_Snap = true;//true if in slot 1 snap
                }
                else
                {
                    aS1_Snap = false;//otherwise it is not in slot 1 snap
                }
                //if the card's position is in Slot 2
                if (cardPos == VerbA.S2_Snap)
                {
                    aS2_Snap = true;//true if in slot 2 snap
                }
                else
                {
                    aS2_Snap = false;//otherwise it is not in slot 2 snap
                }
                //if the card's position is in Slot 3
                if (cardPos == VerbA.S3_Snap)
                {
                    aS3_Snap = true;//true if in slot 3 snap
                }
                else
                {
                    aS3_Snap = false;//otherwise it is not in slot 3 snap
                }
                //if the card's position is in Slot 4
                if (cardPos == VerbA.S4_Snap)
                {
                    aS4_Snap = true;//true if in slot 4 snap
                }
                else
                {
                    aS4_Snap = false;//otherwise it is not in slot 4 snap
                }
            }
        ///if the card is in any of Explore Verb's slots while the object is active
            if (eSlot_Control.sAreaActive == true)
            {
                //if the card's position is in Slot 1
                if (cardPos == VerbE.S1_Snap)
                {
                    eS1_Snap = true;//true if in slot 1 snap
                }
                else
                {
                    eS1_Snap = false;//otherwise it is not in slot 1 snap
                }
                //if the card's position is in Slot 2
                if (cardPos == VerbE.S2_Snap)
                {
                    eS2_Snap = true;//true if in slot 2 snap
                }
                else
                {
                    eS2_Snap = false;//otherwise it is not in slot 2 snap
                }
                //if the card's position is in Slot 3
                if (cardPos == VerbE.S3_Snap)
                {
                    eS3_Snap = true;//true if in slot 3 snap
                }
                else
                {
                    eS3_Snap = false;//otherwise it is not in slot 3 snap
                }
                //if the card's position is in Slot 4
                if (cardPos == VerbE.S4_Snap)
                {
                    eS4_Snap = true;//true if in slot 4 snap
                }
                else
                {
                    eS4_Snap = false;//otherwise it is not in slot 4 snap
                }
            }
        ///if the card is in any of Investigate Verb's slots while the object is active
            if (iSlot_Control.sAreaActive == true)
            {
                //if the card's position is in Slot 1
                if (cardPos == VerbI.S1_Snap)
                {
                    iS1_Snap = true;//true if in slot 1 snap
                }
                else
                {
                    iS1_Snap = false;//otherwise it is not in slot 1 snap
                }
                //if the card's position is in Slot 2
                if (cardPos == VerbI.S2_Snap)
                {
                    iS2_Snap = true;//true if in slot 2 snap
                }
                else
                {
                    iS2_Snap = false;//otherwise it is not in slot 2 snap
                }
                //if the card's position is in Slot 3
                if (cardPos == VerbI.S3_Snap)
                {
                    iS3_Snap = true;//true if in slot 3 snap
                }
                else
                {
                    iS3_Snap = false;//otherwise it is not in slot 3 snap
                }
                //if the card's position is in Slot 4
                if (cardPos == VerbI.S4_Snap)
                {
                    iS4_Snap = true;//true if in slot 4 snap
                }
                else
                {
                    iS4_Snap = false;//otherwise it is not in slot 4 snap
                }
            }
        ///if the card is in any of Speak Verb's slots while the object is active
            if(sSlot_Control.sAreaActive == true)
            {
                //if the card's position is in Slot 1
                if (cardPos == VerbS.S1_Snap)
                {
                    sS1_Snap = true;//true if in slot 1 snap
                }
                else
                {
                    sS1_Snap = false;//otherwise it is not in slot 1 snap
                }
                //if the card's position is in Slot 2
                if (cardPos == VerbS.S2_Snap)
                {
                    sS2_Snap = true;//true if in slot 2 snap
                }
                else
                {
                    sS2_Snap = false;//otherwise it is not in slot 2 snap
                }
                //if the card's position is in Slot 3
                if (cardPos == VerbS.S3_Snap)
                {
                    sS3_Snap = true;//true if in slot 3 snap
                }
                else
                {
                    sS3_Snap = false;//otherwise it is not in slot 3 snap
                }
                //if the card's position is in Slot 4
                if (cardPos == VerbS.S4_Snap)
                {
                    sS4_Snap = true;//true if in slot 4 snap
                }
                else
                {
                    sS4_Snap = false;//otherwise it is not in slot 4 snap
                }
            }
        ///if the card's position is in TimePasses Slot
             if(cardPos == TPasses.SnapPosition)
            {
                in_tSnap = true;//true if in slot snap
            }
             else
            {
                in_tSnap = false;//otherwise it is not in slot snap
            }
            #endregion
            #region Other things being updated
            if ((aS1_Snap || aS2_Snap || aS3_Snap || aS4_Snap) || (eS1_Snap || eS2_Snap || eS3_Snap || eS4_Snap) || (iS1_Snap || iS2_Snap || iS3_Snap || iS4_Snap) || (sS1_Snap || sS2_Snap || sS3_Snap || sS4_Snap) || in_tSnap)
            {
                cTimer.currentState = CardTimer.GameState.PauseState;
            }
            else
            {
                cTimer.currentState = CardTimer.GameState.ActiveState;
            }
            #endregion
            #region checks slot flags, then plays Sound Effects
            if (cAsset.Aspect_Action == true)
            {
                if (aS1_Snap == true)
                {
                    
                    rightSlotSound(1);
                }
                else if (aS2_Snap == true || aS3_Snap == true || aS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (iS1_Snap == true || iS2_Snap == true || iS3_Snap == true || iS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (sS1_Snap == true || sS2_Snap == true || sS3_Snap == true || sS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (in_tSnap == true)
                {
                    wrongSlotSound(1);
                }
            }
            else if(cAsset.Aspect_Person == true)
            {
                if (aS2_Snap == true || aS3_Snap == true || aS4_Snap == true)
                {
                    rightSlotSound(1);
                }
                else if (iS2_Snap == true || iS3_Snap == true || iS4_Snap == true)
                {
                    rightSlotSound(1);
                }
                else if (sS1_Snap == true || sS2_Snap == true || sS3_Snap == true || sS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (aS1_Snap == true || iS1_Snap == true || in_tSnap == true)
                {
                    wrongSlotSound(1);
                }
            }
            else if(cAsset.Aspect_Skill == true)
            {
                if (sS1_Snap == true)
                {
                    rightSlotSound(1);
                }
                else if (aS1_Snap == true || aS2_Snap == true || aS3_Snap == true || aS4_Snap == true)
                {
                    rightSlotSound(1);
                }
                else if (iS2_Snap == true || iS3_Snap == true || iS4_Snap == true)
                {
                    rightSlotSound(1);
                }
                else if (in_tSnap == true || iS1_Snap == true || sS2_Snap == true || sS3_Snap == true || sS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
            }
            else if(cAsset.Aspect_Place == true)
            {
                if (iS1_Snap == true)
                {
                    rightSlotSound(1);
                }
                else if (iS2_Snap == true || iS3_Snap == true || iS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (aS1_Snap == true || aS2_Snap == true || aS3_Snap == true || aS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (in_tSnap == true || sS1_Snap == true || sS2_Snap == true || sS3_Snap == true || sS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
            }
            else if(cAsset.Aspect_Opportunity == true)
            {
                if (aS1_Snap == true)
                {
                    rightSlotSound(1);
                }
                else if (aS2_Snap == true || aS3_Snap == true || aS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (iS1_Snap == true || iS2_Snap == true || iS3_Snap == true || iS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (in_tSnap == true || sS1_Snap == true || sS2_Snap == true || sS3_Snap == true || sS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
            }
            else if(cAsset.Aspect_Ingredient == true)
            {
                if (in_tSnap == true)
                {
                    //rightSlotSound(1);
                }
                else if (sS1_Snap == true || sS2_Snap == true || sS3_Snap == true || sS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (iS1_Snap == true || iS2_Snap == true || iS3_Snap == true || iS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
                else if (aS1_Snap == true || aS2_Snap == true || aS3_Snap == true || aS4_Snap == true)
                {
                    wrongSlotSound(1);
                }
            }
            #endregion
        }
        void rightSlotSound(int times)
        {
            for(int i = 0; i < times; i++)
            {
                //Debug.Log("Played Right Sound");
                aSource.PlayOneShot(rightSlot);
            }
        }
        void wrongSlotSound(int times)
        {
            for(int i = 0; i < times; i++)
            {
                //Debug.Log("Played Wrong Sound");
                aSource.PlayOneShot(wrongSlot);
            }
        }
    }
}