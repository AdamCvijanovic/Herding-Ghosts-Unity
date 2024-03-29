using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class WorkstationInventory : Inventory
{
    //public Inventory inventory;
    private CustomerManager custMngr;

    public List<Transform> transforms = new List<Transform>();

    //ItemSlot Sprites
    public Sprite defaultItemSlotSprite;
    public Sprite successItemSlotSprite;
    public Sprite failItemSlotSprite;

    public UnityEvent itemAdded;

    //audio
    public AudioSource audioFoodAdd1;
    public AudioSource audioFoodAdd2;
    public AudioSource audioFoodAdd3;

    private int randomAudioNumber;

    private float minPitch;
    private float maxPitch;

    // Start is called before the first frame update
    void Start()
    {
        custMngr = FindObjectOfType<CustomerManager>();

        
        minPitch = 0.9f;
        maxPitch = 1.04f;
        randomAudioNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveItemsToPostion()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].transform.position = transforms[i].position;
            CheckIfCorrectItemInSlot(i);
        }
    }

    public override void AddItemToList(Item item)
    {
        //if(item.GetFoodType() == FoodItem.FoodType.Carrot)

        if (item.GetComponent<IngredientItem>())
        {
            _items.Add(item);
            MoveItemsToPostion();

            GetComponent<WorkstationDestination>().InventoryCheck();

            itemAdded.Invoke();

            //audio
            randomAudioNumber = Random.Range(1, 4);
            switch (randomAudioNumber)
            {
                case 1:
                audioFoodAdd1.pitch = Random.Range(minPitch, maxPitch);
                audioFoodAdd1.Play();
                break;

                case 2:
                audioFoodAdd2.pitch = Random.Range(minPitch, maxPitch);
                audioFoodAdd2.Play();
                break;

                case 3:
                audioFoodAdd3.pitch = Random.Range(minPitch, maxPitch);
                audioFoodAdd3.Play();
                break;
            }
        }
    }

    public void ClearInventory()
    {
        List<IngredientItem> temp = new List<IngredientItem>();

        foreach (IngredientItem i in _items)
        {
            temp.Add(i);
        }

        foreach (IngredientItem i in temp)
        {
            RemoveItemFromList(i);
            Destroy(i.gameObject);
        }

        ResetSlotSprites();
    }

    public void CheckIfCorrectItemInSlot(int index)
    {
        Debug.Log("Submitted Ingredient Type: " + _items[index].GetIngredientType());

        if (custMngr._desiredFoodItem != null)
        {
            for (int i = 0; i < 3; i++)
            {
                if (custMngr._desiredFoodItem.recipeObj.ingredient[i] == _items[index].GetIngredientType())
                {
                    transforms[i].gameObject.GetComponent<SpriteRenderer>().sprite = successItemSlotSprite;
                    return;
                }

            }

            transforms[index].gameObject.GetComponent<SpriteRenderer>().sprite = failItemSlotSprite;
        }
    }

    public void ResetSlotSprites()
    {
        //reset slot sprites
        transforms[0].gameObject.GetComponent<SpriteRenderer>().sprite = defaultItemSlotSprite;
        transforms[1].gameObject.GetComponent<SpriteRenderer>().sprite = defaultItemSlotSprite;
        transforms[2].gameObject.GetComponent<SpriteRenderer>().sprite = defaultItemSlotSprite;
    }



}
