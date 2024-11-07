using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour,IDropHandler
{
    public DragHandler drag;
    public GameObject item;


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
                // Destruir un solo objeto con la etiqueta "door"
                GameObject door = GameObject.FindWithTag("Door");
                if (door != null)
                {
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
