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
    ConversationManager _foodItemName;


    public Sprite _customerAppearance;

    [SerializeField]
    CustomerManager _customerMngr;

    public FoodItem.FoodType _desiredFood;

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
        _foodItemName = FindObjectOfType<ConversationManager>();
        _foodItemName.SetCustomer(this);


        SetDesiredFood();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void SetCustomerManager(CustomerManager customerManager)
    {
        _customerMngr = customerManager;
    }

    public void SetDesiredFood()
    {
        _desiredFood = (FoodItem.FoodType)Random.Range(0, System.Enum.GetValues(typeof(FoodItem.FoodType)).Length);
        //UpdateUI();
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
        _customerMngr.UpdatePortraitUI();
    }

    public void UpdateConverMngr()
    {
        _foodItemName.WhatFoodIsIt(_desiredFood);
        _foodItemName.SetCustomerSprite(_customerAppearance);
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
    }



}
