using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : StatusBar
{
    public float hitDelay = 0.5f;
    public Slider hitSlider;
    private int oldValue;

    float nextUpdate;
    bool updating = false;

    public override void ChangeMaxValue(int maxValue)
    {
        base.ChangeMaxValue(maxValue);
        hitSlider.maxValue = maxValue;
    }
    public override void UpdateInfo(int newValue)
    {
        base.UpdateInfo(newValue);
        if (newValue<oldValue && !updating)
        {
            nextUpdate = Time.time + hitDelay;
            updating = true;
        }
        if (Time.time>nextUpdate)
        {
            if (newValue<oldValue)
            { oldValue -= 1; }
            else 
            { oldValue = newValue; }
            if (oldValue==newValue)
            { updating = false; }
        }
        hitSlider.value = oldValue;
    }
}
