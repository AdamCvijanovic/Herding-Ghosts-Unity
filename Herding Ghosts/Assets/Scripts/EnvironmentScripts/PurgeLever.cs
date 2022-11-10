using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurgeLever : MonoBehaviour
{
    public CauldronDestination _cauldron;
    public Animator _animator;
    public float ResetCountdown;


    //timer stuff
    public bool isResetting;

    public float maxTime = 15.0f;
    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        _cauldron = FindObjectOfType<CauldronDestination>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    public void Countdown()
    {
        if (isResetting)
        {
            currentTime -= Time.deltaTime;
            _animator.SetFloat("TimerProgression", -(currentTime / maxTime));

            if (currentTime <= 0)
            {
                Reset();
            }
        }

    }

    public void Reset()
    {
        isResetting = false;
        currentTime = maxTime;
        _animator.SetBool("PurgePulled", false);
    }

    public void LeverPulled()
    {
        //Animator do Things
        _animator.SetBool("PurgePulled", true);

        //start reset timer
        isResetting = true;

        //Clear Inventory
        PurgeCauldron();
    }

    public void PurgeCauldron()
    {
        _cauldron.ClearInventory();
    }

}
