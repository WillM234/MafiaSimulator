using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class iSlotTextController : MonoBehaviour
{
    #region referenced scripts
    private VerbInvestigate vInvest;
    #endregion
    public TMP_Text infoText;
    private void Awake()
    {
        vInvest = GetComponent<VerbInvestigate>();
    }
    void Update()
    {
        if (vInvest.inSlot1.GetComponent<CardTimer>().cardAsset.Aspect_Skill == true)
        {
            if (vInvest.inSlot1.gameObject.name == "Card_S_Athletics(Clone)")
            {
                infoText.text = "Should I investigate how I could improve my athletic ability? Is it even worth the time?";
            }
            if (vInvest.inSlot1.gameObject.name == "Card_S_Mobility(Clone)")
            {
                infoText.text = "Should I investigate how i could become faster? What possibilities are there?";
            }
            if (vInvest.inSlot1.gameObject.name == "Card_S_Persuasion(Clone)")
            {
                infoText.text = "Should I look into how to be more persuasive? Being able to convince people of things could be nice.";
            }
        }
        else
        {
            infoText.text = "";
        }
    }
}
