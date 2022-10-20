using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrannyProximity : MonoBehaviour
{
    private GameObject animHolder;
    private Animator grannyAnimator;


    void Start()
    {
        animHolder = GameObject.Find("GrandmaHead");
        grannyAnimator = animHolder.GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            grannyAnimator.SetBool("GrandmaHeadBool", true);
        }
    }
       private void OnTriggerExit2D(Collider2D col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            grannyAnimator.SetBool("GrandmaHeadBool", false);
        }
    }
}
