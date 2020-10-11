using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardTimer : MonoBehaviour
{
    #region Timer
    public float timeLeft, currentTime;
    public Text countDown;
    public bool setTimer;
    private UIButtonControl ButtonControl;
    #endregion
    #region CardState
    public enum GameState {ActiveState, PauseState, DeactiveState};
    public GameState currentState;
    private PlayerActions Player_A;
    #endregion
    [Header("Input Card Asset Here")]
    public CardAsset cardAsset;
    public Vector3 CardPos;
    public bool in_aSnap, in_tSnap, in_eSnap, in_sSnap, in_iSnap, InsertOnce;
    private NarrativeController N_Control;
    private VerbAutoTimer AutoTimer;
    private CardToLists cardLists;
    private TimePasses T_Pass;
    private CardPositioning VerbA, VerbE, VerbI, VerbS, TPasses;
    private VerbAction vAction;
    private VerbExplore vExplore;
    private VerbInvestigate vInvestigate;
    private VerbSpeak vSpeak;
    private CurrencyList currentCurrency;
    private void Awake()
    {///References to other scripts being used by this script, there are a lot of them///
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        AutoTimer = GameObject.Find("TimePasses").GetComponent<VerbAutoTimer>();
        Player_A = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        ButtonControl = GameObject.Find("MainCamera").GetComponent<UIButtonControl>();
        cardLists = GetComponent<CardToLists>();
        ///references for list scripts///
        currentCurrency = GameObject.Find("NarrativeController").GetComponent<CurrencyList>();
        VerbA = GameObject.Find("Verb_Action").GetComponent<CardPositioning>();
        VerbE = GameObject.Find("Verb_Explore").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("Verb_Investigate").GetComponent <CardPositioning>();
        VerbS = GameObject.Find("Verb_Speak").GetComponent<CardPositioning>();
        TPasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        ///references for each individual Verb Script///
        T_Pass = GameObject.Find("TimePasses").GetComponent<TimePasses>();
        vAction = GameObject.Find("Verb_Action").GetComponent<VerbAction>();
        vExplore = GameObject.Find("Verb_Explore").GetComponent<VerbExplore>();
        vInvestigate = GameObject.Find("Verb_Investigate").GetComponent<VerbInvestigate>();
        vSpeak = GameObject.Find("Verb_Speak").GetComponent<VerbSpeak>();
        ///setting state to Active on wake, mainly for instaniations///
        currentState = GameState.ActiveState;
        if (T_Pass.cardInSnap == false && cardAsset.is_Currency == true)
        {
            currentCurrency.Currency[0].GetComponent<Transform>().position = TPasses.SnapPosition;
        }
    }
    void Start()
    {
                StartCoroutine("LoseTimer");
                Time.timeScale = 1;
    }
    void Update()
    {
        //tracking card Position
        CardPos = transform.position;
        ///Switching States when game is fully paused or not fully paused///
        if(Player_A.currentState == PlayerActions.GameState.Paused)
        {
            currentState = GameState.PauseState;
        }
        if(Player_A.currentState == PlayerActions.GameState.Active)
        {
 ///flagging if card is in any of the snap positions, this should be rechecked in the future for redundencies///
            if (CardPos != VerbA.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Action == true || cardAsset.Aspect_Opportunity))
                in_aSnap = false;
            if (CardPos != VerbS.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Person == true))
                in_sSnap = false;
            if (CardPos != VerbE.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Place == true || cardAsset.Aspect_Opportunity))
                in_eSnap = false;
            if (CardPos != VerbI.SnapPosition && (cardAsset.Aspect_Place == true || cardAsset.Aspect_Person == true))
                in_iSnap = false;
            if (CardPos != TPasses.SnapPosition)
                in_tSnap = false;
            if (CardPos == VerbA.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Action == true || cardAsset.Aspect_Opportunity))
                {in_aSnap = true;
                 in_iSnap = false;
                 in_sSnap = false;
                 in_eSnap = false;
                 in_tSnap = false;}
            if (CardPos == VerbS.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Person == true))
                {in_aSnap = false;
                 in_iSnap = false;
                 in_sSnap = true;
                 in_eSnap = false;
                 in_tSnap = false;}
            if (CardPos == VerbE.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Place == true || cardAsset.Aspect_Opportunity))
                {in_aSnap = false;
                 in_iSnap = false;
                 in_sSnap = false;
                 in_eSnap = true;
                 in_tSnap = false;}
            if(CardPos == VerbI.SnapPosition && (cardAsset.Aspect_Place == true || cardAsset.Aspect_Person == true))
                {in_aSnap = false;
                 in_iSnap = true;
                 in_sSnap = false;
                 in_eSnap = false;
                 in_tSnap = false;
                }
            if(CardPos == TPasses.SnapPosition)
                {in_aSnap = false;
                 in_iSnap = false;
                 in_sSnap = false;
                 in_eSnap = false;
                 in_tSnap = true;}
  ///Stopping card timer countdown if positoned in one of the snap slots///
            if (in_aSnap || in_sSnap|| in_eSnap||in_tSnap||in_iSnap)
                    currentState = GameState.PauseState;
            else if (!in_aSnap && !in_sSnap && !in_eSnap && !in_tSnap && !in_iSnap)
                    currentState = GameState.ActiveState;
  ///Making sure the cards aren't removed if the timer is active on the regular verbs, or at least snap back if they were the last one to be there///
            ///For Verb_Action///
            if (in_aSnap)
            {
                vAction.LastinSnap = gameObject;
            }
            ///For Verb_Explore///
            if(in_eSnap)
            {
                vExplore.LastinSnap = gameObject;
            }
            ///For Verb_Investigate///
            if (in_iSnap)
            {
                vInvestigate.LastinSnap = gameObject;
            }
            ///For Verb_Speak///
            if(in_sSnap)
            {
                vSpeak.LastinSnap = gameObject;
            }
        }
  ///other stuff being updated constantly///
        ///card text updates///
        if (cardAsset.Aspect_Action == true || cardAsset.Aspect_Opportunity == true)
        {
            countDown.text = ("" + timeLeft);
        }
        else
            countDown.text = "";
        ///not in use currently///
            if(timeLeft <= 0)
            {
               currentState = GameState.DeactiveState;
            }
            if(currentState == GameState.DeactiveState)
            {
                if(cardAsset.Aspect_Opportunity == true)
                {
                    N_Control.Decision1Made = true;
                    Destroy(gameObject);
                }
            }
    }
///coroutine for the timer///
    IEnumerator LoseTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if (cardAsset.Aspect_Action == true || cardAsset.Aspect_Opportunity == true)
            {
                if (currentState == GameState.ActiveState)
                {
                    if (ButtonControl.FastForwardClicked == true)
                    {
                        timeLeft -= 2;
                    }
                    if (ButtonControl.NormalClicked == true)
                    {
                        timeLeft -= 1;
                    }
                    if (ButtonControl.PauseClicked == true)
                    {
                        timeLeft -= 0;
                    }
                }
                if (currentState == GameState.PauseState)
                {
                    timeLeft -= 0;
                }
            }
        }
    }
}