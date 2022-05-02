using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{

    public bool isPaused;

    public GameObject pauseMenu;


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
        Debug.Log("PASUE?");

        isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenu.SetActive(true);
        }
        else 
        {
            pauseMenu.SetActive(false);
        }

    }

}
