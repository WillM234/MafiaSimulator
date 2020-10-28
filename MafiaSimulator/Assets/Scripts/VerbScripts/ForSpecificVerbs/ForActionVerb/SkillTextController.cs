using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillTextController : MonoBehaviour
{
    #region Skill Texts
    public Text mobilityText, athleticsText, persuasionText;
    #endregion
    #region Referenced Scripts
    private ActionOnSkills aOnSkills;
    private VerbAction vAction;
    #endregion
    private void Awake()
    {
        //referenced scripts
        aOnSkills = GetComponent<ActionOnSkills>();
        vAction = GetComponent<VerbAction>();
    }
    void Update()
    {
        //if the card in slot one is an opportunity card
        if(vAction.inSlot1.GetComponent<CardTimer>().cardAsset.Aspect_Opportunity == true)
        {
            //Showing mobility total
            mobilityText.text = ("Mobility: " + aOnSkills.cMobilityTotal);
            //showing athletics total
            athleticsText.text = ("Athletics: " + aOnSkills.cAthleticsTotal);
            //showing persuasion total
            persuasionText.text = ("Persuasion: " + aOnSkills.cPersuasionTotal);
        }
        //if the card is not an opportunity card
        else
        {
            //all texts are blank
            mobilityText.text = "";
            athleticsText.text = "";
            persuasionText.text = "";
        }
    }
}