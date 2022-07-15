using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Item
{
    public enum FoodType { Onion, Carrot};
    [SerializeField]
    private FoodType foodType;

    public bool InCauldron;
    public CauldronDestination parentCauldron;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

        if(parentObj.GetComponent<Player>().nearCauldron != null)
        {
            AddToCauldronInventory(parentObj.GetComponent<Player>().nearCauldron);
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        EnableCollider();
        UnsetItemTransform();
        parentObj = null;
    }

    private void AddToCauldronInventory(CauldronDestination cauldron)
    {
        cauldron.AddItemToList(this);
        parentCauldron = cauldron;
    }

    private void RemoveFromCauldronInventory(CauldronDestination cauldron)
    {
        cauldron.RemoveItemFromList(this);
        parentCauldron = null;
    }



}
