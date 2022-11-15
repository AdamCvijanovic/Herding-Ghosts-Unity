using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeInOut : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        animator.SetBool("UIActive", true);
    }

    public void FadeOut()
    {
        animator.SetBool("UIActive", false);
    }

    public void ChangeSceneAnimEvent()
    {

        //put level change logic here

        //FindObjectOfType<LevelManager>().NightDayScene();
        FindObjectOfType<LevelManager>().ActivateEventAfterFade();
    }

}
