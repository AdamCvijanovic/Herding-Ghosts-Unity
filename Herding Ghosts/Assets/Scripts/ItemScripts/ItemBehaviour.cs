using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void PickupBehaviour()
    {

    }

    public virtual string DebugString()
    {
        return "Default Item Behaviour";
    }
}