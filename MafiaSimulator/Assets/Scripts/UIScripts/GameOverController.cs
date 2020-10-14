using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverController : MonoBehaviour
{
    private NarrativeController N_Control;
    private PlayerActions pActions;
    public GameObject WinPanel, LosePanel;
    public Text WinReason, LoseReason;
    private void Awake()
    {
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        pActions = GetComponent<PlayerActions>();
    }
    void Update()
    {
     ///Activating GameOver/Done Panels///
        if(N_Control.GameLost == true)
        {
            LosePanel.SetActive(true);
            pActions.currentState = PlayerActions.GameState.Paused;
        }
        if(N_Control.GameWon == true)
        {
            WinPanel.SetActive(true);
            pActions.currentState = PlayerActions.GameState.Paused; 
        }
     ///Setting reasons text
        ///Lose reasons
        if(N_Control.byLackofFunds == true)
        {
            LoseReason.text = "You don't have enough currency to sustain yourself!";
        }
        if(N_Control.refusedMole == true)
        {
            LoseReason.text = "You have been sent to jail for your crimes and refusing to be their mole.";
        }
        if(N_Control.byKickedOut == true)
        {
            LoseReason.text = "You have been kicked out by the family and blacklisted!";
        }
        ///Won reasons
        if(N_Control.BecameImportant_toFamily == true)
        {
            WinReason.text = "You are important to an existing family. Maybe you could have go further."; 
        }
        if(N_Control.BecameTheDon == true)
        {
            WinReason.text = "You became the Don of an existing family. What could have been if you started your own?";
        }
    }
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}