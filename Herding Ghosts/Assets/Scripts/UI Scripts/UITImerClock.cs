using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UITImerClock : MonoBehaviour
{
    public bool isCounting;

    public float maxTime = 15.0f;
    public float currentTime;

    public Animator _animatorHand;
    public Animator _animatorClock;

    // Start is called before the first frame update
    void Start()
    {
        _animatorClock = GetComponent<Animator>();
        _animatorHand = GetComponentInChildren<Animator>();
        ResetClock();
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    public void ResetClock()
    {
        isCounting = false;
        currentTime = maxTime;
        
        // ideally we should have a animation function
        _animatorHand.SetFloat("TimerProgression", 1 - (currentTime / maxTime));
    }

    public void StartClock()
    {
        isCounting = true;
    }

    public void StopClock()
    {
        isCounting = false;
    }

    public void Countdown()
    {
        if (isCounting)
        {
            currentTime -= Time.deltaTime;
            _animatorHand.SetFloat("TimerProgression", 1-(currentTime / maxTime));
            _animatorClock.SetFloat("Threshold",currentTime);

            if (currentTime <= 0)
            {
                this.CountdownComplete.Invoke();
            }
        }
        
    }

    public void CountDownFinished()
    {
        FindObjectOfType<CustomerLogic>().CustomerDisatisfied();
        _animatorClock.SetFloat("Threshold", maxTime);
        ResetClock();
    }

    [SerializeField]
    private UnityEvent _countdownCompleteEvent;

    public UnityEvent CountdownComplete
    {
        get
        {
            return this._countdownCompleteEvent;
        }
    }
}
