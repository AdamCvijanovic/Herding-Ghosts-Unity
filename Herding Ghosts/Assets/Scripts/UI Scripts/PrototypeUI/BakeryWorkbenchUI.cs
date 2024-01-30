using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BakeryWorkbenchUI : MonoBehaviour
{
    public BakeryWorkstation _bakeryWorksation;

    public GameObject workbenchPanel;

    public Canvas canvas;

    public DraggableItem baseIngItem;

    public List<Button> bakeryButtonOptions = new List<Button>();

    public GameObject cookedFoodPrefab;

    public FoodPrepPanelUI foodPrepPanel;

    public GameObject itemGrid;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        _bakeryWorksation = FindObjectOfType<BakeryWorkstation>();
        //foodPrepPanel = GetComponentInChildren<FoodPrepPanelUI>();



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetWindowWorkstation(BakeryWorkstation bakeryWorkstationIn)
    {
        _bakeryWorksation = bakeryWorkstationIn;
    }

    public void ActivatePanel()
    {
        workbenchPanel.SetActive(true);
        FillInventory();
    }

    public void DeActivatePanel()
    {
        workbenchPanel.SetActive(false);
    }

    public void ActivateCookButton()
    {
        baseIngItem.GetComponent<Image>().sprite = cookedFoodPrefab.GetComponent<FoodItem>().foodSprite;
        _bakeryWorksation.ProcessFood(cookedFoodPrefab);
    }

    public void UpdateDragItem(Item item)
    {
        baseIngItem.image.sprite = item.sprRndr.sprite;
    }

    public void ActivateBaseIngredientButton(GameObject baseIngdntPrefab)
    {
        // Activate Image in centre, Use sprite assigned to ingredient
        if(foodPrepPanel != null)
        {
            if (foodPrepPanel.ingredientBase != null)
            {
                foodPrepPanel.ingredientBase.gameObject.SetActive(true);
                foodPrepPanel.ingredientBase.GetComponent<Image>().sprite = baseIngdntPrefab.GetComponent<FoodItem>().foodSprite;

                cookedFoodPrefab = baseIngdntPrefab;
            }
        }
        else
        {
            Debug.LogError("No foodPrepPanel Found");
        }
    }

    public void FillInventory()
    {
        Debug.Log(_bakeryWorksation.GetInventoryItems());
    }

}
