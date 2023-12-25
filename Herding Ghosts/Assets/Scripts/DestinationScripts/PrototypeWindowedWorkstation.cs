using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeWindowedWorkstation : MonoBehaviour
{
    public Interactable interactable;

    //inventory references a seperate inventory componenet
    public WorkstationInventory _inventory;

    public WorkbenchUIPrototype _workbenchUIPrototype;

    public Item currentItem;

    public Sprite tempCookedIngSprite;

    public float maxDistance;
    public float dstToPlayer;


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();

        _inventory = GetComponent<WorkstationInventory>();



        if (_workbenchUIPrototype == null)
        {
            _workbenchUIPrototype = FindObjectOfType<WorkbenchUIPrototype>();
            _workbenchUIPrototype.SetWindowWorkstation(this);
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
        _workbenchUIPrototype.ActivatePanel();

        WorkstationInventory wkstnInventory = GetComponent<WorkstationInventory>();

    }

    public void PlayerDistanceDisableUI()
    {
        dstToPlayer = Vector3.Distance(FindObjectOfType<Player>().transform.position, transform.position);
        if (dstToPlayer >= maxDistance)
        {
            _workbenchUIPrototype.DeActivatePanel();
        }
    }

    public void UpdateCurrentItem(Item item)
    {
        currentItem = item;
        _workbenchUIPrototype.UpdateDragItem(item);
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
        currentItem.sprRndr.sprite = tempCookedIngSprite;
        if (currentItem.GetComponent<IngredientProperties>() != null)
        {
            currentItem.GetComponent<IngredientProperties>().AddProperty(IngredientProperties.IngredientGroup.Chopped);
        }
    }


}
