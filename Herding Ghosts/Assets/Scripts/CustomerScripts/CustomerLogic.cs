using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    public Customer _customer;

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
            if(counter.GetCounterInventory()._items.Count > 0)
            {
                GrabItem();
                _customer.GetNavigator().SetDestination(customerSpawner.transform);
                currentState = CustomerState.Leaving;
            }
        }
    }

    public void GrabItem()
    {
        _customer.GetPickup().PickupItem(counter.GetCounterInventory()._items[0]);
    }



}
