using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardAsset : ScriptableObject
{
    [Header("Card Aspects")]
    private CardAsset cardAsset;
    public bool Aspect_Action,Aspect_Ingredient, Aspect_Skill, Aspect_Place, Aspect_Person,Aspect_Opportunity,is_Currency;

    [Header("Fill For Aspect_Action Only")]
    public int CurrencyReward;
    public float Timer;
    public CardAsset(CardAsset cardAsset)
    {
        this.cardAsset = cardAsset;
    }
}