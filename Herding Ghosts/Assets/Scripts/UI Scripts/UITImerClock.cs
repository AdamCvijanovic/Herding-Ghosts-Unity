using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UITImerClock : MonoBehaviour
{
    public bool isCounting;

    public float maxTime = 15.0f;
    public float currentTime;

    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
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
    }

    public void StartClock()
    {
        isCounting = true;
    }

    public void StopClock()
    {
        isCounting = true;
    }

    public void Countdown()
    {
        if (isCounting)
        {
            currentTime -= Time.deltaTime;
            _animator.SetFloat("TimerProgression", -(currentTime / maxTime));

            if (currentTime <= 0)
            {
                this.CountdownComplete.Invoke();
            }
        }
        
    }

    public void CountDownFinished()
    {
        FindObjectOfType<CustomerLogic>().SetState(CustomerLogic.CustomerState.Leaving);
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
