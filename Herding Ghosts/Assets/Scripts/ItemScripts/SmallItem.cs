using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallItem : ItemBehaviour
{

    public override void PickupBehaviour()
    {
        Debug.Log("Small Item Pickup");
    }

}
