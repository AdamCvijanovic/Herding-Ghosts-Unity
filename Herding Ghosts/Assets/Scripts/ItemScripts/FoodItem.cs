using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Item
{
    public enum FoodType { ApplePie, BobaPotion, BobaPotionSpooky, Bread, CarrotCake, MushCake, Pancakes, PumpkinPie,SpookyBread,SpookyPancakes, StrawberryCake};
    [SerializeField]
    private FoodType foodType;

    public Sprite foodSprite;

    public RecipeObject recipeObj;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
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

        if (_parentInventory != null)
        {
            RemoveFromParentInventory(_parentInventory);
        }
    }
    public override void OnDrop()
    {
        //shoudl change this proximity check to somewhere else.

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



    //public void AddToParentInventory(WorkstationDestination workstation)
    //{
    //    if (parentObj.GetComponent<Pickup>().nearWorkstation.HasInventorySpace())
    //    {
    //        workstation.AddItemToList(this);
    //        _parentWorkstation = workstation;
    //        _inInventory = true;
    //    }
    //    
    //}

    //public void RemoveFromParentInventory(WorkstationDestination workstation)
    //{
    //    workstation.RemoveItemFromList(this);
    //    _parentWorkstation = null;
    //    _inInventory = false;
    //}

    public void RemoveFromParentInventory(Inventory inventory)
    {
        inventory.RemoveItemFromList(this);
        _inInventory = false;
    }




}
