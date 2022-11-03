using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UITImerClock : MonoBehaviour
{
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
        currentTime = maxTime;
        DEbugPrint();
    }

    public void Countdown()
    {
        currentTime -= Time.deltaTime;
        _animator.SetFloat("TimerProgression", -(currentTime/maxTime));

        if(currentTime <= 0)
        {
            this.CountdownComplete.Invoke();
        }
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

    public void DEbugPrint()
    {
        Debug.Log("TIMER COMPELTE");
    }


}
