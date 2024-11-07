using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
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
        public const int MaxXp = 100;

        void Start()
        {
            Hp.maxvalue = 100;
            Hp.currentValue = Hp.maxvalue;
            XP = 0;
        }

        public void ChangeHealth(int value)
        {
            Hp.currentValue = Mathf.Clamp(Hp.currentValue + value, 0, Hp.maxvalue);
        }

        public void IncrementXP(int newXP)
        {
            XP += newXP;
            if (XP >= MaxXp)
            {
                XP = 0;
                Hp.maxvalue += 10;
                Hp.currentValue = Hp.maxvalue;
            }
        }
    }

