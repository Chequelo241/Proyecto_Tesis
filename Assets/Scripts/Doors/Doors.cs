using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject canvasPuerta1; // Asigna el Canvas en el Inspector

    [SerializeField] Sprite nuevoSprite; // Asigna el nuevo sprite en el Inspector
    Sprite viejoSprite;
    private SpriteRenderer DoorSprite;

    private void Start()
    {
        
        DoorSprite = GetComponent<SpriteRenderer>();
        viejoSprite = DoorSprite.sprite;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player")) 
        {
            Debug.Log("el jugador choco");
            DoorSprite.sprite = nuevoSprite;
            canvasPuerta1.SetActive(true);
        } ;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("el jugador se alejo");
            DoorSprite.sprite = viejoSprite;
            canvasPuerta1.SetActive(false);
        };
    }
}
