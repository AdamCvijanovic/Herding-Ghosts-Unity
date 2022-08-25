using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{

    public enum DestinationType { Cauldron, Basement, Barrel, Oven, Fridge, PointOfSale};
    [SerializeField]
    private DestinationType destinationType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DestinationType GetDestinationType()
    {
        DestinationType typeCopy = destinationType;
        return typeCopy;
    }

    public void SetDestinationType()
    {

    }

}
