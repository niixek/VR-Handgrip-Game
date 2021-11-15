using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameOver : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (_GlobalVariables.numObjectsLeft == 0)
        {
            Debug.Log("GameOver");
        }
    }
}
