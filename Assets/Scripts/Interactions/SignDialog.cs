using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignDialog : BasicInteraction
{
    public string[] dialog;
    int dialogCounter=0;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public override bool Interaction()
    {
        bool succes = false;

        NextDialog();

        return succes;
    }

    private void NextDialog()
    {
        if (dialogCounter == dialog.Length)
        {
            EndDialog();
        }
        else
        {
            gameManager.ShowText(dialog[dialogCounter]);
            dialogCounter++;
        }
    }

    private void EndDialog() 
    {
        gameManager.HideText();
        dialogCounter = 0;
    }
}
