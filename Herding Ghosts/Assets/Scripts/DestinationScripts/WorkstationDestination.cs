using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationDestination : Destination
{

    public int maxItems = 3;

    //take the inventory out
    //should reference a seperate inventory componenet
    //public List<IngredientItem> _items = new List<IngredientItem>();

    public Inventory _inventory;


    public List<Transform> _itemPositions = new List<Transform>();
    

    //_recipe list shoudl be the only relevant thing here
    public List<RecipeObject> _recipeList = new List<RecipeObject>();

    //Accepted Items

    //Recipe Outputs




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //we could do with an inventory script that handles available space and inventory slots seperately
    public bool HasInventorySpace()
    {

        Debug.Log("ITEM LIST SIZE == " + _inventory._items.Count);

        return _inventory._items.Count <= maxItems-1;
    }

    public void AddItemToList(IngredientItem item)
    {
        _inventory._items.Add(item);
        MoveItemToSlotPosition(item);

        InventoryCheck();
    }

    public void MoveItemToSlotPosition(IngredientItem item)
    {
        if(_inventory._items.Count > 0)
        {
            int index = _inventory._items.IndexOf(item);
            item.transform.position = _itemPositions[index].transform.position;
        }
    }

    public void InventoryCheck()
    {
        RecipeObject tempRecipe = null;

        if (_inventory._items.Count >= 3)
            if (_recipeList.Count > 0)
            {
                foreach (RecipeObject recipe in _recipeList)
                {
                    if (RecipeCheck(recipe))
                    {
                        tempRecipe = recipe;
                    }
                }

                if (tempRecipe != null)
                {
                    RecipeCook(tempRecipe);
                }
            }
    }

    //Scan through existing recipes
    //See if items at index's 0-2 match
    //consume items
    //output prefab
    public bool RecipeCheck(RecipeObject recipeIn)
    {

        Debug.Log("Recipe Check");

        //bool recipeTrue = false;
        bool ingredient0 = false;
        bool ingredient1 = false;
        bool ingredient2 = false;

        //For the love of god fix this
        if(_inventory._items[0].GetIngredientType() == recipeIn.ingredient0 ||
            _inventory._items[0].GetIngredientType() == recipeIn.ingredient1 ||
            _inventory._items[0].GetIngredientType() == recipeIn.ingredient2)
        {
            ingredient0 = true;
        }
        else
        {
            ingredient0 = false;
        }

        if(_inventory._items[1].GetIngredientType() == recipeIn.ingredient0 ||
            _inventory._items[1].GetIngredientType() == recipeIn.ingredient1 ||
            _inventory._items[1].GetIngredientType() == recipeIn.ingredient2)
        {
            ingredient1 = true;
        }
        else
        {
            ingredient1 = false;
        }

        if(_inventory._items[2].GetIngredientType() == recipeIn.ingredient0 ||
           _inventory._items[2].GetIngredientType() == recipeIn.ingredient1 ||
           _inventory._items[2].GetIngredientType() == recipeIn.ingredient2)
        {
            ingredient2 = true;
        }
        else
        {
            ingredient2 = false;
        }



        return (ingredient0 && ingredient1 && ingredient2);
        
    }

    public void RecipeCook(RecipeObject recipeIn)
    {
        //temp store
        GameObject ingredient0 = _inventory._items[0].gameObject;
        GameObject ingredient1 = _inventory._items[1].gameObject;
        GameObject ingredient2 = _inventory._items[2].gameObject;

        ConsumeItems(ingredient0, ingredient1, ingredient2);

        Instantiate(recipeIn.recipePrefab, this.gameObject.transform.position, Quaternion.identity);
    }


    public void RemoveItemFromList()
    {
        _inventory._items.Remove(_inventory._items[0]);
    }

    public void RemoveItemFromList(int i)
    {
        _inventory._items.Remove(_inventory._items[i]);
    }

    public void RemoveItemFromList(IngredientItem item)
    {
        if (_inventory._items.Contains(item))
            _inventory._items.Remove(item);
    }

    public void ConsumeItems(GameObject ingredient0, GameObject ingredient1, GameObject ingredient2)
    {
        RemoveItemFromList(ingredient0.GetComponent<IngredientItem>());
        RemoveItemFromList(ingredient1.GetComponent<IngredientItem>());
        RemoveItemFromList(ingredient2.GetComponent<IngredientItem>());

        Destroy(ingredient0);
        Destroy(ingredient1);
        Destroy(ingredient2);
    }
}