using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    public Player _player;

    public Transform _itemHolder;

    public bool _isHolding;

    public List<Item> _nearbyItems;

    public Item _currentItem;



    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTutorialText();
    }

    public void PickupDropAction(InputAction.CallbackContext context)
    {


        if (context.performed)
        {
            if (_isHolding)
            {
                Drop();
            }
            else
            {
                Pickup();
            }
        }
            
    }

    public void Pickup()
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
            }
        }
      

    }

    public void Drop()
    {
        //if (_isHolding)
        {
            Debug.Log("Drop");
            
            // checking for UsableItem tag
            if(_currentItem.tag == "UsableItem")
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
        if (collision.gameObject.GetComponent<Item>())
        {
            _nearbyItems.Add(collision.gameObject.GetComponent<Item>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Item>())
        {
            _nearbyItems.Remove(collision.gameObject.GetComponent<Item>());
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

    public void UpdateTutorialText()
    {
        if (!_isHolding && _nearbyItems.Count > 0)
        {
            Item nearest = GetNearestItem();


            _player.playerUI.UpdateTutorialTextPickup(nearest.name);
            
        }
        else
        {
            _player.playerUI.UpdateTutorialTextPickup(" ");
        }

        if (_isHolding)
        {
            _player.playerUI.UpdateTutorialTextUse(_currentItem.GetType().ToString());
        }
    }

    //Getters & Setters

    public Transform GetHolderTransform()
    {
        return _itemHolder;
    }

   public void ActivateItem(InputAction.CallbackContext context)
    {

        if (_currentItem != null && context.performed)
        {
            _currentItem.Activate();
        }
    }


}
