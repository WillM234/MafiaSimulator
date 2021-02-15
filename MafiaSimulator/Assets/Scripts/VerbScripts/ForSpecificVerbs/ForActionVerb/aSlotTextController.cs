using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class aSlotTextController : MonoBehaviour
{
    #region referenced scripts
    private VerbAction vAction;
    private ActionOnSkills aOnSkills;
    #endregion
    #region Text stuff
    public TMP_Text infoText;
    #endregion
    private void Awake()
    {
        vAction = GetComponent<VerbAction>();
        aOnSkills = GetComponent<ActionOnSkills>();
    }
    void Update()
    {
        if(vAction.inSlot1.GetComponent<CardTimer>().cardAsset.Aspect_Opportunity == true)
        {
            if(vAction.inSlot1.gameObject.name == "Card_O_BeAMole(Clone)")
            {
                infoText.text = "To be or not to be, a mole.";
            }
            if(vAction.inSlot1.gameObject.name == "Card_O_ShadyDeal(Clone)")
            {
                infoText.text = "The deal seems good; but there are always consequences.";
            }
            if(vAction.inSlot1.gameObject.name == "Card_O_TheRecruiter(Clone)")
            {
                infoText.text = "A limited window to agree. Different choices lead to different things.";
            }
            if(vAction.inSlot1.gameObject.name == "Card_O_CreateFamily(Clone)")
            {
                infoText.text = "Is creating a family a good idea? Long road lies ahead.";
            }
            if(vAction.inSlot1.gameObject.name == "Card_O_InvestigateWarehouse(Clone)")
            {
                infoText.text = "Time to investigate the warehouse. Which approach should I take?";
            }
            if(vAction.inSlot1.gameObject.name == "Card_O_RaidRival(Clone)")
            {
                infoText.text = "Getting ready to raid a rival family's hideout. How should we approach this?";
                if (aOnSkills.useA == true)
                {
                    if(aOnSkills.cAthleticsTotal <= 3 && aOnSkills.cAthleticsTotal > 0)
                    {
                        infoText.text = "Our athletics is not good enough. We are being forced to retreat.";
                    }
                    else if(aOnSkills.cAthleticsTotal > 3 && aOnSkills.cAthleticsTotal <= 6)
                    {
                        infoText.text = "We are eveningly matched in strength. Both have suffered heavy losses.";
                    }
                    else
                    {
                        infoText.text = "We are by far superior. We are making them run in terror.";
                    }
                }
                if(aOnSkills.useM == true)
                {
                    if (aOnSkills.cMobilityTotal <= 3 && aOnSkills.cMobilityTotal > 0)
                    {
                        infoText.text = "We were not quick enough. They escaped before we could do any damage.";
                    }
                    else if (aOnSkills.cMobilityTotal > 3 && aOnSkills.cMobilityTotal <= 6)
                    {
                        infoText.text = "Some got away and some did not. They will likely come back for revenge.";
                    }
                    else
                    {
                        infoText.text = "We caught them by surprise and quickly dealt with them.";
                    }
                }
                if(aOnSkills.useP == true)
                {
                    if (aOnSkills.cPersuasionTotal <= 3 && aOnSkills.cPersuasionTotal > 0)
                    {
                        infoText.text = "Our negoiations broke down and they launched a surprise counter-attack. we sustained heavy loses.";
                    }
                    else if (aOnSkills.cPersuasionTotal > 3 && aOnSkills.cPersuasionTotal <= 6)
                    {
                        infoText.text = "We reached a compromise but neither family is happy with the result.";
                    }
                    else
                    {
                        infoText.text = "We convinced them to surrender. Now we own thier opperation.";
                    }
                }
                
            }
            if(vAction.inSlot1.gameObject.name == "Card_O_AssassinateRDon(Clone)")
            {
                infoText.text = "My task is to kill a rival family's Don. How should I go about it?";
                if (aOnSkills.useA)
                {
                    if (aOnSkills.cAthleticsTotal <= 3 && aOnSkills.cAthleticsTotal > 0)
                    {
                        infoText.text = "I have been seen and the guards are on alert. It is not a good idea for me to continue.";
                    }
                    else if (aOnSkills.cAthleticsTotal > 3 && aOnSkills.cAthleticsTotal <= 6)
                    {
                        infoText.text = "I have been seen, but no alarm has risen. I am close to where the Don sleeps. I may complete this job yet.";
                    }
                    else
                    {
                        infoText.text = "I got in and I got out. The rival Don is dead and the family will be pleased.";
                    }
                }
                if (aOnSkills.useM)
                {
                    if (aOnSkills.cMobilityTotal <= 3 && aOnSkills.cMobilityTotal > 0)
                    {
                        infoText.text = "I have been been caught. There may be an opportunity to slip away soon.";
                    }
                    else if (aOnSkills.cMobilityTotal > 3 && aOnSkills.cMobilityTotal <= 6)
                    {
                        infoText.text = "The rival Don is dead but I got caught in the act. I need to be quicker.";
                    }
                    else
                    {
                        infoText.text = "I got in and I got out. The rival Don is dead and the family will be pleased.";
                    }
                }
                if (aOnSkills.useP)
                {
                    if (aOnSkills.cPersuasionTotal <= 3 && aOnSkills.cPersuasionTotal > 0)
                    {
                        infoText.text = "";
                    }
                    else if (aOnSkills.cPersuasionTotal > 3 && aOnSkills.cPersuasionTotal <= 6)
                    {
                        infoText.text = "";
                    }
                    else
                    {
                        infoText.text = "";
                    }
                }
            }
            if(vAction.inSlot1.gameObject.name == "Card_O_BecomeDon(Clone)")
            {
                infoText.text = "I already am important to the family. Do i really asspire to become the Don?";
            }
        }
        else if(vAction.inSlot1.GetComponent<CardTimer>().cardAsset.Aspect_Skill)
        {
            if(vAction.inSlot1.gameObject.name == "Card_S_Athletics(Clone)")
            {
                infoText.text = "I use my athletic ability to do some heavy lifting. It is back-breaking work and pays little.";
            }
            if (vAction.inSlot1.gameObject.name == "Card_S_Mobility(Clone)")
            {
                infoText.text = "I move packages for a dilivery company. It is not easy work and pays badly.";
            }
            if (vAction.inSlot1.gameObject.name == "Card_S_Persuasion(Clone)")
            {
                infoText.text = "I persuaded some friends to give me some money.";
            }
        }
        else
        {
            infoText.text = "";
        }
    }
    
}
