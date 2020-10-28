using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class eSlotTextController : MonoBehaviour
{
    #region referenced scripts
    private VerbExplore vExplore;
    #endregion
    public Text infoText;
    private void Awake()
    {
        vExplore = GetComponent<VerbExplore>();
    }
    void Update()
    {
        if(vExplore.inSlot1.GetComponent<CardTimer>().cardAsset.Aspect_Skill == true)
        {
            if(vExplore.inSlot1.gameObject.name == "Card_S_Athletics(Clone)")
            {
                infoText.text = "If I am going to explore the city my athletic ability should help.";
            }
            if (vExplore.inSlot1.gameObject.name == "Card_S_Mobility(Clone)")
            {
                infoText.text = "Sneaking in the shadows around the city should prove fruitful.";
            }
            if (vExplore.inSlot1.gameObject.name == "Card_S_Persuasion(Clone)")
            {
                infoText.text = "I don't know how being persuasive can help explore the city.";
            }
        }
        else
        {
            infoText.text = "";
        }
    }
}
