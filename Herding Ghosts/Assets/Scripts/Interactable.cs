using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{


    //Interaction system
    public SpriteRenderer sprRndr;

    public Material defaultMaterial;
    public Material highlightMaterial;

    public UnityEvent _ActivateEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        //_ActivateEvent.AddListener(Activate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Interaction Systems
    public void Highlight()
    {
        if (highlightMaterial != null)
            sprRndr.material = highlightMaterial;
    }

    public void UnHighlight()
    {
        if (defaultMaterial != null)
        {
            sprRndr.material = defaultMaterial;
        }
        //if item highlighted, unhiglight

    }

    public void Activate()
    {
        Debug.Log("ACTIVATE");
        _ActivateEvent.Invoke();
    }

}
