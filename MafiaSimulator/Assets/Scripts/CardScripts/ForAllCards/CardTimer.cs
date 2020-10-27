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
    private bool removed;
    public CardAsset cardAsset;
    public Vector3 CardPos;
    #region Script References
    private AngryFamilyTracking AFamTracking;
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
    #endregion
private void Awake()
    {///References to other scripts being used by this script, there are a lot of them///
        AFamTracking = GameObject.Find("NarrativeController").GetComponent<AngryFamilyTracking>();
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

        }
  ///other stuff being updated constantly///
        ///card text updates///
        if (cardAsset.Aspect_Action == true || cardAsset.Aspect_Opportunity == true)
        {
            countDown.text = ("" + timeLeft);
        }
        else
            countDown.text = "";
        //What happens when card is deactivated
            if(timeLeft <= 0)
            {
               currentState = GameState.DeactiveState;
            }
            if(currentState == GameState.DeactiveState)
            {
            //stuff that happens during Deactived State, only for Opportunity Cards///
                if(cardAsset.Aspect_Opportunity == true)
                {
                    if(gameObject.name == "Card_O_TheRecruiter(Clone)")
                        {
                        N_Control.DidntJoinFamily = true;
                        N_Control.Decision1Made = true;
                        }
                    if(gameObject.name == "Card_O_ShadyDeal(Clone)")
                        {
                        N_Control.refusedDeal = true;
                        N_Control.Decision1Made = true;
                        }
                    if(gameObject.name == "Card_O_RaidRival(Clone)")
                        {
                        //AFamTracking.SetOneTime();
                        N_Control.Decision2Made = true;
                        }
                    if(gameObject.name == "Card_O_AssassinateRDon(Clone)")
                        {
                        //AFamTracking.SetOneTime();
                        N_Control.Decision3Made = true;
                        }
                    if (gameObject.name == "Card_O_BecomeDon(Clone)")
                        {
                        N_Control.BecameImportant_toFamily = true;
                        N_Control.Decision4Made = true;
                        }
                    removeFromLists();
                    if (removed)
                    {
                    Destroy(gameObject);
                    }
                }
                if(cardAsset.Aspect_Place == true)
                {
                if(gameObject.name == "Card_P_TheDocks(Clone)")
                    {
                    N_Control.raidFinished = true;
                    }
                removeFromLists();
                if (removed)
                {
                    Destroy(gameObject);
                }  
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
//removing cards from lists
void removeFromLists()
    {
        currentCurrency.Currency.Remove(gameObject);
        TPasses.Card.Remove(gameObject);
        VerbA.Card.Remove(gameObject);
        VerbE.Card.Remove(gameObject);
        VerbI.Card.Remove(gameObject);
        VerbS.Card.Remove(gameObject);
        removed = true;
    }
}