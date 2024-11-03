using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public static GameObject itemDragging;

    Vector3 startPosition;
    Transform startParent;
    Transform dragParent;
    
    void Start()
    {
        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("empieza a arrastrar");
        itemDragging = gameObject;
        //posiciones.
        startPosition = transform.position;
        startParent = transform.parent;
        //Nuevo parent
        transform.SetParent(dragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        itemDragging = null;
        if (transform.parent == dragParent || transform.tag != "correcto")
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
            Debug.Log("no seas wacho");
        }
        else 
        {
            Debug.Log("lo soltaste en donde va");
        }
    }
}
