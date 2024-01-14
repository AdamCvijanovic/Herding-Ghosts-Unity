using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;

    public Transform currentParent;
    public Transform parentAfterDrag;

    public IngredientItem item;

    public void Start()
    {
        currentParent = transform.parent;

        if(item != null && image != null)
        {
            if(item.itemSprite != null)
                image.sprite = item.itemSprite;
        }
    }

    private void Update()
    {
        UpdateItemImage();
    }

    public void UpdateItemImage()
    {
        if (item != null && image != null)
        {
            if (item.itemSprite != null)
            {
                Debug.Log("item sprite not null");
                image.sprite = item.itemSprite;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
