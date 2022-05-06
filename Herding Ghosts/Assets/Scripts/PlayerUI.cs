using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{

    public bool isPaused;

    public PauseMenu pauseMenu;
    //public GameObject pauseMenu;

    public GameObject textPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Pause()
    {
        Debug.Log("PAUSE?");

        isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenu.gameObject.SetActive(true);
            pauseMenu.Pause();
        }
        else 
        {
            pauseMenu.gameObject.SetActive(false);
            pauseMenu.Resume();
        }

    }

    public void Lose()
    {
        Debug.Log("Lose?");

        isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenu.gameObject.SetActive(true);
            pauseMenu.Lose();
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
            pauseMenu.Resume();
        }

    }

    public void Win()
    {
        Debug.Log("Win?");

        isPaused = true;

        if (isPaused)
        {
            pauseMenu.gameObject.SetActive(true);
            pauseMenu.Win();
        }
        

    }

}
