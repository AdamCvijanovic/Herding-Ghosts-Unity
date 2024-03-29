using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    public GameObject _playerInventoryPanel;

    public GridLayoutGroup _gridLayoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        _playerInventoryPanel.SetActive(false);
        _gridLayoutGroup = _playerInventoryPanel.GetComponentInChildren<GridLayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
