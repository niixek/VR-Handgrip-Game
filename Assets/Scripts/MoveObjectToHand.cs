using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToHand : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public SelectionManager selectionManager;
    public GameObject[] objOrigPos;
    public int gripSensitivity;
    public float selectedFruitWeight;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_GlobalVariables.leftForce);
        float[] forces = new float[2];

        forces[0] = _GlobalVariables.leftForce;
        forces[1] = _GlobalVariables.rightForce;

        GameObject selectedObject = selectionManager.selectedObject;

        /*
        if (selectedObject != null)
        {
            Debug.Log(selectedObject.GetComponent<FruitWeight>().weight);
        }
        */
        //Debug.Log(_GlobalVariables.leftHasObject);

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

            if (!_GlobalVariables.leftHasObject && forces[0] >= selectedObject.GetComponent<FruitWeight>().weight)
            {
                /*
                if (_GlobalVariables.leftHasObject)
                {
                    _GlobalVariables.leftObject.transform.parent = null;
                    _GlobalVariables.leftObject.transform.position = _GlobalVariables.leftObject.GetComponent<PositionHolder>().origPos;
                }
                */

                selectedObject.transform.parent = leftHand.transform;
                selectedObject.transform.localPosition = new Vector3(0, -0.05f, 0.15f);
                _GlobalVariables.leftHasObject = true;
                if (selectedObject == _GlobalVariables.rightObject)
                {
                    _GlobalVariables.rightHasObject = false;
                    _GlobalVariables.rightObject = null;
                    _GlobalVariables.rightHasObject = false;
                }
                _GlobalVariables.leftObject = selectedObject;

                
                /*
                if (_GlobalVariables.rightObject == null && !_GlobalVariables.rightHasObject)
                {
                    Debug.Log("Right works");
                }
                */
            }

            else if (!_GlobalVariables.rightHasObject && forces[1] >= selectedObject.GetComponent<FruitWeight>().weight)
            {
                selectedObject.transform.parent = rightHand.transform;
                selectedObject.transform.localPosition = new Vector3(0, -0.05f, 0.15f);
                _GlobalVariables.rightHasObject = true;
                if (selectedObject == _GlobalVariables.leftObject)
                {
                    _GlobalVariables.leftHasObject = false;
                    _GlobalVariables.leftObject = null;
                    _GlobalVariables.leftHasObject = false;
                }
                _GlobalVariables.rightObject = selectedObject;

                /*
                if (_GlobalVariables.leftObject == null && !_GlobalVariables.leftHasObject)
                {
                    Debug.Log("left works");
                }
                */

            }
        }
        else if (_GlobalVariables.leftHasObject)
        {
            //Debug.Log("left has object");
            if (forces[0] < _GlobalVariables.leftObject.GetComponent<FruitWeight>().weight)
            {
                _GlobalVariables.leftObject.transform.parent = null;
                _GlobalVariables.leftObject.transform.position = _GlobalVariables.leftObject.GetComponent<PositionHolder>().origPos;
                _GlobalVariables.leftObject.transform.rotation = _GlobalVariables.leftObject.GetComponent<PositionHolder>().origRot;
                _GlobalVariables.leftHasObject = false;
            }
        }
        else if (_GlobalVariables.rightHasObject)
        {
            if (forces[1] < _GlobalVariables.rightObject.GetComponent<FruitWeight>().weight)
            {
                _GlobalVariables.rightObject.transform.parent = null;
                _GlobalVariables.rightObject.transform.position = _GlobalVariables.rightObject.GetComponent<PositionHolder>().origPos;
                _GlobalVariables.rightObject.transform.rotation = _GlobalVariables.rightObject.GetComponent<PositionHolder>().origRot;
                _GlobalVariables.rightHasObject = false;
            }
        }
    }
}
