using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject pauseMenuTextGO;
    public GameObject pauseMenuWinGO;
    public GameObject pauseMenuLoseGO;

    public bool pausedState;

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
        if (pausedState == true)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            pausedState = false;

            pauseMenuTextGO.SetActive(false);
            pauseMenuWinGO.SetActive(false);
            pauseMenuLoseGO.SetActive(false);
        }
    }

    public void Pause()
    {
        if(pausedState == false)
        {
            pauseMenuUI.SetActive(true);
            pauseMenuTextGO.SetActive(true);
            Time.timeScale = 0f;
            pausedState = true;
            // if(tutorialMenu == false){}
        }   
    }

    public void Win()
    {
        if (pausedState == false)
        {
            pauseMenuUI.SetActive(true);
            pauseMenuWinGO.SetActive(true);
            Time.timeScale = 0f;
            pausedState = true;
        }
    }

    public void Lose()
    {
        if (pausedState == false)
        {
            pauseMenuUI.SetActive(true);
            pauseMenuLoseGO.SetActive(true);
            Time.timeScale = 0f;
            pausedState = true;
        }
    }
}
