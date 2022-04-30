using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{

    public Image timerFill;
    public GameObject timer;
    public float currentTime = 60.0f;
    public float maxTime = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerFill.fillAmount = currentTime / maxTime;
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            timer.SetActive(false);
        }
    }


}
