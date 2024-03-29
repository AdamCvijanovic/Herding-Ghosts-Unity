using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public Transform _itemHolder;

    public bool _isHolding;

    public List<Item> _nearbyItems;

    public Item _currentItem;

    //Don't liek this have it be universal to inventories instead
    public WorkstationDestination nearWorkstation;
    public Inventory nearInventory;

    public Interactable nearInteractable;
    public List<Interactable> _nearbyinteractables;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //UpdateTutorialText();
    }

    public void PickupDropAction()
    {
        if (_isHolding)
        {
            Drop();
        }
        else
        {
            PickupItem();
        }
    }

    public void PickupItem()
    {

        //if (!_isHolding)
        {
            Debug.Log("Pickup");

            //get nearby objects
            //parent to transform
            if (_nearbyItems.Count > 0)
            {
                Item nearestItem = GetNearestItem();
                _currentItem = nearestItem;
                _nearbyItems.Remove(nearestItem);
                _isHolding = true;
                _currentItem.OnPickup(this);
                //nearestItem.UpdateHelpTextUse();
            }
        }


    }

    public void PickupItem(Item item)
    {

        //if (!_isHolding)
        {
            Debug.Log("Pickup");

            //get nearby objects
            //parent to transform
            _currentItem = item;
            _isHolding = true;
            _currentItem.OnPickup(this);
            //nearestItem.UpdateHelpTextUse();

            if (item.GetComponent<Item>()._inInventory)
            {
                item.GetComponent<Item>().RemoveFromParentInventory();
            }
        }
    }

    public void Drop()
    {
        //if (_isHolding)
        {
            Debug.Log("Drop");

            // checking for UsableItem tag
            if (_currentItem.tag == "UsableItem")
            {
                // Name of item
                Debug.Log(_currentItem);

                //_currentItem.GetComponent<SaltItem>().Activate();
            }

            _currentItem.OnDrop();
            _isHolding = false;
            _currentItem = null;
        }

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.GetComponent<Item>())
        //{
        //    _nearbyItems.Add(collision.gameObject.GetComponent<Item>());
        //    collision.gameObject.GetComponent<Item>().UpdateHelpTextPickup();
        //}

        if (collision.gameObject.GetComponent<CauldronDestination>())
        {
            nearWorkstation = collision.gameObject.GetComponent<WorkstationDestination>();
        }

        if (collision.gameObject.GetComponent<Inventory>())
        {
            nearInventory = collision.gameObject.GetComponent<Inventory>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Item>())
        {
            _nearbyItems.Remove(collision.gameObject.GetComponent<Item>());
            //collision.gameObject.GetComponent<Item>().DisableHelpTextPickup();

        }

        if (collision.gameObject.GetComponent<CauldronDestination>())
        {
            if (nearWorkstation != null)
            {
                nearWorkstation = null;
            }
        }
    }

    private Item GetNearestItem()
    {
        //I do this here because this method should never be called if there are no items nearby
        Item nearestItem = null;
        if (_nearbyItems.Count > 0)
        {
            nearestItem = _nearbyItems[0];
            float smallestDist = Vector2.Distance(transform.position, _nearbyItems[0].gameObject.transform.position);


            //we only really need to do this if there is more than one item
            foreach (Item i in _nearbyItems)
            {
                float currentDist = Vector2.Distance(transform.position, i.gameObject.transform.position);
                if (currentDist < smallestDist)
                {
                    smallestDist = currentDist;
                    nearestItem = i;
                }
            }
        }

        return nearestItem;
    }

    public Interactable GetNearestInteractable()
    {
        //I do this here because this method should never be called if there are no items nearby
        Interactable nearestInteractable = null;
        if (_nearbyinteractables.Count > 0)
        {
            nearestInteractable = _nearbyinteractables[0];
            float smallestDist = Vector2.Distance(transform.position, _nearbyinteractables[0].gameObject.transform.position);


            //we only really need to do this if there is more than one item
            foreach (Interactable i in _nearbyinteractables)
            {
                float currentDist = Vector2.Distance(transform.position, i.gameObject.transform.position);
                if (currentDist < smallestDist)
                {
                    smallestDist = currentDist;
                    nearestInteractable = i;
                }
            }
        }

        return nearestInteractable;
    }

    public bool ExistsInInteractable(Interactable interactable)
    {
        if(_nearbyinteractables.Contains(interactable))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Transform GetHolderTransform()
    {
        return _itemHolder;
    }

    public void ActivateItem()
    {

        if (_currentItem != null)
        {
            _currentItem.Activate();
        }
    }


}
