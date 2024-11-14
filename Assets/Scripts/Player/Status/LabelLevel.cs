using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class LabelLevel : MonoBehaviour
{
    public TextMeshProUGUI statLabel;
    public void UpdateInfo(int newValue)
    {
        if (statLabel != null)
        {
            statLabel.text = newValue.ToString();
        }
    }
}
