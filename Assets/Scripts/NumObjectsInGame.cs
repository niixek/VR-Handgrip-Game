using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumObjectsInGame : MonoBehaviour
{

    public int numObjects = 0;
    // Start is called before the first frame update
    void Start()
    {
        _GlobalVariables.numObjectsLeft = numObjects;   
    }
}
