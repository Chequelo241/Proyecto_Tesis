using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusHUD : MonoBehaviour
{
    public PlayerStatus player;
    public StatusBar xpBar;
    public HpBar HpBar;

    void Start()
    {
        xpBar.ChangeMaxValue(PlayerStatus.MaxXp);
        HpBar.ChangeMaxValue(player.Hp.maxvalue);
    }

    void Update()
    {
        xpBar.UpdateInfo(player.XP);
        HpBar.ChangeMaxValue(player.Hp.maxvalue);
        HpBar.UpdateInfo(player.Hp.currentValue);
    }

    public void ChangeHp(int value) 
    {
        player.ChangeHealth(Random.Range(1,value));
    }
}
