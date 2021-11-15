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

    public bool leftHand;

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
        slider.maxValue = getSqueezeMaxValue();
        slider.minValue = getSqueezeMinValue();
        if (leftHand)
        {
            if (_GlobalVariables.leftHasObject)
            {
                slider.value = _GlobalVariables.leftForce;
            }
            else
            {
                slider.value = 0;
            }
        }
        else
        {
            if (_GlobalVariables.rightHasObject)
            {
                slider.value = _GlobalVariables.rightForce;
            }
            else
            {
                slider.value = 0;
            }
        }
 
        fill.color = Color.Lerp(minHealthColor, maxHealthColor, (float)slider.value / maxGrip);
        //Debug.Log(slider.value);
    }

    private float getSqueezeMaxValue()
    {
        if (leftHand)
        {
            if (_GlobalVariables.leftHasObject)
            {
                return _GlobalVariables.leftObject.GetComponent<Squeezable>().strengthRequired;
            }
        }
        else if (!leftHand)
        {
            if (_GlobalVariables.rightHasObject)
            {
                return _GlobalVariables.rightObject.GetComponent<Squeezable>().strengthRequired;
            }
        }

        return 100f;
    }
    private float getSqueezeMinValue()
    {
        if (leftHand)
        {
            if (_GlobalVariables.leftHasObject)
            {
                return _GlobalVariables.leftObject.GetComponent<FruitWeight>().weight;
            }
        }
        else if (!leftHand)
        {
            if (_GlobalVariables.rightHasObject)
            {
                return _GlobalVariables.rightObject.GetComponent<FruitWeight>().weight;
            }
        }
        
        return 0f;
    }
}
