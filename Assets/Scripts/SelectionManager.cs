using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    public GameObject selectedObject = null;

    private Transform _selection;

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(_GlobalVariables.selectedObject);
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            selectedObject = null;
            _selection = null;
            _GlobalVariables.selectedObject = null;
        }


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Selectable")
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
                selectedObject = hit.collider.gameObject;
                _GlobalVariables.selectedObject = selectedObject;
                //Debug.Log(selectedObject);
            }

            _selection = selection;
        }
    }
}
