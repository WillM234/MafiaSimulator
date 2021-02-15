using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VerbTimer : MonoBehaviour
{
    #region Timer Stuff
    [Header("Timer Stuff")]
    public float timeLeft;
    public float startTime;
    public AudioSource aSource;
    public AudioClip TimesUp;
    //public Text countDown;
    public TMP_Text countDown;
    public UIButtonControl ButtonControl;
    #endregion
    #region GameState Stuff
    [Header("GamesState Stuff")]
    private PlayerActions Player_A;
    public enum GameState {Start,Active,Paused,ReadyToCollect, reSet}
    public GameState currentState, lastState;
    public bool SetLastState,setCurrentState,OneTime;
    #endregion
    #region Collection Stuff
    [Header("collection Stuff")]
    public Button button;
    public TMP_Text buttonText;
    private VerbAction vAction;
    private VerbInvestigate vInvest;
    private NarrativeController N_Control;
    private JoinedFamilyController jFam_Control;
    private MoleRouteController mRouteControl;
    private AgressiveCustomFamily cAgroFamControl;
    private SpeakSkills sSkills;
    #endregion
    private void Awake()
    {
        Player_A = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        jFam_Control = GameObject.Find("NarrativeController").GetComponent<JoinedFamilyController>();
        mRouteControl = GameObject.Find("NarrativeController").GetComponent<MoleRouteController>();
        cAgroFamControl = GameObject.Find("NarrativeController").GetComponent<AgressiveCustomFamily>();
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        sSkills = GameObject.Find("SpeakButton").GetComponent<SpeakSkills>();
        vAction = GameObject.Find("ActionButton").GetComponent<VerbAction>();
        vInvest = GameObject.Find("InvestigateButton").GetComponent<VerbInvestigate>();
        currentState = GameState.Start;
        startTime = timeLeft; 
    }
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }
    void Update()
    {
    ///Switching States when game is fully paused or not fully paused///
    if(Player_A.currentState == PlayerActions.GameState.Paused)
            {
            setCurrentState = false;
            if(!OneTime)
            {
                setLastState();
                OneTime = true;
            }
            if(SetLastState == true)
            {
                currentState = GameState.Paused;
            }//sets local game state to pause
            }
    if(Player_A.currentState == PlayerActions.GameState.Active)
        {
            OneTime = false;
            SetLastState = false;
            if(!setCurrentState)
            {
                SetCurrentState();
            }
        }
    ///other stuff being updated constantly///
    countDown.text = ("" + timeLeft);
    if(timeLeft < 0)
        {
            aSource.PlayOneShot(TimesUp);
            currentState = GameState.ReadyToCollect;
            timeLeft = 0;
        }
    ///Starting State///
    if(currentState == GameState.Start)
        {
            button.interactable = true;
            buttonText.text = ("Start");
        }
    ///ReadyToCollectState///
    if(currentState == GameState.ReadyToCollect)
        {
            button.interactable = true;
            buttonText.text = ("Collect");
        }
    if(currentState == GameState.Active || currentState == GameState.Paused)
        {
            jFam_Control.OneTime = true;
            buttonText.text = "";
            button.interactable = false;
        }
    //reSet gamestate//
    if(currentState == GameState.reSet)
        {
            if(vAction.inSlot1.gameObject.tag == "Decision1")
            {
                vAction.inSlot1.GetComponent<Decision1Destroy>().removeFromLists();
            }
            if (vAction.inSlot1.gameObject.tag == "Decision2")
            {
                vAction.inSlot1.GetComponent<Decision2Destroy>().removeFromLists();
            }
            if (vAction.inSlot1.gameObject.tag == "Decision3")
            {
                vAction.inSlot1.GetComponent<Decision3Destroy>().removeFromList();
            }
            if(vAction.inSlot1.gameObject.tag == "AgressiveFam")
            {
                vAction.inSlot1.GetComponent<AFamDestruction>().removeFromList();
            }
            /*if(vAction.inSlot1.gameObject.tag == "")
            {
                vAction.inSlot1.GetComponent<MoleDestruction>().removeFromList();
            }*/
            if(vInvest.inSlot1.gameObject.name == "Card_P_TheDocks(Clone)")
            {
                vInvest.inSlot1.GetComponent<PlaceDestruction>().removeFromLists();
            }
            if(vInvest.inSlot1.gameObject.name == "Card_P_Headquarters(Clone)")
            {
                vInvest.inSlot1.GetComponent<PlaceDestruction>().removeFromLists();
            }
            if (vInvest.inSlot1.gameObject.name == "Card_P_Warehouse(Clone)")
            {
                vInvest.inSlot1.GetComponent<PlaceDestruction>().removeFromLists();
            }
            if (gameObject.name == "SpeakButton")
            {
                sSkills.setRandNum(1);
                sSkills.setOneTime(1);
            }
            if(N_Control.StartingJob.wasFarmer == true)
            {
                jFam_Control.SetOneTime(1);
            }
            if(N_Control.StartingJob.wasAccountant == true)
            {
                mRouteControl.SetOneTime(1);
            }
            if(N_Control.StartingJob.wasBouncer == true)
            {
                cAgroFamControl.SetOneTime(1);
            }
            currentState = GameState.Start;
        }
    }
    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if (currentState == GameState.Active)  
            {
                if(ButtonControl.FastForwardClicked == true)
                {
                    timeLeft -= 2;
                }
                if(ButtonControl.NormalClicked == true)
                {
                    timeLeft -= 1;
                }
                if(ButtonControl.PauseClicked == true)
                {
                    timeLeft -= 0;
                }
            }
            if(currentState != GameState.Active)
            {
                timeLeft -= 0;
            }
        }
    }
    public void Reactivate()
    {
        if(currentState == GameState.Start)
        {
            timeLeft = startTime;
            currentState = GameState.Active;
        }
       if(currentState == GameState.ReadyToCollect)
        {
            currentState = GameState.reSet;
        }
    }
    public void setLastState()
    {
        lastState = currentState;
        SetLastState = true;
    }
    public void SetCurrentState()
    {
        currentState = lastState;
        setCurrentState = true;
    }
}