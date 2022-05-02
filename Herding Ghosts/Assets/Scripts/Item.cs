using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject parentObj;
    public Item subclass;


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
        parentObj = target.gameObject;
    }

    //This also needs to be an event
    public void OnDrop()
    {
        EnableCollider();
        UnsetItemTransform();
        parentObj = null;
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

    public virtual void Activate()
    {
        if(subclass != null)
        {
            subclass.Activate();
        }
    }

  




}
