using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyDestruction : MonoBehaviour
{
    public bool inCurrencyList;
    private void Update()
    {
        if(!inCurrencyList)
        {
            Destroy(gameObject);
        }
    }
}
