using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class O_FeedBackController : MonoBehaviour
{
    private NarrativeController N_Control;
    private PlayerActions pActions;
    public GameObject FeedbackPanel;
    public Text Explanation;
    private bool OneTime;
    private void Awake()
    {
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        pActions = GetComponent<PlayerActions>();
        OneTime = true;
    }
    void Update()
    {
        if(!OneTime)
        {
            SetPanelActive();
        }
        ///Explanation for first Opportunity
        if(N_Control.startingJobsDone == true)
        {
            if(N_Control.StartingJob.wasFarmer == true)
            {
                Explanation.text = "You are offered a deal to work for an established mafia family. Do you ignore the chance and let time run out or join?";
            }
            if(N_Control.StartingJob.wasAccountant == true)
            {
                Explanation.text = "You were arrested for money Laundering and face a long sentence. You are offered a deal to become a mole for the police. The decision is yours.";
            }
            if(N_Control.StartingJob.wasBouncer == true)
            {
                Explanation.text = "You are approached by a recruiter of a reputable mafia family. He offers you a limited time deal. What is your choice?";
            }
        }
        ///Explanation for Secound Opportunity
        if(N_Control.Decision1Made == true && N_Control.SpawnedDecision2 == true)
        {
            if(N_Control.TookDeal == true)
            {
                Explanation.text = "You joined forces with the family. The first chance to prove yourself is here.";
            }
            if(N_Control.JoinedFamily == true)
            {
                Explanation.text = "You took his offer and joined the family. Your first job is now.";
            }
            if(N_Control.BecameMole == true)
            {
                Explanation.text = "You became a mole for the police. They let you go but you are expected to provide evidence. Betraying the mafia can be very dangerous.";
            }
            if(N_Control.refusedDeal == true)
            {
                Explanation.text = "You refused their deal. There may be other opportunities for you in the future.";
            }
            if(N_Control.DidntJoinFamily == true)
            {
                Explanation.text = "You declined the offer. Prehaps an opportunity will come around in the future.";
            }
        }
        ///Explanation for Raid Opportunity
        if(N_Control.Decision2Made == true && N_Control.spawnPlace == true)
        {
            Explanation.text = "The raid is taking place at The Docks. All we need to do now is take action.";
        }
        ///Explanation for third opportunity
        if(N_Control.Decision2Made == true && N_Control.SpawnedDecision3 == true)
        {
            if(N_Control.raidFinished == true)
            {
                Explanation.text = "The raid is done and we revel inour success. More opportunities lie ahead. The next is far more dangerous.";
            }
        }
        ///Explanation for fourth opportunity
        if(N_Control.Decision3Made == true && N_Control.SpawnedDecision4 == true)
        {
            Explanation.text = "My work has paid off. Now it is my decision if I want to take the lead or not.";
        }
    }
    public void SetOneTime(int times)
    {
        for(int i = 0; i < times; i++)
        {
            OneTime = false;
        }
    }
    void SetPanelActive()
    {
        FeedbackPanel.SetActive(true);
        pActions.currentState = PlayerActions.GameState.Paused;
        OneTime = true;
    }
    public void CotinueGame()
    {
        FeedbackPanel.SetActive(false);
        pActions.currentState = PlayerActions.GameState.Active;
   
    }
}