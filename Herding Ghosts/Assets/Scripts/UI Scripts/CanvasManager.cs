using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    public GameObject introductionMenu;
    public GameObject menuElements;
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject controlsMenu;
    public GameObject pantryUI;
    public GameObject seedBarrelUI;

    public GrimoireUI grimoireUI;
    
    //public Image playerIMG;
    public Image customerIMG;

    public bool youWin = false;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
        introductionMenu.SetActive(true);
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
        controlsMenu.SetActive(false);

        GrimoireDeactivate();

    }

    // Update is called once per frame
    void Update()
    {
        if(youWin == true)
        {
            WinMenu();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
       // GetComponent<PlayerUI>().isPaused = false;
        
        Time.timeScale = 1f;
    }

    public void PauseMenu()
    {
        //Disable Other Menus
        DisableOtherUIElements();

        if (pauseMenu.activeSelf)
        {
            menuElements.SetActive(false);
            pauseMenu.SetActive(false);
            Resume();
        }
        else if(controlsMenu.activeInHierarchy == false && loseMenu.activeInHierarchy == false && winMenu.activeInHierarchy == false && introductionMenu.activeInHierarchy == false && pauseMenu.activeInHierarchy == false)
        {
            Pause();
            menuElements.SetActive(true);
            pauseMenu.SetActive(true);
        }
    }
/*
    public void LoseMenu()
    {
        menuElements.SetActive(true);
        loseMenu.SetActive(true);
    }
*/
    public void WinMenu()
    {
        if(controlsMenu.activeInHierarchy == false && loseMenu.activeInHierarchy == false && winMenu.activeInHierarchy == false && introductionMenu.activeInHierarchy == false && pauseMenu.activeInHierarchy == false)
        {
            Pause();
            menuElements.SetActive(true);
            winMenu.SetActive(true);
        }
    }
    
    public void GrimoireToggle()
    {

        if (!grimoireUI.isActive)
        {
            GrimoireActivate();
        }
        else
        {
            GrimoireDeactivate();
        }
    }

    public void GrimoireActivate()
    {
        grimoireUI.gameObject.SetActive(true);
        grimoireUI.Activate();
    }

    public void GrimoireDeactivate()
    {
        grimoireUI.Deactivate();
    }
    public void PantryActivate()
    {
        pantryUI.SetActive(true);
        pantryUI.GetComponent<PantryUI>();
    }

    public void PantryDeactivate()
    {
        pantryUI.GetComponent<PantryUI>();
        pantryUI.SetActive(false);
    }

    public void SeedBarrelActivate()
    {
        seedBarrelUI.SetActive(true);
        seedBarrelUI.GetComponent<SeedButtonUI>();
    }

    public void SeedBarrelDeactivate()
    {
        seedBarrelUI.GetComponent<SeedButtonUI>();
        seedBarrelUI.SetActive(false);
    }

    public void DisableOtherUIElements()
    {
        if (pantryUI.activeInHierarchy)
        {
            PantryDeactivate();
        }

        grimoireUI.tooltipAnimator.SetBool("isActive", false);
        grimoireUI.grimoireAnimator.SetBool("isActive", false);
    }

    public void EnableUIElements()
    {
        grimoireUI.tooltipAnimator.SetBool("isActive", true);
    }

}
