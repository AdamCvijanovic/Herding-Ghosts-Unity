using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlantTimer : MonoBehaviour
{

    public PlanterBox parentPlanter;

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

    //audio
    public bool isHarvested;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.enabled = false;
        maxTime = currentTime;
        displayImage = gameObject.GetComponent<SpriteRenderer>();
        displayImage.sprite = seedling;
        isHarvested = false;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer();

        ChangeSprite();

        TimerReset();

        if (isHarvested)
        {
            Debug.Log("Crop has been harvested!!!");
            CropAudioManager.instance.PlayCropAudio();
            isHarvested = false;
        }
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
        if (!FindObjectOfType<PlayerPickup>()._isHolding)
        {
            if (displayImage.sprite == plant && foodPicked != true)
            {
                Item item = Instantiate(prefab, this.transform.position, Quaternion.identity).GetComponent<Item>();
                item.transform.parent = this.transform;
                FindObjectOfType<PlayerPickup>().PickupItem(item);
                foodPicked = true;
                interactable.UnHighlight();
                interactable.enabled = false;
                displayImage.sprite = seedling;
                currentTime = maxTime;

                StartCoroutine(CoroutineAction(item));
            }
        }
        isHarvested = true;

    }

    public IEnumerator CoroutineAction(Item item)
    {
        Debug.Log("Coroutine has started");
        // do some actions here
        yield return new WaitForEndOfFrame(); // wait for end of update
                                              // do some actions after waiting for update
        Debug.Log("Coroutine has ended");
        FindObjectOfType<PlayerPickup>().PickupItem(item);

        //clear parent planter if one exists
        if (parentPlanter != null)
        {
            Destroy(this.gameObject);
        }

        //yield return null;
    }

    


}
