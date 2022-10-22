using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICustomerCounter : MonoBehaviour
{

    CustomerManager _customerManager;

    public TextMeshProUGUI counterText;

    // Start is called before the first frame update
    void Start()
    {
        _customerManager = FindObjectOfType<CustomerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCounter(int count)
    {
        counterText.text = "SatisfiedCustomers " + count;
    }


}