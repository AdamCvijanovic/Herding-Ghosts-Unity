using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeItem : ItemBehaviour
{
    public override void PickupBehaviour()
    {
        Debug.Log("large Item Pickup");
    }
}
