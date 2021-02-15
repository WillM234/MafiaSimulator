using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class sSlotTextController : MonoBehaviour
{
    #region referenced scripts
    private VerbSpeak vSpeak;
    #endregion
    public TMP_Text infoText;
    private void Awake()
    {
        vSpeak = GetComponent<VerbSpeak>();
    }
    void Update()
    {
        if(vSpeak.inSlot1.GetComponent<CardTimer>().cardAsset.Aspect_Skill == true)
        {
            if(vSpeak.inSlot1.gameObject.name == "Card_S_Athletics(Clone)")
            {
                infoText.text = "I should speak about athletics. You never know who may be interested in a workout.";
            }
            if (vSpeak.inSlot1.gameObject.name == "Card_S_Mobility(Clone)")
            {
                infoText.text = "I should speak about mobility. You never know who may be sneaking about.";
            }
            if (vSpeak.inSlot1.gameObject.name == "Card_S_Persuasion(Clone)")
            {
                infoText.text = "I should talk about persausion. There are plenty who wish to engage in acedemic discourse.";
            }
        }
        else
        {
            infoText.text = "";
        }
    }
}
