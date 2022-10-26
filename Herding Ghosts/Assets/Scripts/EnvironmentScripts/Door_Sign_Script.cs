using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Sign_Script : MonoBehaviour
{

    public Door_Open_Script doorScript;
    public Animator doorSignAnimator;

    // Start is called before the first frame update
    void Start()
    {
        doorSignAnimator = GetComponent<Animator>();
        doorScript = FindObjectOfType<Door_Open_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimDoorSign();
    }

    public void AnimDoorSign()
    {
        doorSignAnimator.SetBool("IsOpen", doorScript.isStoreOpen);
    }
}
