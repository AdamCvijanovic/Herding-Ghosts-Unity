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

    CustomerManager _customerMngr;



    void Start()
    {
        _customerLogic = GetComponent<CustomerLogic>();
        _customerPickup = GetComponent<Pickup>();
        _customerNavigation = GetComponent<AINavigation>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
