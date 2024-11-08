using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour,IDropHandler
{
    public DragHandler drag;
    public GameObject item;
    public int xpReward=50;


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        if (!item) 
        {
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
            if (item.transform.CompareTag("correcto") && item.transform.parent.CompareTag("respuesta")) 
            {

                Transform puzzle = transform.parent.parent; // El objeto "puzzle"
                GameObject puertaUno = puzzle.parent.gameObject; // El objeto "puerta uno"
                GameObject door = puertaUno.transform.parent.gameObject; // El objeto "door" con la etiqueta "Door"
                
                if (door.CompareTag("Door"))
                {
                    GameManager.instance.IncrementPlayerXP(xpReward);
                    Destroy(door);
                }
            }
        }
    }
    void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            Debug.Log("Remover");
            item = null;
        }
    }
}
