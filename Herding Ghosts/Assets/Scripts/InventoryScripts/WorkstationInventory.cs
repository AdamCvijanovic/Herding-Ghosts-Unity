using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class WorkstationInventory : Inventory
{
    //public Inventory inventory;

    public List<Transform> transforms = new List<Transform>();

    public UnityEvent itemAdded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveItemsToPostion()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].transform.position = transforms[i].position;
        }
    }

    public override void AddItemToList(Item item)
    {
        //if(item.GetFoodType() == FoodItem.FoodType.Carrot)

        if (item.GetComponent<IngredientItem>())
        {
            _items.Add(item);
            MoveItemsToPostion();

            GetComponent<WorkstationDestination>().InventoryCheck();

            itemAdded.Invoke();
        }
    }



}
