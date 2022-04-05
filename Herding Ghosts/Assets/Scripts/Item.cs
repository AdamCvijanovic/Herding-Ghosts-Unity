using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //need to make this an event
    public void OnPickup(PlayerPickup target)
    {
        DisableCollider();
        SetItemTransform(target);
    }

    //This also needs to be an event
    public void OnDrop()
    {
        EnableCollider();
        UnsetItemTransform();
    }

    public void EnableCollider()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DisableCollider()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void SetItemTransform(PlayerPickup target)
    {
        transform.parent = target.GetHolderTransform();
        transform.position = target.GetHolderTransform().position;
    }

    private void UnsetItemTransform()
    {
        transform.parent = null;

    }


}
