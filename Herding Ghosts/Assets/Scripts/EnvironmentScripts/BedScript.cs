using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedScript : MonoBehaviour
{
    public LevelManager levelManager;
    public bool sleepActive = false;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sleep()
    {
        if (!sleepActive)
        {
            Debug.Log("Sleep");
            levelManager.EndDay();
            sleepActive = true;
        }
    }
}
