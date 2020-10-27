using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOnSkills : MonoBehaviour
{
    #region Reference Scripts
    private VerbAction vAction;
    private CardPositioning aList;
    private VerbTimer aTimer;
    private AngryFamilyTracking aFamTracking;
    //private CardTimer cTimer;
    //private CardsInSlots cInSlots;
    #endregion
    #region Skill Totals
    public int mGoal, pGoal, aGoal;
    public int cMobilityTotal, cPersuasionTotal, cAthleticsTotal;
    public bool fail, part_Success, full_Success;
    public bool useM, useA, useP;
    #endregion
    private void Awake()
    {
        //fetching reference scripts
        aFamTracking = GameObject.Find("NarrativeController").GetComponent<AngryFamilyTracking>();
        vAction = GetComponent<VerbAction>();
        aTimer = GetComponent<VerbTimer>();
        aList = GetComponent<CardPositioning>();
    }
    void Update()
    {
        //Determinining Mobiliity, Athletics, and Persuasion Totals based on what is in the slots beside sides slot 1
        //if card requires two slots
        if(vAction.inSlot1.GetComponent<CardTimer>().cardAsset.aSlotsNeeded == 2)
        {
            //current mobility total equals mobility value of 2nd slot only
            cMobilityTotal = vAction.inSlot2.GetComponent<CardTimer>().cardAsset.MobilityValue;
            //current athletics total equals athletics value of 2nd slot only
            cAthleticsTotal = vAction.inSlot2.GetComponent<CardTimer>().cardAsset.AthleticsValue;
            //current persuasion total equals persuasion value of 2nd slot only
            cPersuasionTotal = vAction.inSlot2.GetComponent<CardTimer>().cardAsset.PersuasionValue;
        }
        //if card requires three slots
        if (vAction.inSlot1.GetComponent<CardTimer>().cardAsset.aSlotsNeeded == 3)
        {
            //current mobility total equals mobility value of 2nd and 3rd slots
            cMobilityTotal = vAction.inSlot2.GetComponent<CardTimer>().cardAsset.MobilityValue + vAction.inSlot3.GetComponent<CardTimer>().cardAsset.MobilityValue;
            //current athletics total equals athletics value of 2nd and 3rd slots
            cAthleticsTotal = vAction.inSlot2.GetComponent<CardTimer>().cardAsset.AthleticsValue + vAction.inSlot3.GetComponent<CardTimer>().cardAsset.AthleticsValue;
            //current persuasion total equals persuasion value of 2nd and 3rd slots
            cPersuasionTotal = vAction.inSlot2.GetComponent<CardTimer>().cardAsset.PersuasionValue + vAction.inSlot3.GetComponent<CardTimer>().cardAsset.PersuasionValue;
        }
            //if card requires four slots
            if (vAction.inSlot1.GetComponent<CardTimer>().cardAsset.aSlotsNeeded == 4)
        {
            //current mobility total equals mobility value of 2nd, 3rd, and 4th, slots 
            cMobilityTotal = vAction.inSlot2.GetComponent<CardTimer>().cardAsset.MobilityValue + vAction.inSlot3.GetComponent<CardTimer>().cardAsset.MobilityValue + vAction.inSlot4.GetComponent<CardTimer>().cardAsset.MobilityValue;
            //current athletics total equals athletics  value of 2nd, 3rd, and 4th, slots
            cAthleticsTotal = vAction.inSlot2.GetComponent<CardTimer>().cardAsset.AthleticsValue + vAction.inSlot3.GetComponent<CardTimer>().cardAsset.AthleticsValue + vAction.inSlot4.GetComponent<CardTimer>().cardAsset.AthleticsValue;
            //current persuasion total equals persuasion  value of 2nd, 3rd, and 4th, slots
            cPersuasionTotal = vAction.inSlot2.GetComponent<CardTimer>().cardAsset.PersuasionValue + vAction.inSlot3.GetComponent<CardTimer>().cardAsset.PersuasionValue + vAction.inSlot4.GetComponent<CardTimer>().cardAsset.PersuasionValue;
        }
        //setting goal total
        if (vAction.inSlot1.GetComponent<CardTimer>().cardAsset.Aspect_Opportunity == true)
        {
            mGoal = vAction.inSlot1.GetComponent<CardTimer>().cardAsset.mGoal;//setting mobility total 
            aGoal = vAction.inSlot1.GetComponent<CardTimer>().cardAsset.aGoal;//setting athletics total
            pGoal = vAction.inSlot1.GetComponent<CardTimer>().cardAsset.pGoal;//setting persuasion total
        }
        ///determining which total will be used
        if(aTimer.currentState == VerbTimer.GameState.Active)
        {
            //for using Mobility
            if(cMobilityTotal > cAthleticsTotal && cMobilityTotal > cPersuasionTotal)
            {
                useM = true;
            }
            //for using Athletics
            if(cAthleticsTotal > cMobilityTotal && cAthleticsTotal > cPersuasionTotal)
            {
                useA = true;
            }
            // for using Persuasion
            if(cPersuasionTotal > cMobilityTotal && cPersuasionTotal > cAthleticsTotal)
            {
                useP = true;
            }
        }
        ///What happens with different totals
        if(aTimer.currentState == VerbTimer.GameState.ReadyToCollect)
        {
            //if using mobility
            if(useM)
            {
                //if mobility total is equal to 3 or less
                if (cMobilityTotal <= 3)
                {
                    fail = true;
                }
                //if mobility total is greater than 3 but equal to or less than 6
                else if (cMobilityTotal > 3 && cMobilityTotal <= 6)
                {
                    part_Success = true;
                }
                //if mobility total is greater than  6
                else
                {
                    full_Success = true;
                }
            }
            //if using persuasion
            else if(useP)
            {
                //if persuasion total is equal to 3 or less
                if(cPersuasionTotal <= 3)
                {
                    fail = true;
                }
                //if persuasion total is greater than 3 but equal to or less than 6
                else if(cPersuasionTotal > 3 && cPersuasionTotal <= 6)
                {
                    part_Success = true;
                }
                //if persuasion total is greater than 6
                else
                {
                    full_Success = true;
                }
            }
            //if using athletics 
            else if(useA)
            {
                //if athletics total is equal to 3 or less
                if(cAthleticsTotal <= 3)
                {
                    fail = true;
                }
                //if athletics total is greater than 3 but less than or equal to 6
                else if(cAthleticsTotal > 3 && cAthleticsTotal <= 6)
                {
                    part_Success = true;
                }
                //if athletics total is greater than 6
                else
                {
                    full_Success = true;
                }
            }
        }
    }
    public void fail_Success()
    {
        if(fail)
        {
            aFamTracking.SetOneTime();
            fail = false;
        }
        if(part_Success)
        {
            aFamTracking.SetOneTime();
            part_Success = false;
        }
        useA = false;
        useP = false;
        useM = false;
        full_Success = false;
    }
}
