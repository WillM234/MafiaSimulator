using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardInfoUI : MonoBehaviour
{
    public float displayTime;
    private CardHover cHover;
    private GameObject thisCard;
    private FlavorTextDisplay fTextDisplay;
    void Awake()
    {
        cHover = GetComponent<CardHover>();
        fTextDisplay = GameObject.Find("MainCamera").GetComponent<FlavorTextDisplay>();
        thisCard = gameObject;
    }
    private void OnMouseUp()
    {
        if(cHover.mouseIsOver == true)
        {
        //Displaying the actual panel 
            fTextDisplay.active = true;
            fTextDisplay.timeLeft = fTextDisplay.DisplayTime;
            ///Starting Job cards
            //What happens for Bodyguard job
            if(thisCard.name == "Card_A_Bodyguard(Clone)")
            {
                fTextDisplay.cardName.text = "Job: Being a Bodyguard";
                fTextDisplay.notUsedHere.text = "Can not be used in Investigate or Speak";
                fTextDisplay.FlavorArea.text = "I am a bodyguard and bouncer at a local speakeasy. I do my job diligently but I am not paid a lot.";
            }
            //what happens for Money Launderer Job
            if (thisCard.name == "Card_A_MoneyLaunderer(Clone)")
            {
                fTextDisplay.cardName.text = "Job: Money-Laundering";
                fTextDisplay.notUsedHere.text = "Can not be used in Investigate or Speak";
                fTextDisplay.FlavorArea.text = "I launder money for a local mafia family on the side. It pays well but if I am caught then I will be in prision for a long time.";
            }
            //What happens for Moonshiner Job
            if(thisCard.name == "Card_A_Moonshiner(Clone)")
            {
                fTextDisplay.cardName.text = "Job: Running and Making Moonshine";
                fTextDisplay.notUsedHere.text = "Can not be used in Investigate or Speak";
                fTextDisplay.FlavorArea.text = "I create and run moonshine. I sell it to a few local speakeasies at a profit. It pays okay but I could probably make more doing something else.";
            }
            ///Ingrediant cards
            //what happen for visual currency
            if (thisCard.name == "VisualCurrency")
            {
                fTextDisplay.cardName.text = "Currency, Funds, or Money";
                fTextDisplay.notUsedHere.text = "Is automaticaly pulled or subtracted from the stockpile.";
                fTextDisplay.FlavorArea.text = "I need money in order to survive. If I run out of money then I will die(lose).";
            }
            //What happens for evidence
            if (thisCard.name == "Card_i_Evidence(Clone)")
            {
                fTextDisplay.cardName.text = "Evidence On the Family";
                fTextDisplay.notUsedHere.text = "Used In action conditionally.";
                fTextDisplay.FlavorArea.text = "I have evidnece for the police. It is time sensative so I should hand it to them as soon as possible.";
            }
            ///opportunity cards
            //What happens for Create Family
            if (thisCard.name == "Card_O_CreateFamily(Clone)")
            {
                fTextDisplay.cardName.text = "To Create my own Family";
                fTextDisplay.notUsedHere.text = "This is not used in Investigate or Speak.";
                fTextDisplay.FlavorArea.text = "Should I create a family? If we are successful we will go far.";
            }
            //What happens for Family Specialization
            if (thisCard.name == "Card_O_FamSpecialization(Clone)")
            {
                fTextDisplay.cardName.text = "Specialiazation of My Family";
                fTextDisplay.notUsedHere.text = "This is not used in Investigate or Speak.";
                fTextDisplay.FlavorArea.text = "What should my family specialize in? Being agressive is the only way currently.(Doesn't matter what is put in the slots with this card)";
            }
            //What happens for Tax Enforcement
            if (thisCard.name == "Card_O_TaxEnforcement(Clone)")
            {
                fTextDisplay.cardName.text = "Enforce Protection Tax";
                fTextDisplay.notUsedHere.text = "This is not used in Investigate or Speak.";
                fTextDisplay.FlavorArea.text = "We need to collect a tax for protecting the local businesses. It is nessissary for us to keep the funds coming in for us to survive. How we go about it is up to me.";
            }
            //What happens for Drug Deal
            if (thisCard.name == "Card_O_DrugDeal(Clone)")
            {
                fTextDisplay.cardName.text = "To Protect a Drug Deal";
                fTextDisplay.notUsedHere.text = "This is not used in Investigate or Speak.";
                fTextDisplay.FlavorArea.text = "We have to protect this drug deal. Proving that we can protect the dealer will help us in the future. How we go about doing so is up to me.";
            }
            //What happens for Rival Enforcer
            if (thisCard.name == "Card_O_RivalEnforcer(Clone)")
            {
                fTextDisplay.cardName.text = "To Assassinate a Rival Enforcer";
                fTextDisplay.notUsedHere.text = "This is not used in Investigate or Speak.";
                fTextDisplay.FlavorArea.text = "This is my opportunity to get rid of the annoying enforcer of a rival family. I need to be decrete and not have it be tracked back to my family. How I go about it is my choice.";
            }
            //What happens for Investigate warehouse
            if (thisCard.name == "Card_O_InvestigateWarehouse(Clone)")
            {
                fTextDisplay.cardName.text = "Investigate The Family's Warehouse";
                fTextDisplay.notUsedHere.text = "This is not used in Investigate or Speak.";
                fTextDisplay.FlavorArea.text = "I should investigate the warehouse for evidence for the police. I need to be careful. How I go about it is up to me.";
            }
            //what happens for raid rival
            if (thisCard.name == "Card_O_RaidRival(Clone)")
            {
                fTextDisplay.cardName.text = "To Raid a Rival Family";
                fTextDisplay.notUsedHere.text = "This is not used in Investigate or Speak.";
                fTextDisplay.FlavorArea.text = "We have an opportuinty to take a rival family's resources. This could mean an advancement for me in my family. How we go about it is up to me.";
            }
            //What happens for assassinate rival don 
            if (thisCard.name == "Card_O_AssassinateRDon(Clone)")
            {
                fTextDisplay.cardName.text = "To Assassinate a Rival Don";
                fTextDisplay.notUsedHere.text = "This is not used in Investigate or Speak.";
                fTextDisplay.FlavorArea.text = "This is my opportunity to kill a rival family's Don. I must be careful, for if it is racked back to my family it could mean war. How I go about it is my choice.";
            }
            //What happens for Become The Don
            if (thisCard.name == "Card_O_BecomeDon(Clone)")
            {
                fTextDisplay.cardName.text = "To Become Don";
                fTextDisplay.notUsedHere.text = "This is not used in Investigate or Speak.";
                fTextDisplay.FlavorArea.text = "This is my chance to become the Don of the family. It is my chance to have the highest honor but I have left my mark on the family no matter what.";
            }
            ///People cards
            //What happens for Family Bodyguard
            if (thisCard.name == "Card_Per_FamBodyguard(Clone)")
            {
                fTextDisplay.cardName.text = "The Bodyguard";
                fTextDisplay.notUsedHere.text = "Used to bolster your forces during certain opportunities.";
                fTextDisplay.FlavorArea.text = "The bodyguard was hired to protect those in the family who need the extra muscle. His Athletics is okay and lacks in both Mobility and Persuasion.";
            }
            //What happens for Hitman
            if (thisCard.name == "Card_Per_Hitman(Clone)")
            {
                fTextDisplay.cardName.text = "The Hitman";
                fTextDisplay.notUsedHere.text = "Used to bolster your forces during certain opportunities.";
                fTextDisplay.FlavorArea.text = "The hitman does the dirty work of the family. If someone needs to disapear he is your man. He excells in Athletics but lacks in Mobility and Persuasion.";
            }
            //What happens for Informant 
            if (thisCard.name == "Card_Per_Informant(Clone)")
            {
                fTextDisplay.cardName.text = "The Informant";
                fTextDisplay.notUsedHere.text = "Used to bolster your forces during certain opportunities.";
                fTextDisplay.FlavorArea.text = "The informant sneaks their way into our enemy's opporations and provides us insider information descretly. He is excells in Mobility but lacks in Athletics and Persuasion.";
            }
            //What happens for RightHand
            if (thisCard.name == "Card_Per_RightHand(Clone)")
            {
                fTextDisplay.cardName.text = "The Righthand";
                fTextDisplay.notUsedHere.text = "Used to bolster your forces during certain opportunities.";
                fTextDisplay.FlavorArea.text = "The Right Hand is the second in command after the Don. Thy handle some affrairs so the Don does not have to. The Right Hand excells in Athletics and is okay in Mobility and Persuasion.";
            }
            //What happens for The Don
            if (thisCard.name == "Card_Per_TheDon(Clone)")
            {
                fTextDisplay.cardName.text = "The Don";
                fTextDisplay.notUsedHere.text = "Used to bolster your forces during certain opportunities.";
                fTextDisplay.FlavorArea.text = "The Don is the head of the family. He excells in Athletics, Persuasion, and Mobility.";
            }
            ///PlaceCards
            //What happens for Headquarters
            if (thisCard.name == "Card_P_Headquarters(Clone)")
            {
                 fTextDisplay.cardName.text = "Headquarters";
                 fTextDisplay.notUsedHere.text = "Is not used in Action or Speak.";
                 fTextDisplay.FlavorArea.text = "The headquarters is where the big wigs hang out. It is guarded and armed like a castle. It wouldn't be taken without a fight.";
            }
            //What happens for The Docks
            if (thisCard.name == "Card_P_TheDocks(Clone)")
            {
                 fTextDisplay.cardName.text = "The Docks";
                 fTextDisplay.notUsedHere.text = "Is not used in Action or Speak.";
                 fTextDisplay.FlavorArea.text = "The docks are next to the river. They are a good place to hold a descrite meeting or a drop-off. Many people have been laid to rest here never to be found again.";
            }
            //What happens for Warehouse
            if (thisCard.name == "Card_P_Warehouse(Clone)")
            {
                 fTextDisplay.cardName.text = "Warehouse";
                 fTextDisplay.notUsedHere.text = "Is not used in Action or Speak.";
                 fTextDisplay.FlavorArea.text = "The warehouse is where the family stores various precious goods. It is hidden away between the legitament store houses of businesses in the city.";
            }
            ///Skill Cards
            //What happens for Athletics
            if (thisCard.name == "Card_S_Athletics(Clone)")
            {
                fTextDisplay.cardName.text = "Athletics";
                fTextDisplay.notUsedHere.text = "This can be used in either Action or Speak freely. Conditionaly for Investigate";
                fTextDisplay.FlavorArea.text = "My athletic ability and over all fitness. This has an Athletics Value of 1.";
            }
            //What happens for Mobility
            if (thisCard.name == "Card_S_Mobility(Clone)")
            {
                fTextDisplay.cardName.text = "Mobility";
                fTextDisplay.notUsedHere.text = "This can be used in either Action or Speak freely. Conditionaly for Investigate";
                fTextDisplay.FlavorArea.text = "My ability to move and how fast I am generally. This has a Mobility Value of 1.";
            }
            //What happens for Persuasion
            if (thisCard.name == "Card_S_Persuasion(Clone)")
            {
                fTextDisplay.cardName.text = "Persuasion";
                fTextDisplay.notUsedHere.text = "This can be used in either Action or Speak freely. Conditionaly for Investigate";
                fTextDisplay.FlavorArea.text = "My ability to persuade people and get them to do what I want. This has a Persuasion Value of 1.";
            }
        }//what happens when the mouse is clicked while over the card this script is attached to
    }
}