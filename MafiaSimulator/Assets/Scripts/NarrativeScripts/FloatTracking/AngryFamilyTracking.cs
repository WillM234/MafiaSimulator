using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryFamilyTracking : MonoBehaviour
{
    public bool OneTime;
    private NarrativeController N_Control;
    private void Awake()
    {
        N_Control = GetComponent<NarrativeController>();
        OneTime = true;
    }
    void Update()
    {
        if(!OneTime)
        {
            AddToAFamily();
        }
    }
    public void SetOneTime()
    {
        OneTime = false;
    }
    void AddToAFamily()
    {
        N_Control.AngryFamily += 1;
        OneTime = true;
    }
}