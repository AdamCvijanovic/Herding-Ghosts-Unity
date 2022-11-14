using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public CanvasManager canvasManager;
    public UIFadeInOut uiFadeInOut;

    public Color dayColor;
    public Color nightColor;

    public int maxCustomerCount;

    // Start is called before the first frame update
    void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
        uiFadeInOut = FindObjectOfType<UIFadeInOut>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDay()
    {
        uiFadeInOut.FadeIn();
    }

    public void EndDay()
    {
        uiFadeInOut.FadeOut();
    }

    public void RollCredits()
    {
        SceneManager.LoadScene("NightToDayCutscene", LoadSceneMode.Single);
    }

    public void NightDayScene()
    {
        SceneManager.LoadScene("Game_Outro_Cutscene", LoadSceneMode.Single);
    }

}
