using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI statLabel;
    public virtual void ChangeMaxValue(int maxValue) 
    {
        slider.maxValue = maxValue;
    }

    public virtual void UpdateInfo(int newValue)
    {
        slider.value=newValue;
        if (statLabel!=null) 
        {
            statLabel.text = newValue.ToString();
        }
    }
}
