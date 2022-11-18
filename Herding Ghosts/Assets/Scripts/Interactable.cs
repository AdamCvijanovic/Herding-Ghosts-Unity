using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{


    //Interaction system
    public SpriteRenderer sprRndr;

    public Material defaultMaterial;
    public Material highlightMaterial;

    public UnityEvent _ActivateEvent = new UnityEvent();

    public string pickupString = "Press E to Interact";
    public string useString = "";

    // Start is called before the first frame update
    void Start()
    {
        //_ActivateEvent.AddListener(Activate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        //Do we have an interactable
        if (GetComponent<Interactable>())
        {
            //Is Interactable in PlayerPickup list
            PlayerPickup pickup = FindObjectOfType<PlayerPickup>();
            if (pickup._nearbyinteractables.Contains(GetComponent<Interactable>()))
            {
                //If so remove before destroy
                pickup._nearbyinteractables.Remove(GetComponent<Interactable>());
            }
        }
    }

    //Interaction Systems
    public void Highlight()
    {
        if (this.enabled)
        {
            if (highlightMaterial != null && sprRndr != null)
                sprRndr.material = highlightMaterial;

            UpdateHelpTextPickup();
        }

        
    }

    public void UnHighlight()
    {
        if (this.enabled)
        {
            if (defaultMaterial != null && sprRndr != null)
            {
                sprRndr.material = defaultMaterial;
            }
            //if item highlighted, unhiglight
        }



    }

    public void Activate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("ACTIVATE");
            _ActivateEvent.Invoke();
        }


    }

    public void UpdateHelpTextPickup()
    {
        if (FindObjectOfType<Player>().helpText != null)
            FindObjectOfType<Player>().helpText.UpdateTextPickup(pickupString);
    }

}
