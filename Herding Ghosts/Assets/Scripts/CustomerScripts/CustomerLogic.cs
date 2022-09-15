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
    public float dst;
    public float despawnTime;


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
        dst = Vector3.Distance(_customer.GetNavigator().GetDestination(), transform.position);

        CheckState();
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

    public void CheckState()
    {


        if (currentState == CustomerState.Shopping)
        {
            if (dst < minDst)
            {
                //_customer.UpdateUI();

                if (counter.GetCounterInventory()._items.Count > 0)
                {
                    if (DesireditemFound())
                    {
                        GrabItem();
                        _customer.GetNavigator().SetDestination(customerSpawner.transform);
                        dst = Vector3.Distance(_customer.GetNavigator().GetDestination(), transform.position);
                        currentState = CustomerState.Leaving;
                    }
                    else
                    {
                        //Debug.Log("No item found");
                    }
                }
            }
        }

        if (currentState == CustomerState.Leaving)
        {
            if (dst < minDst)
            {
                Debug.Log("Remove customer");
                _customer.GetCustomerManager().RemoveCustomer(this.GetComponent<Customer>());
                Destroy(this.gameObject, despawnTime);
            }
        }       
    }

    public void RunShopping()
    {

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
