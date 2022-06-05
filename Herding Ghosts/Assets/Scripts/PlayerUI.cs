using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{

    public bool isPaused;

    public PauseMenu pauseMenu;
    //public GameObject pauseMenu;

    public WinTextUI winTextPanel;

    public bool hasLost;

    // Start is called before the first frame update
    void Start()
    {
        winTextPanel = FindObjectOfType<WinTextUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Pause()
    {

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

        if (!hasLost)
        {
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

            hasLost = true;
        }
    }

    public void Win()
    {
        //Debug.Log("Win?");

        isPaused = true;

        if (isPaused)
        {
            pauseMenu.gameObject.SetActive(true);
            pauseMenu.Win();
        }
    }

    

    public void UpdateWinText(DaughterLogic daughter)
    {
        winTextPanel.UpdateText(daughter);
    }

}
