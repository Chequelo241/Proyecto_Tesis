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
        /*if (Input.GetKeyDown(KeyCode.P)) 
        {
            player.incrementXP(5);
            Debug.Log(player.XP);
        }*/
        xpBar.UpdateInfo(player.XP);
        HpBar.UpdateInfo(player.Hp.currentValue);
        
    }

    public void changeHp(int value) 
    {
        player.changeHealth(Random.Range(1,value));
    }
}
