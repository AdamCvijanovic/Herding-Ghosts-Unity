using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    CustomerManager _customerMngr;

    public FoodItem.FoodType _desiredFood;

    void Start()
    {
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
        UpdateUI();
    }

    public void UpdateUI()
    {
        _foodItemImage.SelectFoodImage(_desiredFood);
        _customerMngr.UpdatePortraitUI();
    }

    public AINavigation GetNavigator()
    {
        return _customerNavigation;
    }

    public Pickup GetPickup()
    {
        return _customerPickup;
    }

   

}
