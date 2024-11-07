using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusHUD : MonoBehaviour
{
    public StatusBar xpBar;
    public HpBar HpBar;

    void Start()
    {
        xpBar.ChangeMaxValue(PlayerStatus.MaxXp);
        HpBar.ChangeMaxValue(GameManager.instance.playerStatus.Hp.maxvalue);
    }

    void Update()
    {
        xpBar.UpdateInfo(GameManager.instance.playerStatus.XP);
        HpBar.ChangeMaxValue(GameManager.instance.playerStatus.Hp.maxvalue);
        HpBar.UpdateInfo(GameManager.instance.playerStatus.Hp.currentValue);
    }

    public void ChangeHp(int value)
    {
        GameManager.instance.ChangePlayerHealth(Random.Range(1, value));
    }
}

