using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    [SerializeField]
    private Customer _customer;

    public enum CustomerState {Shopping,Leaving};
    public CustomerState currentState;

    DestinationManager _destMngr;
    public CounterDestination counter;
    public Destination customerSpawner;


    public float minDst;


    // Start is called before the first frame update
    void Start()
    {
        _customer = GetComponent<Customer>();
        _destMngr = FindObjectOfType<DestinationManager>();
        FetchDestination();
        currentState = CustomerState.Shopping;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public void FetchDestination()
    {
        counter = _destMngr.GetDestinationOfType(Destination.DestinationType.Counter).GetComponent<CounterDestination>();
        customerSpawner = _destMngr.GetDestinationOfType(Destination.DestinationType.CustomerSpawner);
        _customer.GetNavigator().SetDestination(counter.transform);
    }

    public void CheckDistance()
    {
        float dst = Vector3.Distance(counter.transform.position, transform.position);

        if(dst < minDst)
        {
            //_customer.UpdateUI();

            if (currentState == CustomerState.Shopping)
            {
                if (counter.GetCounterInventory()._items.Count > 0)
                {
                    if (DesireditemFound())
                    {
                        GrabItem();
                        _customer.GetNavigator().SetDestination(customerSpawner.transform);
                        currentState = CustomerState.Leaving;
                    }
                }
            }

            if(currentState == CustomerState.Leaving)
            {
                _customer.GetCustomerManager().RemoveCustomer(this.GetComponent<Customer>());
                Destroy(this.gameObject, .2f);
            }

            
            
        }
    }


    public bool DesireditemFound()
    { 
        return counter.GetCounterInventory().SearchForFoodType(_customer._desiredFood);
    }

    public void GrabItem()
    {
        Item desiredFoodItem = counter.GetCounterInventory().GrabFoodOfType(_customer._desiredFood).GetComponent<Item>();
        _customer.GetPickup().PickupItem(desiredFoodItem);
    }



}
