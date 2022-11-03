using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurgeLever : MonoBehaviour
{

    public CauldronDestination _cauldron;
    public Animator _animator;
    public int layer;

    // Start is called before the first frame update
    void Start()
    {
        _cauldron = FindObjectOfType<CauldronDestination>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullLever()
    {
        _animator.Play("Base Layer.Purge", layer, 1f);
        PurgeCauldron();
    }

    public void PurgeCauldron()
    {
        Inventory inventory = _cauldron._inventory;
        inventory.RemoveAllItems();
        Debug.Log("RemoveAll");
    }

    public void ResetCauldron()
    {

    }

}
