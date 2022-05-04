using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    public List<Destination> destinations = new List<Destination>();

    // Start is called before the first frame update
    void Start()
    {
        FetchExistingDestinations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FetchExistingDestinations()
    {
        foreach (Destination e in FindObjectsOfType<Destination>())
        {
            destinations.Add(e);
        }
    }

    public void AddDestination()
    {

    }
}
