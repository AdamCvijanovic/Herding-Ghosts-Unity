using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantTimer : MonoBehaviour
{

    public IngredientItem.IngredientType ingredientType;
    public GameObject prefab;

    public Interactable interactable;

    private SpriteRenderer displayImage;
    public Sprite seedling;
    public Sprite sprout;
    public Sprite plant;

    public float firstTransition = 3.0f;
    public float secondTransition = 2.0f;

    public float currentTime = 10.0f;
    [SerializeField]
    private float maxTime;

    public bool foodPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.enabled = false;
        maxTime = currentTime;
        displayImage = gameObject.GetComponent<SpriteRenderer>();
        displayImage.sprite = seedling;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer();

        ChangeSprite();

        TimerReset();
    }



    public void CountdownTimer()
    {
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
        }
    }

    public void ChangeSprite()
    {
        if (currentTime <= firstTransition && currentTime > secondTransition)
        {
            displayImage.sprite = sprout;
        }
        if (currentTime <= secondTransition && currentTime > 0)
        {
            displayImage.sprite = plant;
            interactable.enabled = true;
        }
    }

    public void TimerReset()
    {
        // Timer Reset
        if (foodPicked == true)
        {
            currentTime = maxTime;
            displayImage.sprite = seedling;
            foodPicked = false;
            interactable.UnHighlight();
            interactable.enabled = false;
        }
    }
    public void SpawnItem()
    {
        if(displayImage.sprite == plant && foodPicked != true)
        {
            Item item = Instantiate(prefab, this.transform.position, Quaternion.identity).GetComponent<Item>();
            item.transform.parent = this.transform;
            FindObjectOfType<PlayerPickup>().PickupItem(item);
            foodPicked = true;
            interactable.UnHighlight();
            interactable.enabled = false;
            displayImage.sprite = seedling;
            currentTime = maxTime;

        }
    }


}
