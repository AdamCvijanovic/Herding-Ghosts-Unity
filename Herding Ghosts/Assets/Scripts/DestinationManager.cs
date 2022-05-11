using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    //Singleton
    //public static DestinationManager DestinationManagerSGLTN { get; private set; }

    public List<Destination> destinations = new List<Destination>();

    private void Awake()
    {
        //Singleton Constructor (unnecesary, we can just use global search on Awak and store ref in a local var)
        //if (DestinationManagerSGLTN != null && DestinationManagerSGLTN != this)
        //{
        //    Destroy(this);
        //    return;
        //}
        //DestinationManagerSGLTN = this;

        PopulateExistingDestinations();

    }

    // Start is called before the first frame update
    void Start()
    {
        PopulateExistingDestinations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PopulateExistingDestinations()
    {
        foreach (Destination e in FindObjectsOfType<Destination>())
        {
            destinations.Add(e);
        }
    }

    public void AddDestination(Destination destination)
    {
        destinations.Add(destination);
    }

    public void RemoveDestination(Destination destination)
    {
        destinations.Remove(destination);
    }

    public List<Destination> GetDestinations()
    {
        return destinations;
    }

    public Destination GetDestinationOfType(Destination.DestinationType type)
    {
        Destination returnDest = null;

        foreach (Destination d in destinations)
        {
            if (d.GetDestinationType() == type)
            {
                returnDest = d;
            }
        }

        return returnDest;
    }
}
