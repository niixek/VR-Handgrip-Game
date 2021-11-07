using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseText : MonoBehaviour
{

    private bool coroutineAllowed;
    public Vector3 initialSize;
    public float speed = 0.02f;

    private void Start()
    {
        coroutineAllowed = true;
    }

    public void Pulse()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(nameof(StartPulsing));
        }
    }

    private IEnumerator StartPulsing()
    {
        coroutineAllowed = false;
        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.01f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.01f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z + 0.01f, Mathf.SmoothStep(0f, 1f, i)))
                );
            yield return new WaitForSeconds(speed);
        }


        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.01f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.01f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z - 0.01f, Mathf.SmoothStep(0f, 1f, i)))
                );
            yield return new WaitForSeconds(speed);
        }
        coroutineAllowed = true;
        Pulse();
    }

    public void StopPulse()
    {
        StopCoroutine(nameof(StartPulsing));
        transform.localScale = initialSize;
        coroutineAllowed = true;
    }
}
