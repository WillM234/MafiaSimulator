using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardAsset : ScriptableObject
{
    [Header("Card Aspects")]
    private CardAsset cardAsset;
    public bool Aspect_Action,Aspect_Ingredient, Aspect_Skill, Aspect_Place, Aspect_Person,Aspect_Opportunity,is_Currency;
    [Header("Fill for things that go in Verb_Action")]
    public int CurrencyReward;
    public int aSlotsNeeded;
    public float aTimer;
    [Header("Fill for things that go in Verb_Explore")]
    public float eTimer;
    public int eSlotsNeeded;
    [Header("Fill for things that go in Verb_Investigate")]
    public float iTimer;
    public int iSlotsNeeded;
    [Header("Fill for things that go in Verb_Speak")]
    public float sTimer;
    public int sSlotsNeeded;
    public CardAsset(CardAsset cardAsset)
    {
        this.cardAsset = cardAsset;
    }
}