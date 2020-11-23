using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlavorTextDisplay : MonoBehaviour
{
    #region UI Stuff
    public GameObject FlavorDisplay;
    public bool active;
    public Text cardName;
    public Text notUsedHere;
    public Text FlavorArea;
    #endregion
    #region Timer Stuff
    public float timeLeft;
    #endregion
    #region GameStateStuff
    public enum GameState {Active, Paused}
    public GameState currentState;
    private PlayerActions playerA;
    #endregion
    void Awake()
    {
        playerA = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        active = false;
    }
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }
    void Update()
    {
       if(playerA.currentState == PlayerActions.GameState.Active)
        {
            currentState = GameState.Active;
        }
       if(playerA.currentState == PlayerActions.GameState.Paused)
        {
            currentState = GameState.Paused;
        }
       if(timeLeft <= 0)
        {
            timeLeft = 0;
            active = false;
        }
       if(active)
        {
            FlavorDisplay.SetActive(true);
        }
        if (!active)
        {
            FlavorDisplay.SetActive(false);
        }
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(currentState == GameState.Active)
            {
                timeLeft -= 1;
            }
            if(currentState == GameState.Paused)
            {
                timeLeft -= 0;
            }
        }
    }
}
