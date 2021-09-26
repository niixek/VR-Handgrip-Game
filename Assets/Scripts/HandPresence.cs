using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    public GameObject handPrefab;
    public int gripSensitivity;

    public Animator handAnimator;

    void UpdateHandAnimation()
    {
        float[] forces = new float[2];

        forces[0] = _GlobalVariables.leftForce;
        forces[1] = _GlobalVariables.rightForce;

        if (handPrefab.name == "LeftHand Variant" && forces[0] > 2)
        {
            handAnimator.SetFloat("GripStrength", forces[0] / gripSensitivity);
        }
        else if (handPrefab.name == "RightHand Variant" && forces[1] > 1)
        {
            handAnimator.SetFloat("GripStrength", forces[1] / gripSensitivity);
        }
        else
        {
            handAnimator.SetFloat("GripStrength", 0);
        }


    }

    void Update()
    {
            UpdateHandAnimation();
    }
}
