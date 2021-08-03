using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squeezable : MonoBehaviour
{
    public GameObject destroyedVersion;
    public float strengthRequired;

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Update()
    {
        float[] forces = new float[2];

        forces[0] = _GlobalVariables.leftForce;
        forces[1] = _GlobalVariables.rightForce;

        //Debug.Log("Left force: " + forces[0] + ", Right force: " + forces[1]);

        /*
        if (forces[0] > strengthRequired)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        */

        if (_GlobalVariables.leftHasObject)
        {
            if (_GlobalVariables.leftObject == gameObject)
            {
                if (forces[0] > strengthRequired)
                {
                    Instantiate(destroyedVersion, transform.position, transform.rotation);
                    Destroy(gameObject);
                    _GlobalVariables.leftHasObject = false;
                    _GlobalVariables.leftObject = null;

                }
            }
        }

        if (_GlobalVariables.rightHasObject)
        {
            if (_GlobalVariables.rightObject == gameObject)
            {
                if (forces[1] > strengthRequired)
                {
                    Instantiate(destroyedVersion, transform.position, transform.rotation);
                    Destroy(gameObject);
                    _GlobalVariables.rightHasObject = false;
                    _GlobalVariables.rightObject = null;
                }
            }
        }

    }
}
