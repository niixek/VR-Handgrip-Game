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
}
