using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoughUI : MonoBehaviour
{
    public BakeryWorkbenchUI _bakeryWorkbenchUI;

    public Image image;
    public InventorySlot inventorySlot;

    public IngredientScriptableObject currentIngrdnt;

    public DoughType doughType;

    //currentDoughType

    //DoughTypeEnum

    //DoughFlatness
    public int flatnessLevel;
    public Sprite doughDefault;
    public Sprite doughHalfFlat;
    public Sprite doughFlat;


    private void Update()
    {

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

    public void UpdateDoughFlatness()
    {
        if(flatnessLevel < 2)
        {
            flatnessLevel++;
        }
        else
        {
            //flatnessLevel = 0;
           
        }

        switch (flatnessLevel)
        {
            case 0:
                image.sprite = doughDefault;
                break;
            case 1:
                image.sprite = doughHalfFlat;
                break;
            case 2:
                image.sprite = doughFlat;
                _bakeryWorkbenchUI.DeActivateRollingPin();
                _bakeryWorkbenchUI.ActivateInventoryPanel();
                break;

        }
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