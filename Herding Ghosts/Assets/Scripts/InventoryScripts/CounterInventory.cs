using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CounterInventory : Inventory
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
        if (item.GetComponent<FoodItem>())
        {
            _items.Add(item);
            MoveItemsToPostion();

            itemAdded.Invoke();
        }
        
    }

    public bool SearchForFoodType(FoodItem.FoodType foodType)
    {
        bool returnObject = false;

        foreach (FoodItem item in _items)
        { 
            if (item.GetFoodType() == foodType)
                returnObject = item.gameObject;
        }

        return returnObject;
    }

    public GameObject GrabFoodOfType(FoodItem.FoodType foodType)
    {
        GameObject returnObject = null;

        foreach (FoodItem item in _items)
        {
            if (item.GetFoodType() == foodType)
                returnObject = item.gameObject;
        }

        return returnObject;
    }

}
