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

    public SpriteRenderer sprRndr;

    public Material defaultMaterial;
    public Material highlightMaterial;

    public string pickupString = "Press E to pickup: ";
    public string useString = "Press E to Drop: ";

    // Start is called before the first frame update
    protected new void Start()
    {
        //helpText = GetComponentInChildren<TutorialText>();

        sprRndr = GetComponent<SpriteRenderer>();
        if(sprRndr == null)
            sprRndr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    protected new void Update()
    {
        
    }

    //need to make this an event
    public virtual void OnPickup(PlayerPickup target)
    {
        DisableCollider();
        if (_inInventory && _parentInventory!=null)
        {
            _parentInventory.RemoveItemFromList(this);
        }
        SetItemTransform(target);
        parentObj = target.gameObject;
        _isHeld = true;
    }

    public virtual void OnPickup(Pickup target)
    {
        DisableCollider();
        if (_inInventory)
        {
            _parentInventory.RemoveItemFromList(this);
        }
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

    public void ItemHighlight()
    {
        if (highlightMaterial!= null)
            sprRndr.material = highlightMaterial;
    }

    public void ItemUnHighlight()
    {
        if (defaultMaterial != null)
        {
                sprRndr.material = defaultMaterial;
        }
        //if item highlighted, unhiglight
        
    }

    //public void UpdateHelpTextPickup()
    //{
    //    if(helpText != null)
    //    helpText.UpdateTextPickup("Item");
    //}
    //
    //public void DisableHelpTextPickup()
    //{
    //    if (helpText != null)
    //        helpText.DisableText();
    //}
    //
    //public void UpdateHelpTextUse()
    //{
    //    if (helpText != null)
    //        helpText.UpdateTextUse("");
    //    FadeOutTextAfterTime();
    //}
    //
    //public void DisableHelpTextUse()
    //{
    //    if (helpText != null)
    //        helpText.DisableText();
    //}
    //
    //public void FadeOutTextAfterTime()
    //{
    //    if (helpText != null)
    //        Invoke("DisableHelpTextUse", 1.2f);
    //}

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

    public virtual IngredientItem.IngredientType GetIngredientType()
    {
        //IngredientItem.IngredientType ingredientType = IngredientItem.IngredientType.None;
        //
        //if (this is IngredientItem child)
        //{
        //    ingredientType = child.GetIngredientType();
        //    // Here is where I want to access the child class methods and variables    
        //}

        return IngredientItem.IngredientType.None;
    }

}
