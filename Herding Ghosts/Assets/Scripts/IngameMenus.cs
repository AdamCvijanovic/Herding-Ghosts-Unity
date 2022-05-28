using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenus : MonoBehaviour
{

    public GameObject introductionMenu;
    public GameObject menuElements;
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject controlsMenu;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
        introductionMenu.SetActive(true);
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause(){Time.timeScale = 0f;}

    public void Resume(){Time.timeScale = 1f;}



    public void PauseMenu()
    {
        if(controlsMenu.active == false && loseMenu.active == false && winMenu.active == false && introductionMenu.active == false && pauseMenu.active == false)
        {
            Pause();
            menuElements.SetActive(true);
            pauseMenu.SetActive(true);
        }
        
    }

    public void LoseMenu(){}

    public void WinMenu(){}

}
