using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BakeryWorkbenchUI : MonoBehaviour
{
    public BakeryWorkstation _bakeryWorksation;

    public GameObject workbenchPanel;

    public GameObject IngInventoryPanel;

    public Canvas canvas;

    [Header("Child References")]
    public DoughUI doughUI;
    public RollingPinUI rollingPinUI;

    public int baseDoughIndex = 0;

    public List<FoodScriptableObject> doughTypes = new List<FoodScriptableObject>();

    public List<Button> bakerySelectButtons = new List<Button>();

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

        GetDough();

        UpdateDoughTypeImage(IngredientItem.IngredientType.None);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetDough()
    {
        if (doughUI == null)
        {
            doughUI = GetComponentInChildren<DoughUI>();
            doughUI._bakeryWorkbenchUI = this;
        }
        else
        {
            doughUI._bakeryWorkbenchUI = this;
        }
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

    public void ActivateInventoryPanel()
    {
        if(IngInventoryPanel != null)
        {
            IngInventoryPanel.SetActive(true);
        }
    }

    public void DeActivateInventoryPanel()
    {
        if(IngInventoryPanel != null)
        {
            IngInventoryPanel.SetActive(false);
        }
    }

    public void ActivateRollingPin()
    {
        if (rollingPinUI != null)
        {
            rollingPinUI.gameObject.SetActive(true);
        }
    }

    public void DeActivateRollingPin()
    {
        if (rollingPinUI != null)
        {
            rollingPinUI.gameObject.SetActive(false);
        }
    }

    public void ActivateCookButton()
    {
        doughUI.GetComponent<Image>().sprite = cookedFoodPrefab.GetComponent<FoodItem>().foodSprite;
        _bakeryWorksation.ProcessFood(cookedFoodPrefab);
    }

    public void UpdateDragItem(Item item)
    {
        //**acvija change to enum dough image list
        doughUI.UpdateImage(item.sprRndr.sprite);
    }

    public void UpdateDoughTypeImage(IngredientItem.IngredientType ingType)
    {
        doughUI.UpdateDough(ingType);
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

    public void ActivateLeftCycleButton()
    {
        Debug.Log("Left Button pressed");
    }

    public void ActivateRightCycleButton()
    {
        Debug.Log("Right Button pressed");
    }

    public void FillInventory()
    {
        Debug.Log(_bakeryWorksation.GetInventoryItems());
    }

}
