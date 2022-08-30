using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public UnityEvent itemAdded;

    public int maxItems = 3;

    public List<FoodItem> _items = new List<FoodItem>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //we could do with an inventory script that handles available space and inventory slots seperately
    public bool HasInventorySpace()
    {

        Debug.Log("ITEM LIST SIZE == " + _items.Count);

        return _items.Count <= maxItems - 1;
    }

    public void AddItemToList(FoodItem item)
    {
        //if(item.GetFoodType() == FoodItem.FoodType.Carrot)
        _items.Add(item);


        itemAdded.Invoke();
    }

    public void RemoveItemFromList()
    {
        _items.Remove(_items[0]);
    }

    public void RemoveItemFromList(int i)
    {
        _items.Remove(_items[i]);
    }

    public void RemoveItemFromList(FoodItem item)
    {
        if (_items.Contains(item))
            _items.Remove(item);
    }

}
