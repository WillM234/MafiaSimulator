using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class O_FeedBackController : MonoBehaviour
{
    private MoleRouteController moleController;
    private AgressiveCustomFamily AgroCFamController;
    private JoinedFamilyController joinFamController;
    private NarrativeController N_Control;
    private PlayerActions pActions;
    private ActionOnSkills aOnSkills;
    private AngryFamilyTracking aFamTracking;
    public GameObject FeedbackPanel;
    public Text Explanation;
    public bool OneTime;
    private void Awake()
    {
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        moleController = GameObject.Find("NarrativeController").GetComponent<MoleRouteController>();
        joinFamController = GameObject.Find("NarrativeController").GetComponent<JoinedFamilyController>();
        AgroCFamController = GameObject.Find("NarrativeController").GetComponent<AgressiveCustomFamily>();
        aFamTracking = GameObject.Find("NarrativeController").GetComponent<AngryFamilyTracking>();
        pActions = GetComponent<PlayerActions>();
        aOnSkills = GameObject.Find("Verb_Action").GetComponent<ActionOnSkills>();
        OneTime = true;
    }
    void Update()
    {
        if (!OneTime)
        {
            SetPanelActive();
        }

        ///Explanation for first Opportunity
        if (N_Control.startingJobsDone == true)
        {
            if (N_Control.StartingJob.wasFarmer == true)
            {
                Explanation.text = "I was offered a deal to join the mafia. Should I take the offer or ignore it?";
            }
            if (N_Control.StartingJob.wasAccountant == true)
            {
                Explanation.text = "I was arrested for money laundering. The police offered me a way out. Become a mole in a mafia family. What should I do?";
            }
            if (N_Control.StartingJob.wasBouncer == true)
            {
                Explanation.text = "I was approached by a local mafia family's recruiter. He said his it is a limited time offer. What should I do?";
            }
        }
        ///Explanation for Secound Opportunity
        if (N_Control.Decision1Made == true && N_Control.SpawnedDecision2 == true)
        {
            if (N_Control.TookDeal == true)
            {
                Explanation.text = "I joined forces with the family. My first chance to prove myself is here.";
            }
            if (N_Control.JoinedFamily == true)
            {
                Explanation.text = "I took the recruiter's offer. I start my first job now.";
            }
            if (N_Control.BecameMole == true)
            {
                Explanation.text = "I became a mole for the police. I am expected to provide evidence on the local mafia. This is a dangerous game that I play.";
            }
            if (N_Control.refusedDeal == true)
            {
                Explanation.text = "I refused their deal. I hope there are other opportunities in the future.";
            }
            if (N_Control.DidntJoinFamily == true)
            {
                Explanation.text = "I declined the offer. Prehaps another opportunity will come around in the future.";
            }
        }
        ///Explanation for third opportunity
        if (N_Control.Decision2Made == true && N_Control.SpawnedDecision3 == true)
        {
            if (N_Control.raidFinished == true)
            {
                if (aOnSkills.fail == true)
                {
                    Explanation.text = "We failed. The Don and the rest of the heads are not happy.";
                }
                if (aOnSkills.part_Success == true)
                {
                    Explanation.text = "We successed but at a costly price. The Don and the rest of the heads are not happy with the price we paid. Is there still time to prove myself?";
                }
                if (aOnSkills.full_Success == true)
                {
                    Explanation.text = "The raid is done and we revel in our success. More opportunities lie ahead. The next is far more dangerous.";
                }
            }
            else
            {
                Explanation.text = "This is the end of this current path. To quit open the Options and hit the quit button. To restart open the Options and hit the restart button.";
            }
        }
        ///Explanation for fourth opportunity
        if (N_Control.Decision3Made == true && N_Control.SpawnedDecision4 == true)
        {
            if (N_Control.AngryFamily < 1)
            {
                if (aOnSkills.fail == true)
                {
                    Explanation.text = "I failed to assassinate the rival Don. The family is not happy with me.";
                }
                if (aOnSkills.part_Success == true)
                {
                    Explanation.text = "I killed the rival Don but I was seen. The heads are not happy that it turned out this way. But has my other work paid off?";
                }
                if (aOnSkills.full_Success == true)
                {
                    Explanation.text = "I everything went smoothly. I killed the rival Don. Is that enough to prove my worth?";
                }
            }
            if (N_Control.AngryFamily == 1)
            {
                if (aOnSkills.fail == true)
                {
                    Explanation.text = " I failed to kill the rival Don and they saw me. Did they identify me? The family heads are not happy with my work.";
                }
                if (aOnSkills.part_Success == true)
                {
                    Explanation.text = "I killed the rival Don but I was seen. Was I followed? The family is not happy that I was spotted.";
                }
                if (aOnSkills.full_Success == true)
                {
                    Explanation.text = "I killed the rival Don. I was not seen. The family is happy with my work so far.";
                }
            }
            if (N_Control.AngryFamily == 2)
            {
                if (aOnSkills.fail == true)
                {
                    Explanation.text = "I have failed again. The heads are extremely unhappy with me.";
                }
                if (aOnSkills.part_Success == true)
                {
                    Explanation.text = "I killed the rival Don but there were complications. The family is not happy with this turn of events.";
                }
            }
        }
        //for temp ends
        if (moleController.tempEnd == true || AgroCFamController.tempEnd == true || joinFamController.tempEnd == true)
        {

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