using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositioning : MonoBehaviour
{
    public List<GameObject> Card = new List<GameObject>();
    private SlotAreaController aSlot_Control, iSlot_Control, sSlot_Control;
    private CardPositioning VerbA, VerbI, VerbS;
    [Header("Slot 1 Stuff")]
    public float S1x_Min;
    public float S1x_Max;
    public float S1y_Min;
    public float S1y_Max;
    public Vector3 S1_Snap;
    [Header("Slot 2 Stuff")]
    public float S2x_Min;
    public float S2x_Max;
    public float S2y_Min;
    public float S2y_Max;
    public Vector3 S2_Snap;
    [Header("Slot 3 Stuff")]
    public float S3x_Min;
    public float S3x_Max;
    public float S3y_Min;
    public float S3y_Max;
    public Vector3 S3_Snap;
    [Header("Slot 4 Stuff")]
    public float S4x_Min;
    public float S4x_Max;
    public float S4y_Min;
    public float S4y_Max;
    public Vector3 S4_Snap;
    [Header("For TimePasses")]
    public float X_min;
    public float X_max;
    public float Y_min;
    public float Y_max;
    public Vector3 SnapPosition;
    [Header("For All")]
    public bool locked;
    private Vector3 CardPos;
    private void Awake()
    {
        //script references for SlotControllers
        aSlot_Control = GameObject.Find("ActionButton").GetComponent<SlotAreaController>();
        iSlot_Control = GameObject.Find("InvestigateButton").GetComponent<SlotAreaController>();
        sSlot_Control = GameObject.Find("SpeakButton").GetComponent<SlotAreaController>();
        //references for this script on other objects
        VerbA = GameObject.Find("ActionButton").GetComponent<CardPositioning>();
        VerbI = GameObject.Find("InvestigateButton").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("SpeakButton").GetComponent<CardPositioning>();
    }
    private void Update()
    {
        foreach(GameObject card in Card)
        {

            CardPos = card.transform.position;//sets cardPos as a card's position and updates when a card is moved
            if ((CardPos.x >= X_min && CardPos.x <= X_max) && (CardPos.y <= Y_max && CardPos.y >= Y_min))
            {
                card.transform.position = SnapPosition;
            }
            //for Verb Action
            if(gameObject.name == "ActionButton")
            {
                //as long as the verb area is active and not locked the first slot snap works
                if (aSlot_Control.sAreaActive == true && locked == false)
                {
                    ///Slot 1 Snap
                    if ((CardPos.x >= S1x_Min && CardPos.x <= S1x_Max) && (CardPos.y <= S1y_Max && CardPos.y >= S1y_Min))
                    {
                        card.transform.position = S1_Snap;
                    }
                    //as long as the 2nd slot area is active the #2 slot snap works
                    if (aSlot_Control.slot2Active == true)
                    {
                        ///Slot 2 Snap
                        if ((CardPos.x >= S2x_Min && CardPos.x <= S2x_Max) && (CardPos.y <= S2y_Max && CardPos.y >= S2y_Min))
                        {
                            card.transform.position = S2_Snap;
                        }
                    }
                    //as long as the 3rd slot area is active the #3 slot snap works
                    if (aSlot_Control.slot3Active == true)
                    {
                        ///Slot 3 Snap
                        if ((CardPos.x >= S3x_Min && CardPos.x <= S3x_Max) && (CardPos.y <= S3y_Max && CardPos.y >= S3y_Min))
                        {
                            card.transform.position = S3_Snap;
                        }
                    }
                    //as long as the 4th slot area is active the #4 slot snap works
                    if (aSlot_Control.slot4Active == true)
                    {
                        ///Slot 4 Snap
                        if ((CardPos.x >= S4x_Min && CardPos.x <= S4x_Max) && (CardPos.y <= S4y_Max && CardPos.y >= S4y_Min))
                        {
                            card.transform.position = S4_Snap;
                        }
                    }
                }
            }
            //for Verb Investigate
            if (gameObject.name == "InvestigateButton")
            {
                //as long as the verb area is active and not locked the first slot snap works
                if (iSlot_Control.sAreaActive == true && locked == false)
                {
                    ///Slot 1 Snap
                    if ((CardPos.x >= S1x_Min && CardPos.x <= S1x_Max) && (CardPos.y <= S1y_Max && CardPos.y >= S1y_Min))
                    {
                        card.transform.position = S1_Snap;
                    }
                    //as long as the 2nd slot area is active the #2 slot snap works
                    if (iSlot_Control.slot2Active == true)
                    {
                        ///Slot 2 Snap
                        if ((CardPos.x >= S2x_Min && CardPos.x <= S2x_Max) && (CardPos.y <= S2y_Max && CardPos.y >= S2y_Min))
                        {
                            card.transform.position = S2_Snap;
                        }
                    }
                    //as long as the 3rd slot area is active the #3 slot snap works
                    if (iSlot_Control.slot3Active == true)
                    {
                        ///Slot 3 Snap
                        if ((CardPos.x >= S3x_Min && CardPos.x <= S3x_Max) && (CardPos.y <= S3y_Max && CardPos.y >= S3y_Min))
                        {
                            card.transform.position = S3_Snap;
                        }
                    }
                    //as long as the 4th slot area is active the #4 slot snap works
                    if ( iSlot_Control.slot4Active == true)
                    {
                        ///Slot 4 Snap
                        if ((CardPos.x >= S4x_Min && CardPos.x <= S4x_Max) && (CardPos.y <= S4y_Max && CardPos.y >= S4y_Min))
                        {
                            card.transform.position = S4_Snap;
                        }
                    }
                }
            }
            //for Verb Speak
            if(gameObject.name == "SpeakButton")
            {
                //as long as the verb area is active and not locked the first slot snap works
                if (sSlot_Control.sAreaActive == true && locked == false)
                {
                    ///Slot 1 Snap
                    if ((CardPos.x >= S1x_Min && CardPos.x <= S1x_Max) && (CardPos.y <= S1y_Max && CardPos.y >= S1y_Min))
                    {
                        card.transform.position = S1_Snap;
                    }
                    //as long as the 2nd slot area is active the #2 slot snap works
                    if (sSlot_Control.slot2Active == true)
                    {
                        ///Slot 2 Snap
                        if ((CardPos.x >= S2x_Min && CardPos.x <= S2x_Max) && (CardPos.y <= S2y_Max && CardPos.y >= S2y_Min))
                        {
                            card.transform.position = S2_Snap;
                        }
                    }
                    //as long as the 3rd slot area is active the #3 slot snap works
                    if (sSlot_Control.slot3Active == true)
                    {
                        ///Slot 3 Snap
                        if ((CardPos.x >= S3x_Min && CardPos.x <= S3x_Max) && (CardPos.y <= S3y_Max && CardPos.y >= S3y_Min))
                        {
                            card.transform.position = S3_Snap;
                        }
                    }
                    //as long as the 4th slot area is active the #4 slot snap works
                    if (sSlot_Control.slot4Active == true)
                    {
                        ///Slot 4 Snap
                        if ((CardPos.x >= S4x_Min && CardPos.x <= S4x_Max) && (CardPos.y <= S4y_Max && CardPos.y >= S4y_Min))
                        {
                            card.transform.position = S4_Snap;
                        }
                    }
                }
            }
        }
    }
}
