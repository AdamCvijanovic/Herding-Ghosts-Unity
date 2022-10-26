using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open_Script : MonoBehaviour
{

    public Door_Anim_Script doorAnimator;

    public bool isStoreOpen;

    public Door_Sign_Script doorSign;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCloseDoor()
    {
        isStoreOpen = !isStoreOpen;

        FindObjectOfType<CustomerManager>().storeOpen = isStoreOpen;
    }
}
