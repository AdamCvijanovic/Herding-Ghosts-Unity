using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool pausedState;
    // Start is called before the first frame update
    void Start()
    {
        pausedState = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Resume ()
    {
        if(pausedState == true)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            pausedState = false;
        }
    }

    public void Pause()
    {
        if(pausedState == false)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            pausedState = true;
        }   
    }
}
