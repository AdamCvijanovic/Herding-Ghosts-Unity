using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField]
    private List<Customer> customers = new List<Customer>();

    [SerializeField]
    private int MaxCustomers;

    [SerializeField]
    public List<GameObject> _foodPrefabs = new List<GameObject>();

    //Store Open Bool
    public bool storeOpen;

    //UI ELEMENTS
    public CanvasManager _canvasManager;

    public UIItemPortrait uiItemPortrait;

    public UICustomerCounter uiCustomerCounter;
    
    //Level Stats
    public int satisfiedCustomerCounter = 0;
    public int maxSatisfiedCustomers = 3;


    //CurrentCustomerStats
    public FoodItem _desiredFoodItem;


    public Door_Anim_Script _doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _canvasManager = FindObjectOfType<CanvasManager>();
        uiItemPortrait = FindObjectOfType<UIItemPortrait>();
        uiCustomerCounter = FindObjectOfType<UICustomerCounter>();
        _doorAnimator = FindObjectOfType<Door_Anim_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenStore()
    {
        uiCustomerCounter.UpdateCounter(satisfiedCustomerCounter);
        FindObjectOfType<LevelManager>().OpenStore();
    }

    public Customer GetCurrentCustomer()
    {
        if (customers.Count >= 1)
        {
            return customers[0];
        }
        else
        {
            return null;
        }
    }

    private void FetchExistingCustomers()
    {
        foreach (Customer e in FindObjectsOfType<Customer>())
        {
            customers.Add(e);
        }
    }

    public void AddCustomer(Customer customer)
    {
        customer.enabled = true;
        customers.Add(customer);
        customer.SetCustomerManager(this);
        customer.transform.parent = this.transform;

        //updateUI
        //ActivateTimerUI();

        //worldAnimations
        _doorAnimator.OpenDoor();
    }

    public void RemoveCustomer(Customer customer)
    {
        _doorAnimator.OpenDoor();
        customers.Remove(customer);
    }

    public void UpdatePortraitUI(UIFoodItemImage foodItemImage)
    {
        uiItemPortrait.UpdateImage(foodItemImage._foodItemImage);
    }

    public void ResetPortraitUI()
    {
        uiItemPortrait.ResetImage();
    }

    public bool CheckMax()
    {
        return customers.Count < MaxCustomers;
    }

    public GameObject FindFoodFromEnum(FoodItem.FoodType foodType)
    {

        GameObject foodObj = _foodPrefabs[0];

        foreach (GameObject i in _foodPrefabs)
        {
            if (i.GetComponent<FoodItem>().GetFoodType() == foodType)
                foodObj = i;
        }

        return foodObj;
    }

    public void AssignFoodItemFromEnum(FoodItem.FoodType foodType)
    {
        _desiredFoodItem = FindFoodFromEnum(foodType).GetComponent<FoodItem>();
    }

    public FoodItem GetDesiredFoodItem()
    {
        if(_desiredFoodItem != null)
        {
            return _desiredFoodItem;
        }
        else
        {
            return null;
        }
    }

    public void IncrementCounter()
    {
        //Reset Timer
        FindObjectOfType<CanvasManager>().RestartTimer();

        satisfiedCustomerCounter++;

        GameManager.instance.UpdateCustomerCounter(satisfiedCustomerCounter);
        uiCustomerCounter.UpdateCounter(satisfiedCustomerCounter);
    }

    public void IncrementDisatisfiedCustomerCounter()
    {

    }

    public void ActivateTimerUI()
    {
        _canvasManager.ActivateTimer();
    }
}
