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
            int gripval = Mathf.RoundToInt(_GlobalVariables.leftForce);
            text.text = gripval.ToString();
        }
        else
        {
            int gripval = Mathf.RoundToInt(_GlobalVariables.rightForce);
            text.text = gripval.ToString();
        }
       
    }
}
