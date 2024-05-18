using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    public GameObject _playerInventoryPanel;

    public GridLayoutGroup _gridLayoutGroup;

    public List<InventorySlot> _inventorySlotList = new List<InventorySlot>();

    // Start is called before the first frame update
    void Start()
    {
        _playerInventoryPanel.SetActive(false);
        _gridLayoutGroup = _playerInventoryPanel.GetComponentInChildren<GridLayoutGroup>();

        _gridLayoutGroup.GetComponentsInChildren<InventorySlot>(true, _inventorySlotList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ToggleInventory()
    {
        Debug.Log("Toggle activate");

        if (_playerInventoryPanel.activeInHierarchy == false)
        {
            _playerInventoryPanel.SetActive(true);
        }
        else if(_playerInventoryPanel.activeInHierarchy == true)
        {
            _playerInventoryPanel.SetActive(false);
        }

        
    }
}
