using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;


public class LevelManager : MonoBehaviour
{

    public CanvasManager canvasManager;
    public UIFadeInOut uiFadeInOut;

    public Light2D globalLight;
    public Color dayColor;
    public Color nightColor;
    public float colorTime = 0;
    float colorIncrement = 0.2f;

    public int maxCustomerCount;
    public int dayNumber;

    public float remainingCustomers;

    public bool isDayOne;
    public bool isStoreOpen;
    public bool minCustomersServed;

    //end cutscene event
    public UnityEvent _ActivateEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.ResetDailyCounters();
        canvasManager = FindObjectOfType<CanvasManager>();
        uiFadeInOut = FindObjectOfType<UIFadeInOut>();
        SetMaxCustomers();
        ResetLightingTimer();
    }

    // Update is called once per frame
    void Update()
    {
        remainingCustomers = (maxCustomerCount - FindObjectOfType<GameManager>().satisfiedCustomers);

        ChangeLighting();

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

    public void OpenStore()
    {
        isStoreOpen = true;
    }

    public void ChangeLighting()
    {
        if(globalLight != null)
        {
            if (minCustomersServed)
            {
                globalLight.color = Color.Lerp(dayColor, nightColor, colorTime);
            }
            else
            {
                globalLight.color = Color.Lerp(nightColor, dayColor, colorTime);
            }

            if (colorTime < 1)
            {
                colorTime += Time.deltaTime * colorIncrement;
            }
        }
        
    }

    public void ResetLightingTimer()
    {
        colorTime = 0;
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

    public void AllCustomersServedForTheDay()
    {
        ResetLightingTimer();
        minCustomersServed = true;
    }

    public void SetMaxCustomers()
    {
        switch (GameManager.instance.dayNumber)
        {
            case 0:
                maxCustomerCount = 1;
                dayNumber = 1;
                isDayOne = true;
                break;
            case 3:
                maxCustomerCount = 3;
                dayNumber = 2;
                isDayOne = false;
                break;
            case 6:
                maxCustomerCount = 5;
                dayNumber = 3;
                isDayOne = false;
                break;
            default:
                maxCustomerCount = 1;
                break;
        }
    }

}
