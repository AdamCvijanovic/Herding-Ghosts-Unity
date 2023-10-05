using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Anim_Script : MonoBehaviour
{
    public Animator doorAnimator;
    public SpriteRenderer sprRndr;

    //audio
    public AudioSource audioBell;
    public AudioSource audioBell2;
    private int audioCounter;

    // Start is called before the first frame update
    void Start()
    {
        sprRndr = GetComponent<SpriteRenderer>();
        audioCounter = 1;
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

        //audio
        if (audioCounter == 1)
        {
            audioBell.Play();
            audioCounter = 2;
        }
        else if (audioCounter == 2)
        {
            audioBell2.Play();
            audioCounter = 1;
        }
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
