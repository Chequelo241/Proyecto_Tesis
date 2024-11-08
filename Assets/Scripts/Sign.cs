using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public string text="";
    GameManager gameManager;
    private void Start()
    {
        gameManager= GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            gameManager.ShowText(text);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameManager.HideText();
    }
}
