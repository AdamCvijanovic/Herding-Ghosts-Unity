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

    public UIItemPortrait uiItemPortrait;

    // Start is called before the first frame update
    void Start()
    {
        uiItemPortrait = FindObjectOfType<UIItemPortrait>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void RemoveCustomer(Customer customer)
    {
        customers.Remove(customer);
    }

    public void UpdatePortraitUI()
    {
        uiItemPortrait.UpdateImage(GetCurrentCustomer().GetUIFoodItemImage()._foodItemImage);
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

}
