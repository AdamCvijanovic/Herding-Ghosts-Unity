using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public CanvasManager canvasManager;
    public UIFadeInOut uiFadeInOut;

    public Color dayColor;
    public Color nightColor;

    public int maxCustomerCount;

    //end cutscene event
    public UnityEvent _ActivateEvent = new UnityEvent();

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
        if(uiFadeInOut != null)
            uiFadeInOut.FadeIn();
    }

    public void EndDay()
    {
        if (uiFadeInOut != null)
            uiFadeInOut.FadeOut();
    }



    public void RollCredits()
    {
        SceneManager.LoadScene("Game_Outro_Cutscene", LoadSceneMode.Single);
    }

    public void RollCredits2()
    {
        SceneManager.LoadScene("Game_Credits", LoadSceneMode.Single);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void NightDayScene()
    {
        SceneManager.LoadScene("NightToDayCutscene", LoadSceneMode.Single);
    }

    public void ActivateEventAfterFade()
    {
        Debug.Log("ACTIVATE");
        _ActivateEvent.Invoke();
    }

}
