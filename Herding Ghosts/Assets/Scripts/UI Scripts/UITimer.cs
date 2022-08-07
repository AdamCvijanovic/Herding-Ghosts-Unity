using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
public float countdown = 10.0f;
public float currentTime;
public Image timerFill;
public Color yellowColor;
public Color redColor;
public Animator shake;
public GameObject menues;
public GameObject losemenu;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = countdown;
        yellowColor.a = 1;
        redColor.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timerFill.fillAmount = currentTime / countdown;
        if(currentTime <= 10.0f && currentTime> 5.0f)
        {
            timerFill.color = yellowColor;
        }
        else
            if(currentTime <= 5.0f)
            {
                timerFill.color = redColor;
            }

        if(currentTime <= 10.0f)
        {
            ShakeThat();
        }
        if(currentTime <= 0.0f)
        {
            Time.timeScale = 0f;
            menues.SetActive(true);
            losemenu.SetActive(true);
        }

    }

    void ShakeThat()
    {
        shake.Play("TimerShake");
    }
}