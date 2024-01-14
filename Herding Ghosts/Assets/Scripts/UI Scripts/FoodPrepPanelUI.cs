using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class FoodPrepPanelUI : MonoBehaviour
{
    public DraggableItem ingredientBase;
    public InventorySlot ingredientOne;
    public InventorySlot ingredientTwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (ingredientOne == null)
        {
            ingredientOne.OnDrop(eventData);
        }

        if (ingredientTwo == null)
        {
            ingredientTwo.OnDrop(eventData);
        }

        //PrepPanel
        addToPrepPanel();
    }

    public void addToPrepPanel()
    {
       //if(ingredientOne != null)
    }

}
