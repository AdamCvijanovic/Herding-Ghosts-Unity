using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnerDestination : Destination
{
    public List<GameObject> customerPrefabs;

    public CustomerManager _customerMngr;

    public Transform _spawnPosition;
    public float _spawnTime;
    public float countdown;

    // Start is called before the first frame update
    void Start()
    {
        _customerMngr = FindObjectOfType<CustomerManager>();
        countdown = _spawnTime;

    }

    // Update is called once per frame
    void Update()
    {
        if(_customerMngr.storeOpen)
            SpawnCountDown(_spawnTime);
    }

    private void SpawnCountDown(float time)
    {


        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = time;
            if (_customerMngr.CheckMax())
            {
                SpawnRandomCustomer();
            }
            else
            {
                //Debug.Log("Exceeds Max Count");
            }
        }



    }

    public void SpawnRandomCustomer()
    {


        int i = Random.Range(0, customerPrefabs.Count);

        SpawnCustomer(customerPrefabs[i]);



    }

    public void SpawnCustomer(GameObject customerPrefab)
    {
        if (_spawnPosition != null)
        {
            GameObject newCustomer = Instantiate(customerPrefab, _spawnPosition.position, Quaternion.identity, _customerMngr.transform);
            _customerMngr.AddCustomer(newCustomer.GetComponent<Customer>());
            newCustomer.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            GameObject newCustomer = Instantiate(customerPrefab, this.transform.position, Quaternion.identity, _customerMngr.transform);
            _customerMngr.AddCustomer(newCustomer.GetComponent<Customer>());
            newCustomer.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }
}
