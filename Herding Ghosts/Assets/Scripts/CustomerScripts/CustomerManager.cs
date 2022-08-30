using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField]
    private List<Customer> customers = new List<Customer>();

    [SerializeField]
    private int MaxCustomers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        customers.Add(customer);

    }

    public void RemoveCustomer(Customer customer)
    {
        customers.Remove(customer);
    }

    public bool CheckMax()
    {
        return customers.Count < MaxCustomers;
    }

}
