using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarBase : MonoBehaviour
{
    public Slider slider;
    private bool maxValSet = false;

    public void SetBarToMaxValue(float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;

        maxValSet = true;
    }
    public void SetCurrentBarValue(float value)
    {
        if(!maxValSet)
        {
            Debug.LogError("Max value for " + gameObject.name + " not set! Please call 'SetBarToMaxValue' first before calling 'SetCurrentBarValue'.");
            return;
        }
        else
        {
            slider.value = value;
        }
    }
}
