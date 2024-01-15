using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class FoodPrepPanelUI : MonoBehaviour
{
    public BakeryWorkbenchUI _bakeryWorkbenchUI;

    public DraggableItem ingredientBase;
    public InventorySlot ingredientSlotOne;
    public InventorySlot ingredientSlotTwo;

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
        if (ingredientSlotOne.currentItem == null)
        {
            ingredientSlotOne.OnDrop(eventData);
        }
        else if (ingredientSlotTwo.currentItem == null)
        {
            ingredientSlotTwo.OnDrop(eventData);
        }

        //PrepPanel
        addToPrepPanel();
    }

    public void addToPrepPanel()
    {

       //if(ingredientOne != null)
    }

}
