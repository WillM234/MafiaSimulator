using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;
public class SliderController : MonoBehaviour
{
    public Slider timerSlider;
    private VerbAction vAction;
    private VerbExplore vExplore;
    private VerbInvestigate vInvest;
    private VerbSpeak vSpeak;
    private VerbTimer vTimer;
    private void Awake()
    {
        //reference to scripts
        vTimer = GetComponent<VerbTimer>();
        vAction = GameObject.Find("Verb_Action").GetComponent<VerbAction>();
        vExplore = GameObject.Find("Verb_Explore").GetComponent<VerbExplore>();
        vInvest = GameObject.Find("Verb_Investigate").GetComponent<VerbInvestigate>();
        vSpeak = GameObject.Find("Verb_Speak").GetComponent<VerbSpeak>();
    }
    // Update is called once per frame
    void Update()
    {
        //if the gameObject that this script is attached to the Verb Action Object
        if(gameObject.name == "Verb_Action")
        {
            //sets the slider's max value to the aTimer value of whatever card is in the first slot.
            //note: card has to be in the first slot in order for this to work
            timerSlider.maxValue = vAction.inSlot1.GetComponent<CardTimer>().cardAsset.aTimer;
        }
        //if the gameObject that this script is attached to the Verb Explore Object
        if (gameObject.name == "Verb_Explore")
        {
            //sets the slider's max value to the eTimer value of whatever card is in the first slot.
            //note: card has to be in the first slot in order for this to work
            timerSlider.maxValue = vExplore.inSlot1.GetComponent<CardTimer>().cardAsset.eTimer;
        }
        //if the gameObject that this script is on is attached to the Verb Investigate Object
        if(gameObject.name == "Verb_Investigate")
        {
            //sets the slider's max value to the iTimer value of whatever card is in the first slot.
            //note: card has to be in the first slot in order for this to work
            timerSlider.maxValue = vInvest.inSlot1.GetComponent<CardTimer>().cardAsset.iTimer;
        }
        //if the gameObject that this script is on is attched to the Verb Speak Object
        if (gameObject.name == "Verb_Speak")
        {
            //sets the slider's max value to the sTimer value of whatever card is in the first slot.
            //note: card has to be in the first slot in order for this to work
            timerSlider.maxValue = vSpeak.inSlot1.GetComponent<CardTimer>().cardAsset.sTimer;
        }
        //sets the slider value to whater the current time on the verb timer
        timerSlider.value = vTimer.timeLeft;
    }
}
