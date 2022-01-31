using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEmitter : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float laserMaxLength = 5f;


    // Start is called before the first frame update
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        lineRenderer.SetPositions(initLaserPositions);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, DetectHit(transform.position, laserMaxLength, Vector3.forward));
    }

    Vector3 DetectHit(Vector3 startPos, float distance, Vector3 direction)
    {
        Ray ray = new(startPos, direction);
        Vector3 endPos = startPos + (distance * direction);

        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            endPos = hit.point;
            return endPos;
        }

        return endPos;
    }
}
