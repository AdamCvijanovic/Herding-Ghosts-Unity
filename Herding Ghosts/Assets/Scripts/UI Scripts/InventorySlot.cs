using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    public Transform childTransform;
    public DraggableItem currentItem;
    public int currentItemCount;

    public void OnDrop(PointerEventData eventData)
    {
        if(currentItem == null)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.transform.position = dropped.transform.position;
            //draggableItem.parentAfterDrag = transform;
            currentItem = draggableItem;
        }
    }

    public void AddItemToSlot(GameObject item)
    {
        item.transform.position = this.transform.position;
        item.transform.SetParent(this.transform);
        currentItem = item.GetComponent<DraggableItem>();
    }

    public void RemoveItemFromSlot()
    {
        currentItem = null;
    }


}
