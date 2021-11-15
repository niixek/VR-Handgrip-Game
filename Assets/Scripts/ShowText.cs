using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{

    public SelectionManager selectionManager;
    public GameObject text;
    public GameObject fruit;

    // Update is called once per frame
    void Update()
    {
        GameObject selectedObject = selectionManager.selectedObject;
        if (selectedObject != null)
        {
            if (selectedObject != _GlobalVariables.leftObject && selectedObject != _GlobalVariables.rightObject)
            {
                if (selectedObject == fruit)
                {
                    text.SetActive(true);
                }
                else
                {
                    text.SetActive(false);
                }
            }
            else
            {
                text.SetActive(false);
            }            
        }
        else
        {
            text.SetActive(false);
        }
    }
}
