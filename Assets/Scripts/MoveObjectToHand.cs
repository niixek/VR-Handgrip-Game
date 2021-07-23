using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToHand : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public SelectionManager selectionManager;
    public GameObject selectedObject = null;
    public int gripSensitivity;

    // Update is called once per frame
    void Update()
    {
        float[] forces = new float[2];

        forces[0] = _GlobalVariables.leftForce;
        forces[1] = _GlobalVariables.rightForce;

        GameObject selectedObject = selectionManager.selectedObject;

        if (selectedObject != null)
        {
            //Debug.Log(selectedObject);

            //Debug.Log("Left force: " + forces[0] + ", Right force: " + forces[1]);

            /*
            if (forces[0] > 30.0)
            {
                Instantiate(destroyedVersion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            */

            if (forces[0] > gripSensitivity)
            {
                selectedObject.transform.parent = leftHand.transform;
                selectedObject.transform.localPosition = new Vector3(0, -0.05f, 0.15f);
                _GlobalVariables.leftHasObject = true;
                if (selectedObject == _GlobalVariables.rightObject)
                {
                    _GlobalVariables.rightHasObject = false;
                    _GlobalVariables.rightObject = null;
                }
                _GlobalVariables.leftObject = selectedObject;
                if (_GlobalVariables.rightObject == null && !_GlobalVariables.rightHasObject)
                {
                    Debug.Log("Right works");
                }
            }

            else if (forces[1] > gripSensitivity)
            {
                selectedObject.transform.parent = rightHand.transform;
                selectedObject.transform.localPosition = new Vector3(0, -0.05f, 0.15f);
                _GlobalVariables.rightHasObject = true;
                if (selectedObject == _GlobalVariables.leftObject)
                {
                    _GlobalVariables.leftHasObject = false;
                    _GlobalVariables.leftObject = null;
                }
                _GlobalVariables.rightObject = selectedObject;
                if (_GlobalVariables.leftObject == null && !_GlobalVariables.leftHasObject)
                {
                    Debug.Log("left works");
                }

            }
        }
        
    }
}
