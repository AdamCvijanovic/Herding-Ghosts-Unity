using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantTimer : MonoBehaviour
{
    
    private SpriteRenderer displayImage;
    public Sprite seedling;
    public Sprite sprout;
    public Sprite plant;

    public float firstTransition = 3.0f;
    public float secondTransition = 2.0f;


   // public Image circleTimer;
    public float currentTime = 10.0f;
    private float maxTime;

    public bool foodPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = currentTime;
        displayImage = gameObject.GetComponent<SpriteRenderer>();
        displayImage.sprite = seedling;
    }

    // Update is called once per frame
    void Update()
    {

        if(currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
        }

	   // circleTimer.fillAmount = currentTime / maxTime;;
	
        if(currentTime <= firstTransition && currentTime > secondTransition)
        {
            displayImage.sprite = sprout;
        }
        if(currentTime <= secondTransition && currentTime > 0)
        {
            displayImage.sprite = plant;
        }

        // Timer Reset
        if(foodPicked == true && currentTime <= 0)
        {
            Debug.Log("Food was picked");
            currentTime = maxTime;
            displayImage.sprite = seedling;
            foodPicked = false;
        }
    }
}
