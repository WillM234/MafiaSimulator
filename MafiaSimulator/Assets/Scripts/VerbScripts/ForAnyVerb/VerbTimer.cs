using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VerbTimer : MonoBehaviour
{
    #region Timer Stuff
    [Header("Timer Stuff")]
    public float timeLeft;
    public float startTime;
    public Text countDown;
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
    public Text buttonText;
    private VerbAction vAction;
    private JoinedFamilyController jFam_Control;
    #endregion
    private void Awake()
    {
        Player_A = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        jFam_Control = GameObject.Find("NarrativeController").GetComponent<JoinedFamilyController>();
        if (gameObject.name == "Verb_Action")
        {
            vAction = GetComponent<VerbAction>();
        }
        else vAction = GameObject.Find("Verb_Action").GetComponent<VerbAction>();
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
            if(vAction.inSlot1.gameObject.name == "Card_P_TheDocks(Clone)")
            {
                vAction.inSlot1.GetComponent<PlaceDestruction>().removeFromLists();
            }
            jFam_Control.SetOneTime(1);
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