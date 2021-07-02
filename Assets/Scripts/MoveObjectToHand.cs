using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToHand : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public SelectionManager selectionManager;
    public GameObject selectedObject = null;

    // Update is called once per frame
    void Update()
    {
        float[] forces = new float[2];

        forces[0] = _GlobalVariables.leftForce;
        forces[1] = _GlobalVariables.rightForce;
        Vector3 leftHandPos = leftHand.transform.position;
        Vector3 rightHandPos = rightHand.transform.position;

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

            if (forces[0] > 15.0)
            {
                selectedObject.transform.position = leftHandPos;
            }

            else if (forces[1] > 15.0)
            {
                selectedObject.transform.position = rightHandPos;
            }
        }
        
    }
}
