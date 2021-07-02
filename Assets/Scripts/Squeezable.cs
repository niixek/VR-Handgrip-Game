using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squeezable : MonoBehaviour
{
    public GameObject destroyedVersion;

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

        if (forces[0] > 30.0)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
