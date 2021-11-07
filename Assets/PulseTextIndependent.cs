using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseTextIndependent : MonoBehaviour
{
    private bool coroutineAllowed;
    public float delay;
    public float steps;
    public float growth;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(Pulse));
    }

    private IEnumerator Pulse()
    {
        for (float i = 0f; i <= 1f; i += steps)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x + growth, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y + growth, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z + growth, Mathf.SmoothStep(0f, 1f, i)))
                );
            yield return new WaitForSeconds(delay);
        }


        for (float i = 0f; i <= 1f; i += steps)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x - growth, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y - growth, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z - growth, Mathf.SmoothStep(0f, 1f, i)))
                );
            yield return new WaitForSeconds(delay);
        }
        StartCoroutine(nameof(Pulse));
    }
}
