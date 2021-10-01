using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColorChanger : MonoBehaviour
{
    private Slider slider;

    public int maxGrip = 100;
    public Image fill;

    public Color maxHealthColor = Color.green;
    public Color minHealthColor = Color.red;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = maxGrip;
        slider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        fill.color = Color.Lerp(minHealthColor, maxHealthColor, (float)slider.value / maxGrip);
        //Debug.Log(slider.value);
    }
}
