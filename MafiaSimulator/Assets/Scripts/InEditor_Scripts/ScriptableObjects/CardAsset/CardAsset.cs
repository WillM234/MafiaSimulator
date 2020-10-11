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
    public float aTimer;
    [Header("Fill for things that go in Verb_Explore")]
    public float eTimer;
    [Header("Fill for things that go in Verb_Investigate")]
    public float iTimer;
    [Header("Fill for things that go in Verb_Speak")]
    public float sTimer;
    public CardAsset(CardAsset cardAsset)
    {
        this.cardAsset = cardAsset;
    }
}