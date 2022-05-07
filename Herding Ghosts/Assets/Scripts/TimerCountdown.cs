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
    public GameObject _winMenu;

    // Start is called before the first frame update
    void Start()
    {
        // added this to make sure the scene runs when loaded, had an issue where it wouldnt run on scene load
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timerFill.fillAmount = currentTime / maxTime;
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            _winMenu.SetActive(true);
            Time.timeScale = 0f;
            timer.SetActive(false);
        }
    }


}
