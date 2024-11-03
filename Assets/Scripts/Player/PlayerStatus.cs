using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [System.Serializable]
    public struct Stat 
    {
        public int currentValue;
        public int maxvalue;
    }
    public Stat Hp;
    public int XP;
    public const int MaxXp=100;

    public void changeHealth(int value) 
    {
        Hp.currentValue = Mathf.Clamp(Hp.currentValue+value,0,Hp.maxvalue);
    }
    public void incrementXP(int newXP)
    {
        XP += newXP;
        if (XP > MaxXp) { 
            XP = 0;
            Hp.maxvalue = Hp.maxvalue + 1;
        }
    }
}
