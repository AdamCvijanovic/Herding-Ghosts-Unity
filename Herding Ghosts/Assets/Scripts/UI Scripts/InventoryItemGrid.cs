using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryItemGrid : MonoBehaviour
{

    public GridLayoutGroup itemGrid;

    public List<InventorySlot> inventorySlotList = new List<InventorySlot>();

    // Start is called before the first frame update
    void Start()
    {
        itemGrid = GetComponent<GridLayoutGroup>();

        inventorySlotList = GetComponentsInChildren<InventorySlot>().ToList();




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateItemSlot()
    {
        // Fisrt Find empty
        // Add item to empty
    }

}
