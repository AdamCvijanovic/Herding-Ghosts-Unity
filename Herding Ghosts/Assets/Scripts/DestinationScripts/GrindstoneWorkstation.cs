using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindstoneWorkstation : MonoBehaviour
{
    public Interactable interactable;

    //inventory references a seperate inventory componenet
    public WorkstationInventory _inventory;

    public GrindstoneWorkbenchUI _grindstoneWorkbenchUI;

    public Item currentItem;

    public Sprite tempCookedIngSprite;

    public float maxDistance;
    public float dstToPlayer;

    public GameObject flourPrefab;
    public Transform itemSpawnTransform;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();

        _inventory = GetComponent<WorkstationInventory>();



        if (_grindstoneWorkbenchUI == null)
        {
            _grindstoneWorkbenchUI = FindObjectOfType<GrindstoneWorkbenchUI>();
            _grindstoneWorkbenchUI.SetWindowWorkstation(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistanceDisableUI();
    }


    public void UseWorkbench()
    {
        Debug.Log("Using Workbench");
        _grindstoneWorkbenchUI.ActivatePanel();

        WorkstationInventory wkstnInventory = GetComponent<WorkstationInventory>();

    }

    public void PlayerDistanceDisableUI()
    {
        dstToPlayer = Vector3.Distance(FindObjectOfType<Player>().transform.position, transform.position);
        if (dstToPlayer >= maxDistance)
        {
            _grindstoneWorkbenchUI.DeActivatePanel();
        }
    }

    public void UpdateCurrentItem(Item item)
    {
        currentItem = item;
        _grindstoneWorkbenchUI.UpdateDragItem(item);
    }

    public void InventoryCheck(Item item)
    {
        //RecipeObject tempRecipe = null;
        Debug.Log("The Item is " + item.gameObject.name);

        if (_inventory._items.Count > 0 && _inventory._items.Count >= _inventory.maxItems)
        {
            UpdateCurrentItem(item);
        }
    }

    public void ProcessFood()
    {
        if (currentItem != null)
        {
            currentItem.sprRndr.sprite = tempCookedIngSprite;
            if (currentItem.GetComponent<IngredientProperties>() != null)
            {
                currentItem.GetComponent<IngredientProperties>().AddProperty(IngredientProperties.IngredientGroup.Chopped);
            }
        }
    }

    public void SpawnFlour()
    {
        Instantiate(flourPrefab, itemSpawnTransform);
    }

}
