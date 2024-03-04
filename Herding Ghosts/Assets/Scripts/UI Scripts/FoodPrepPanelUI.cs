using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class FoodPrepPanelUI : MonoBehaviour
{
    public BakeryWorkbenchUI _bakeryWorkbenchUI;

    public GameObject ingredientBase;
    public InventorySlot ingredientSlotOne;


    // Start is called before the first frame update
    void Start()
    {
        _bakeryWorkbenchUI = FindObjectOfType<BakeryWorkbenchUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        //if (currentItem == null)
        //{
        //    GameObject dropped = eventData.pointerDrag;
        //    DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        //    draggableItem.transform.position = dropped.transform.position;
        //    //draggableItem.parentAfterDrag = transform;
        //}

        //else if (ingredientSlotTwo.currentItem == null)
        //{
        //    eventData.pointerDrag.GetComponent<DraggableItem>().parentAfterDrag = ingredientSlotTwo.transform;
        //    ingredientSlotTwo.OnDrop(eventData);
        //}

    }

    public InventorySlot AddToPrepPanel()
    {
        if (ingredientSlotOne.currentItem == null)
        {
            return ingredientSlotOne;
        }
        else
        {
            return null;
        }
    }

    public void SetParentAfterDrag(DraggableItem dragItem)
    {
        if (ingredientSlotOne.currentItem == null)
        {
            dragItem.parentAfterDrag = ingredientSlotOne.transform;
        }
        else
        {
            //do nothing
            return;
        }
    }

    public void AddItemToSlot(GameObject item)
    {
        item.transform.position = this.transform.position;
        item.transform.SetParent(this.transform);
    }

    public void RemoveItemFromSlot()
    {
        //currentItem = null;
    }

}
