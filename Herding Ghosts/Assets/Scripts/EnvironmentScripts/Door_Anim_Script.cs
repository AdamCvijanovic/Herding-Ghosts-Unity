using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Anim_Script : MonoBehaviour
{
    public Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("Door_Open"))
        {
            Debug.Log("DOOR IS CLOSIGN");
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        doorAnimator.SetTrigger("Open");
    }

    public void CloseDoor()
    {
        doorAnimator.ResetTrigger("Open");
        doorAnimator.SetTrigger("Close");
    }
}
