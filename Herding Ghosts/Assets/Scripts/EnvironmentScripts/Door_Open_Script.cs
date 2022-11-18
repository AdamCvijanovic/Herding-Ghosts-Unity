using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open_Script : MonoBehaviour
{

    public Door_Anim_Script doorAnimator;

    public bool isStoreOpen;

    public Door_Sign_Script doorSign;

    CustomerManager _customerMngr;

    // Start is called before the first frame update
    void Start()
    {
        _customerMngr = FindObjectOfType<CustomerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<LevelManager>().isStoreOpen)
        {
            DisableInteractable();
        }
    }

    public void DisableInteractable()
    {
        GetComponent<Interactable>().UnHighlight();
        GetComponent<Interactable>().enabled = false;
    }

    public void OpenCloseDoor()
    {
        isStoreOpen = !isStoreOpen;

        _customerMngr.storeOpen = isStoreOpen;

        FindObjectOfType<CustomerSpawnerDestination>().RestartCounter();

        FindObjectOfType<CustomerManager>().OpenStore();

    }
}
