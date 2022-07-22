using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronDestination : Destination
{

    public List<Item> items = new List<Item>();

    //Accepted Items

    //Recipe Outputs

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToList(FoodItem item)
    {
        if(item.GetFoodType() == FoodItem.FoodType.Carrot)
        items.Add(item);
    }

    //Scan through existing recipes
    //See if items at index's 0-2 match
    //consume items
    //output prefab


    public void RemoveItemFromList()
    {
        items.Remove(items[0]);
    }

    public void RemoveItemFromList(Item item)
    {
        if (items.Contains(item))
            items.Remove(item);
    }
}
