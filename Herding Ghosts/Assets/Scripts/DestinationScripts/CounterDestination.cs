using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterDestination : Destination
{
    public CounterInventory counterInventory;


    //Accepted Items

    //Recipe Outputs

    public Queue<Customer> customerQueue;

    public List<CounterQueuePosition> queuePositions = new List<CounterQueuePosition>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public CounterInventory GetCounterInventory()
    {
        return counterInventory;
    }

    
}
