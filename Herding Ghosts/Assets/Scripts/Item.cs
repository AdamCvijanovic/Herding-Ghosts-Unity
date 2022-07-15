using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject parentObj;
    public Item subclass;

    public TutorialText helpText;

    // Start is called before the first frame update
    void Start()
    {
        helpText = GetComponentInChildren<TutorialText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //need to make this an event
    public virtual void OnPickup(PlayerPickup target)
    {
        DisableCollider();
        SetItemTransform(target);
        parentObj = target.gameObject;
    }

    //This also needs to be an event
    public virtual void OnDrop()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
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

    protected void UnsetItemTransform()
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


    public void UpdateHelpTextPickup()
    {
        if(helpText != null)
        helpText.UpdateTextPickup("Item");
    }

    public void DisableHelpTextPickup()
    {
        if (helpText != null)
            helpText.DisableText();
    }

    public void UpdateHelpTextUse()
    {
        if (helpText != null)
            helpText.UpdateTextUse("");
        FadeOutTextAfterTime();
    }

    public void DisableHelpTextUse()
    {
        if (helpText != null)
            helpText.DisableText();
    }

    public void FadeOutTextAfterTime()
    {
        if (helpText != null)
            Invoke("DisableHelpTextUse", 1.2f);
    }




}
