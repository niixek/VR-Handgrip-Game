using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayGripValue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool leftHand;
    void Update()
    {
        if (leftHand)
        {
            text.text = _GlobalVariables.leftForce.ToString();
        }
        else
        {
            text.text = _GlobalVariables.rightForce.ToString();
        }
       
    }
}
