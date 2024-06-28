using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkHelp : MonoBehaviour
{

    bool opened = false;
    public GameObject helpscreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void ManageHelpScreen()
    {
        if(opened)
        {
            helpscreen.SetActive(false);
            opened = false;
        }

        else
        {
            helpscreen.SetActive(true);
            opened = true;
        }
    }

}
