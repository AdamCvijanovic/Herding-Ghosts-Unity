using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Item
{
    public enum FoodType { CupCake, Carrot};
    [SerializeField]
    private FoodType foodType;

    public bool _inCauldron;
    public WorkstationDestination _parentWorkstation;
    public Inventory _parentInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public FoodType GetFoodType()
    {
        return foodType;
    }

    public override void Activate()
    {

        Debug.Log(foodType.ToString() + " IS THE FOOD TYPE");
    }


    public override void OnPickup(PlayerPickup target)
    {
        base.OnPickup(target);
        if (_parentWorkstation != null)
        {
            RemoveFromParentInventory(_parentWorkstation);
        }

        if (_parentInventory != null)
        {
            RemoveFromParentInventory(_parentInventory);
        }
    }
    public override void OnDrop()
    {
        //shoudl change this proximity check to somewhere else.
        if(parentObj.GetComponent<Pickup>().nearWorkstation != null)
        {
            AddToParentInventory(parentObj.GetComponent<Pickup>().nearWorkstation);
        }

        if (parentObj.GetComponent<Pickup>().nearInventory != null)
        {
            AddToParentInventory(parentObj.GetComponent<Pickup>().nearInventory);
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        EnableCollider();
        UnsetItemTransform();
        parentObj = null;
        _isHeld = false;
    }



    private void AddToParentInventory(WorkstationDestination workstation)
    {
        if (parentObj.GetComponent<Pickup>().nearWorkstation.HasInventorySpace())
        {
            workstation.AddItemToList(this);
            _parentWorkstation = workstation;
            _inCauldron = true;
        }
        
    }

    private void AddToParentInventory(Inventory inventory)
    {
        if (parentObj.GetComponent<Pickup>().nearInventory.HasInventorySpace())
        {
            inventory.AddItemToList(this);
            _parentInventory = inventory;
            _inCauldron = true;
        }

    }

    private void RemoveFromParentInventory(WorkstationDestination workstation)
    {
        workstation.RemoveItemFromList(this);
        _parentWorkstation = null;
        _inCauldron = false;
    }

    private void RemoveFromParentInventory(Inventory inventory)
    {
        inventory.RemoveItemFromList(this);
        _parentWorkstation = null;
        _inCauldron = false;
    }



}
