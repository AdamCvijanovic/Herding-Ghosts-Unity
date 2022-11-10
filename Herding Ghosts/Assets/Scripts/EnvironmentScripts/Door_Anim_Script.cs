using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Anim_Script : MonoBehaviour
{
    public Animator doorAnimator;
    public SpriteRenderer sprRndr;

    // Start is called before the first frame update
    void Start()
    {
        sprRndr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("Door_Open"))
        {
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

    public void ChangeLayerInFrontOfGhost()
    {
        sprRndr.sortingOrder = 4;


    }

    public void ChangeLayerBehindGhost()
    {
        sprRndr.sortingOrder = 2;
    }
}
