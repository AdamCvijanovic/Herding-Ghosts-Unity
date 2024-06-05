using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoughUI : MonoBehaviour
{
    public Image image;
    public InventorySlot inventorySlot;

    public IngredientScriptableObject currentIngrdnt;

    public DoughType doughType;

    //currentDoughType

    //DoughTypeEnum

    private void Update()
    {
        //**acvija I hate leaving this on update, so expensive,
        //we should find a way to make this update ONLY on the drop and pickup events
        // To do this we need some way of referencing the Dough from the Slot
        // Maybe some inheritence doohickey? 
        //UpdateCurrentIngredient();
    }

    public void UpdateCurrentIngredient()
    {
        //if(inventorySlot.currentItem != null)
        {
            currentIngrdnt = inventorySlot.currentItem.ingScrptObj;
            UpdateDoughIngredient(currentIngrdnt);
        }
    }

    
    
    public void UpdateDoughIngredient(IngredientScriptableObject ingScrptObj)
    {
        currentIngrdnt = ingScrptObj;
        IngredientItem.IngredientType ingType = ingScrptObj.itemPrefab.GetComponent<IngredientItem>().GetIngredientType();

        Debug.Log("Update DoughIngredient Here: " + ingScrptObj.name);
        UpdateDough(ingType);
    }

    public void UpdateDough(IngredientItem.IngredientType ingType)
    {
        Debug.Log("Update Dough Here: " + ingType);
        switch (ingType)
        {
            case IngredientItem.IngredientType.Apple:
                UpdateImage(doughType.appleDough);
                break;
            case IngredientItem.IngredientType.Strawberry:
                UpdateImage(doughType.strawberryDough);
                break;
            case IngredientItem.IngredientType.Carrot:
                UpdateImage(doughType.carrotDough);
                break;
            default:
                UpdateImage(doughType.plainDough);
                break;
        }
    }
    public void UpdateImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}



[System.Serializable]
public struct DoughType
{
    public Sprite plainDough;
    public Sprite appleDough;
    public Sprite strawberryDough;
    public Sprite carrotDough;
}
//Dough's