using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    CustomerLogic _customerLogic;

    [SerializeField]
    Pickup _customerPickup;

    [SerializeField]
    AINavigation _customerNavigation;

    [SerializeField]
    UIFoodItemImage _foodItemImage;

    [SerializeField]
    ConversationTrigger _conversationTrigger;

    [SerializeField]
    ConversationManager _conversationManager;


    public Sprite _customerAppearance;
    public Sprite _customerRasterImg;

    [SerializeField]
    CustomerManager _customerMngr;

    public FoodItem.FoodType _desiredFood;

    public bool isSatisfied;

    public bool isSpokenTo;

    void Start()
    {
        isSpokenTo = false;

        enabled = true;

        if (_customerMngr == null)
        {
            _customerMngr = FindObjectOfType<CustomerManager>();
        }

        _customerNavigation = GetComponent<AINavigation>();
        _customerLogic = GetComponent<CustomerLogic>();
        _customerLogic.SetCustomer(this);
        _customerPickup = GetComponent<Pickup>();
        _foodItemImage = GetComponentInChildren<UIFoodItemImage>();
        _foodItemImage.SetCustomer(this);
        _conversationManager = FindObjectOfType<ConversationManager>();
        _conversationManager.SetCustomer(this);
        _conversationTrigger = GetComponentInChildren<ConversationTrigger>();


        SetDesiredFood();
    }

    // Update is called once per frame
    void Update()
    {
        DynamicLayering();
    }
    public CustomerManager GetCustomerManager()
    {
        if (_customerMngr == null)
        {
            _customerMngr = FindObjectOfType<CustomerManager>();
        }
        return _customerMngr;
    }

    public CustomerLogic GetCustomerLogic()
    {
        return _customerLogic;
    }

    public UIFoodItemImage GetUIFoodItemImage()
    {
        return _foodItemImage;
    }

    public ConversationTrigger GetConversationTrigger()
    {
        return _conversationTrigger;
    }

    public void SetCustomerManager(CustomerManager customerManager)
    {
        _customerMngr = customerManager;
    }

    public void SetDesiredFood()
    {
        _desiredFood = (FoodItem.FoodType)Random.Range(0, System.Enum.GetValues(typeof(FoodItem.FoodType)).Length);
        //UpdateUI();
        _customerMngr.AssignFoodItemFromEnum(_desiredFood);
        UpdateConverMngr();
    }

    public void AmSpokenTo()
    {

        UpdateUI();
        isSpokenTo = true;
    }

    public void UpdateUI()
    {
        _foodItemImage.SelectFoodImage(_desiredFood);
        _customerMngr.UpdatePortraitUI(_foodItemImage);
    }

    public void UpdateConverMngr()
    {
        _conversationManager.WhatFoodIsIt(_desiredFood);
        _conversationManager.SetCustomerSprite(_customerRasterImg);
    }

    public AINavigation GetNavigator()
    {
        return _customerNavigation;
    }

    public Pickup GetPickup()
    {
        return _customerPickup;
    }

    //I'm sure there's a better way to do this
    public bool IsPlayerHoldingItem()
    {

        return FindObjectOfType<Player>().playerPickup._isHolding;
    }

   public bool IsPlayerHoldingDesiredItem()
   {
        bool isHolding = false;

        if (FindObjectOfType<PlayerPickup>()._currentItem.GetType() == typeof(FoodItem))
        {
            FoodItem _playerItem = (FoodItem)FindObjectOfType<PlayerPickup>()._currentItem;
            if (_playerItem.GetFoodType() == _desiredFood ) 

            isHolding = true;
        }

        return isHolding;
   }

    public void PickupDesiredItem()
    {
        Item item = FindObjectOfType<PlayerPickup>()._currentItem;
        FindObjectOfType<PlayerPickup>().Drop();
        _customerPickup.PickupItem(item);
        AmSatisfied();
    }

    public void AmSatisfied()
    {
        _customerLogic.CustomerSatisfied();
    }

    public void DynamicLayering()
    {
        if(transform.position.y < 6)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
    }

}
