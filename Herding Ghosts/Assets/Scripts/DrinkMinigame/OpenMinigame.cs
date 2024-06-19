using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMinigame : MonoBehaviour
{

    public GameObject m_minigameCanvas;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableMinigame()
    {
        m_minigameCanvas.SetActive(true);
        ui.SetActive(false);
    }

    public void DisableMinigame()
    {
        m_minigameCanvas.SetActive(false);
    }
}
