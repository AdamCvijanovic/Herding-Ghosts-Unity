using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimoireUI : MonoBehaviour
{

    public bool isActive;

    public Animator grimoireAnimator;

    public Animator tooltipAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        isActive = true;
        GPause();
        animationActivate();
    }

    public void Deactivate()
    {
        isActive = false;
        GResume();
        animationDeactivate();
    }

    public void GPause()
    {
        Time.timeScale = 0f;
    }

    public void GResume()
    {   
        Time.timeScale = 1f;
    }

    public void animationActivate()
    {
        grimoireAnimator.SetBool("isActive",true);
        tooltipAnimator.SetBool("isActive",false);

    }

    public void animationDeactivate()
    {
        grimoireAnimator.SetBool("isActive", false);
        tooltipAnimator.SetBool("isActive", true);
    }

}
