using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    public GameObject handPrefab;
    public InputDeviceCharacteristics characteristics;

    private Animator handAnimator;
    private InputDevice inputDevice;

    void Start()
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);

        if (devices.Count > 0)
        {
            inputDevice = devices[0];
            handAnimator = handPrefab.GetComponent<Animator>();
        }

    }

    void UpdateHandAnimation()
    {
        if (inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("TriggerStrength", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("TriggerStrength", 0);
        }

        if (inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("GripStrength", gripValue);
        }
        else
        {
            handAnimator.SetFloat("GripStrength", 0);
        }
    }

    void Update()
    {
        if (!inputDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            UpdateHandAnimation();
        }
    }
}
