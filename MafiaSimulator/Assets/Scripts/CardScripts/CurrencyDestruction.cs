using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyDestruction : MonoBehaviour
{
    private TimePasses timePasses;
    public bool inCurrencyList;
    private void Awake()
    {
        timePasses = GameObject.Find("TimePasses").GetComponent<TimePasses>();
    }
    private void Update()
    {
        if(!inCurrencyList)
        {
            timePasses.cardInSnap = false;
            Destroy(gameObject);
        }
    }
}
