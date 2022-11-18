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
    public int dayNumber;

    public float remainingCustomers;

    public bool isStoreOpen;
    public bool minCustomersServed;

    //end cutscene event
    public UnityEvent _ActivateEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
        uiFadeInOut = FindObjectOfType<UIFadeInOut>();
        SetMaxCustomers();
    }

    // Update is called once per frame
    void Update()
    {
        remainingCustomers = (maxCustomerCount - FindObjectOfType<GameManager>().satisfiedCustomers);
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


    public void RepeatDay()
    {
        if (GameManager.instance.dayNumber >= 9)
        {
            Debug.Log("Third Day passed");
            RollCredits();
        }
        else
        {
            Debug.Log("A new day begins");
            SceneManager.LoadScene("PGF_Master", LoadSceneMode.Single);
        }
    }

    public void RollCredits()
    {
        SceneManager.LoadScene("Game_Outro_Cutscene", LoadSceneMode.Single);
    }

    public void RollCredits2()
    {
        SceneManager.LoadScene("Game_Credits", LoadSceneMode.Single);
        GameManager.instance.ClearAllFields();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu NEW", LoadSceneMode.Single);
    }

    public void NightDayScene()
    {
        GameManager.instance.IncrementDay();

        Debug.Log("Third Day passed");
        SceneManager.LoadScene("NightToDayCutscene", LoadSceneMode.Single);
    }

    public void ActivateEventAfterFade()
    {
        Debug.Log("ACTIVATE");
        _ActivateEvent.Invoke();
    }

    public void SetMaxCustomers()
    {
        switch (GameManager.instance.dayNumber)
        {
            case 0:
                maxCustomerCount = 1;
                dayNumber = 1;
                break;
            case 3:
                maxCustomerCount = 3;
                dayNumber = 2;
                break;
            case 6:
                maxCustomerCount = 5;
                dayNumber = 3;
                break;
            default:
                maxCustomerCount = 1;
                break;
        }
    }

}
