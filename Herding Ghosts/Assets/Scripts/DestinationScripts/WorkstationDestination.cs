using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationDestination : Destination
{

    public int maxItems = 3;

    public List<FoodItem> _items = new List<FoodItem>();
    public List<RecipeObject> _recipeList = new List<RecipeObject>();

    //take teh inventory out
    //_recipe list shoudl be the only relevant thign here
    //shoudl reference inventory componenet


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

        Debug.Log("ITEM LIST SIZE == " + _items.Count);

        return _items.Count <= maxItems-1;
    }

    public void AddItemToList(FoodItem item)
    {
        //if(item.GetFoodType() == FoodItem.FoodType.Carrot)
        _items.Add(item);

        RecipeObject tempRecipe = null;

        if (_items.Count >= 3)
            if(_recipeList.Count > 0)
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


        return (_items[0].GetFoodType() == recipeIn.ingredient0 && _items[1].GetFoodType() == recipeIn.ingredient1 && _items[2].GetFoodType() == recipeIn.ingredient2);
        
    }

    public void RecipeCook(RecipeObject recipeIn)
    {
        //temp store
        GameObject ingredient0 = _items[0].gameObject;
        GameObject ingredient1 = _items[1].gameObject;
        GameObject ingredient2 = _items[2].gameObject;

        ConsumeItems(ingredient0, ingredient1, ingredient2);

        Instantiate(recipeIn.recipePrefab, this.gameObject.transform.position, Quaternion.identity);
    }


    public void RemoveItemFromList()
    {
        _items.Remove(_items[0]);
    }

    public void RemoveItemFromList(int i)
    {
        _items.Remove(_items[i]);
    }

    public void RemoveItemFromList(FoodItem item)
    {
        if (_items.Contains(item))
            _items.Remove(item);
    }

    public void ConsumeItems(GameObject ingredient0, GameObject ingredient1, GameObject ingredient2)
    {
        RemoveItemFromList(ingredient0.GetComponent<FoodItem>());
        RemoveItemFromList(ingredient1.GetComponent<FoodItem>());
        RemoveItemFromList(ingredient2.GetComponent<FoodItem>());

        Destroy(ingredient0);
        Destroy(ingredient1);
        Destroy(ingredient2);
    }
}
