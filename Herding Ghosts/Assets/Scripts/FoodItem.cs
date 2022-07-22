using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Item
{
    public enum FoodType { CupCake, Carrot};
    [SerializeField]
    private FoodType foodType;

    public bool _inCauldron;
    public CauldronDestination parentCauldron;

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
        if (parentCauldron != null)
        {
            RemoveFromCauldronInventory(parentCauldron);
        }
    }
    public override void OnDrop()
    {
        //shoudl change this proximity check to somewhere else.
        if(parentObj.GetComponent<Pickup>().nearCauldron != null)
        {
            AddToCauldronInventory(parentObj.GetComponent<Pickup>().nearCauldron);
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        EnableCollider();
        UnsetItemTransform();
        parentObj = null;
        _isHeld = false;
    }

    private void AddToCauldronInventory(CauldronDestination cauldron)
    {
        cauldron.AddItemToList(this);
        parentCauldron = cauldron;
        _inCauldron = true;
    }

    private void RemoveFromCauldronInventory(CauldronDestination cauldron)
    {
        cauldron.RemoveItemFromList(this);
        parentCauldron = null;
        _inCauldron = false;
    }



}
