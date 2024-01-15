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

    public InventorySlot currentSlot;

    public IngredientItem item;

    public void Start()
    {
        currentParent = transform.parent;
        UpdateCurrentSlot();

        if (item != null && image != null)
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
                image.sprite = item.itemSprite;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        currentSlot.RemoveItemFromSlot();
        currentSlot = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        currentParent = transform.parent;
        UpdateCurrentSlot();
        image.raycastTarget = true;
    }

    public void UpdateCurrentSlot()
    {
        if (currentParent.GetComponent<InventorySlot>() != null) currentSlot = currentParent.GetComponent<InventorySlot>();
    }
}
