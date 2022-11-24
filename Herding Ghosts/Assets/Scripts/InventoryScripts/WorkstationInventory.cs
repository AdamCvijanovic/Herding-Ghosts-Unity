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

    // Start is called before the first frame update
    void Start()
    {
        custMngr = FindObjectOfType<CustomerManager>();
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
            FMODUnity.RuntimeManager.PlayOneShot("event:/PutInCauldron");
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
            Debug.Log("Desired Ingredient Type:  " + custMngr._desiredFoodItem.recipeObj.ingredient0);
            //check index
            switch (index)
            {
                case 0:
                    //check if correct ingredient
                    if (custMngr._desiredFoodItem.recipeObj.ingredient0 == _items[index].GetIngredientType())
                    {
                        Debug.Log("Ingredient 1 Correct");
                        transforms[0].gameObject.GetComponent<SpriteRenderer>().sprite = successItemSlotSprite;
                    }
                    else
                    {
                        transforms[0].gameObject.GetComponent<SpriteRenderer>().sprite = failItemSlotSprite;
                    }
                    break;
                case 1:
                    //check if correct ingredient
                    if (custMngr._desiredFoodItem.recipeObj.ingredient1 == _items[index].GetIngredientType())
                    {
                        Debug.Log("Ingredient 2 Correct");
                        transforms[1].gameObject.GetComponent<SpriteRenderer>().sprite = successItemSlotSprite;
                    }
                    else
                    {
                        transforms[1].gameObject.GetComponent<SpriteRenderer>().sprite = failItemSlotSprite;
                    }
                    break;
                case 2:
                    //check if correct ingredient
                    if (custMngr._desiredFoodItem.recipeObj.ingredient2 == _items[index].GetIngredientType())
                    {
                        Debug.Log("Ingredient 3 Correct");
                        transforms[2].gameObject.GetComponent<SpriteRenderer>().sprite = successItemSlotSprite;
                    }
                    else
                    {
                        transforms[2].gameObject.GetComponent<SpriteRenderer>().sprite = failItemSlotSprite;
                    }
                    break;
            }
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
