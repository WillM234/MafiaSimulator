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
    private VerbAutoTimer AutoTimer;
    private CardToLists cardLists;
    private TimePasses T_Pass;
    private CardPositioning VerbA, VerbE, VerbI, VerbS, TPasses;
    public Vector3 CardPos;
    public bool in_aSnap,in_tSnap,in_eSnap,in_sSnap, in_iSnap,InsertOnce;
    private void Awake()
    {
        cardLists = GetComponent<CardToLists>();
        T_Pass = GameObject.Find("TimePasses").GetComponent<TimePasses>();
        AutoTimer = GameObject.Find("TimePasses").GetComponent<VerbAutoTimer>();
        Player_A = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        ButtonControl = GameObject.Find("MainCamera").GetComponent<UIButtonControl>();
        VerbA = GameObject.Find("Verb_Action").GetComponent<CardPositioning>();
        VerbE = GameObject.Find("Verb_Explore").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("Verb_Investigate").GetComponent <CardPositioning>();
        VerbS = GameObject.Find("Verb_Speak").GetComponent<CardPositioning>();
        TPasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        currentState = GameState.ActiveState;
        if(T_Pass.cardInSnap == false && cardAsset.is_Currency == true)
        {
            transform.position = TPasses.SnapPosition;
        }
    }
    void Start()
    {
        if (cardAsset.Aspect_Action == true)
        {
                StartCoroutine("LoseTimer");
                Time.timeScale = 1;
        }
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
            if (in_aSnap || in_sSnap|| in_eSnap||in_tSnap||in_iSnap)
                    currentState = GameState.PauseState;
            else if (!in_aSnap && !in_sSnap && !in_eSnap && !in_tSnap && !in_iSnap)
                    currentState = GameState.ActiveState;
        }
        ///other stuff being updated constantly///
        if (in_tSnap)
        {
            T_Pass.c_timer = GetComponent<CardTimer>();
        }
        if (cardAsset.Aspect_Action == true)
        {
            countDown.text = ("" + timeLeft);
        }
        else
            countDown.text = "";
        if(timeLeft <= 0)
        {
            currentState = GameState.DeactiveState;
        }
        if(currentState == GameState.DeactiveState)
        {

        }
    }
    IEnumerator LoseTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if (cardAsset.Aspect_Action == true)
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
