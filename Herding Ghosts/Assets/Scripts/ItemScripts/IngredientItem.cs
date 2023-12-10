using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientItem : Item
{
    public enum IngredientType {None, CupCake, Carrot, Wheat, Sugar, Apple, Milk, Pumpkin, Mushroom, TeaLeaves, Strawberry, Honey, Ectoplasm, Boba, CarrotSeed,};
    [SerializeField]
    private IngredientType foodType;

    public List<IngredientProperties> myIngrdntProperties = new List<IngredientProperties>();
    public IngredientProperties IngrdntProperties = new IngredientProperties();

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IngredientType GetIngredientType()
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
            RemoveFromParentInventory();
        }
    }
    public override void OnDrop()
    {
        //shoudl change this proximity check to somewhere else.
       if (parentObj.GetComponent<Pickup>().nearInventory != null)
       {
            AddToParentInventory(parentObj.GetComponent<Pickup>().nearInventory);

            //if(parentObj.GetComponent<Pickup>().nearWorkstation != null)
                //parentObj.GetComponent<Pickup>().nearWorkstation.AddItemToList(this);
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
    //        _parentInventory = inve
    //        _inInventory = true;
    //    }
    //    
    //}
    //
    //
    //public void RemoveFromParentInventory(WorkstationDestination workstation)
    //{
    //    workstation.RemoveItemFromList(this);
    //    _inInventory = false;
    //}
    //
    //public void RemoveFromParentInventory(Inventory inventory)
    //{
    //    inventory.RemoveItemFromList(this);
    //    _inInventory = false;
    //}



}
