using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInventory : MonoBehaviour
{
    public Inventory inventory;

    public List<Transform> transforms = new List<Transform>();



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
        for (int i = 0; i < inventory._items.Count; i++)
        {
            inventory._items[i].transform.position = transforms[i].position;
        }
    }



}
