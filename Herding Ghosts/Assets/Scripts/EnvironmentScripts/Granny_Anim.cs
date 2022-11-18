using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granny_Anim : MonoBehaviour
{
    public Animator granny_Animator;

    // Start is called before the first frame update
    void Start()
    {
        granny_Animator = GetComponentInChildren<Animator>();
        granny_Animator.Play("Idle"); //idle anim 
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            granny_Animator.Play("Fading"); 
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            granny_Animator.Play("FadeIn");

        }
    }
}
