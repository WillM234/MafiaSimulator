using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHover : MonoBehaviour
{
    public bool mouseIsOver;
    public GameObject highlightObject;
    private void OnMouseEnter()
    {
        mouseIsOver = true;
    }
    private void OnMouseExit()
    {
        mouseIsOver = false;
    }
    private void Update()
    {
        if (mouseIsOver)
        {
            highlightObject.SetActive(true);
        }
        else
        {
            highlightObject.SetActive(false);
        }
    }
}
