using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GripControllerHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _GlobalVariables.mainThreadActive = true;
        CheckAndStartCommunicator();

        _GlobalVariables.leftForce = _GlobalVariables.UNINITIALIZED;
        _GlobalVariables.rightForce = _GlobalVariables.UNINITIALIZED;
        _GlobalVariables.maxGripStrength[0] = _GlobalVariables.UNINITIALIZED;
        _GlobalVariables.maxGripStrength[1] = _GlobalVariables.UNINITIALIZED;
    }

    private void CheckAndStartCommunicator()
    {
        if (!_GlobalVariables.communicatorThreadExists)
        {
            _GlobalVariables.killCommunicator = false;
            _GlobalVariables.keyboardActive = false;
            Debug.Log("Create arduino input thread");
            Thread thread = new Thread(ArduinoCommunicator.BeginConnection);
            Debug.Log("Start arduino input thread");
            thread.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndStartCommunicator();

        if (!_GlobalVariables.portFound)
        {           
            //if the port is not discovered, write message and listen for keyboard command
            Debug.Log("Port not found");
        }
        else if (!_GlobalVariables.isReadingArduinoData)
        {   //if the port is found but left and right force are not being updated
            Debug.Log("Port found, but data not read");
        }
        else
        {
           // Debug.Log("data being read");
        }


    }

    private void OnDestroy()
    {
        _GlobalVariables.mainThreadActive = false;
    }
}
