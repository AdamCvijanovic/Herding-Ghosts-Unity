using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurgeLever : MonoBehaviour
{

    public CauldronDestination _cauldron;
    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _cauldron = FindObjectOfType<CauldronDestination>();
        _animaator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullLever()
    {
        //_animator.Play
    }

    public void PurgeCauldron()
    {
        Inventory inventory = _cauldron._inventory;
        inventory.RemoveAllItems();
        Debug.Log("RemoveAll");
    }

}
