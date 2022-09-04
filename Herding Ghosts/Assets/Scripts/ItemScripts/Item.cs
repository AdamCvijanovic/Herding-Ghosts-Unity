using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject parentObj;
    public Item subclass;

    public bool _isHeld;

    public TutorialText helpText;

    public bool _inInventory;
    public Inventory _parentInventory;

    // Start is called before the first frame update
    void Start()
    {
        helpText = GetComponentInChildren<TutorialText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //need to make this an event
    public virtual void OnPickup(PlayerPickup target)
    {
        DisableCollider();
        SetItemTransform(target);
        parentObj = target.gameObject;
        _isHeld = true;
    }

    public virtual void OnPickup(Pickup target)
    {
        DisableCollider();
        SetItemTransform(target);
        parentObj = target.gameObject;
        _isHeld = true;
    }


    //This also needs to be an event
    public virtual void OnDrop()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        EnableCollider();
        UnsetItemTransform();
        parentObj = null;
        _isHeld = false;
    }

    public void EnableCollider()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DisableCollider()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void SetItemTransform(PlayerPickup target)
    {
        transform.parent = target.GetHolderTransform();
        transform.position = target.GetHolderTransform().position;
    }
    private void SetItemTransform(Pickup target)
    {
        transform.parent = target.GetHolderTransform();
        transform.position = target.GetHolderTransform().position;
    }


    protected void UnsetItemTransform()
    {
        transform.parent = null;

    }

    public virtual void Activate()
    {
        if(subclass != null)
        {
            subclass.Activate();
        }
    }


    public void UpdateHelpTextPickup()
    {
        if(helpText != null)
        helpText.UpdateTextPickup("Item");
    }

    public void DisableHelpTextPickup()
    {
        if (helpText != null)
            helpText.DisableText();
    }

    public void UpdateHelpTextUse()
    {
        if (helpText != null)
            helpText.UpdateTextUse("");
        FadeOutTextAfterTime();
    }

    public void DisableHelpTextUse()
    {
        if (helpText != null)
            helpText.DisableText();
    }

    public void FadeOutTextAfterTime()
    {
        if (helpText != null)
            Invoke("DisableHelpTextUse", 1.2f);
    }

    public void AddToParentInventory(Inventory inventory)
    {
        if (parentObj.GetComponent<Pickup>().nearInventory.HasInventorySpace())
        {
            inventory.AddItemToList(this);
            _parentInventory = inventory;
            _inInventory = true;
        }

    }

    public void RemoveFromParentInventory()
    {
        _parentInventory.RemoveItemFromList(this);
        _inInventory = false;
    }



}
