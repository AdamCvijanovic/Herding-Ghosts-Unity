using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronDestination : Destination
{

    public List<FoodItem> items = new List<FoodItem>();
    public RecipeObject exampleRecipe;

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

    public void AddItemToList(FoodItem item)
    {
        //if(item.GetFoodType() == FoodItem.FoodType.Carrot)
        items.Add(item);

        if (items.Count >= 3)
            RecipeCheck();
    }

    //Scan through existing recipes
    //See if items at index's 0-2 match
    //consume items
    //output prefab

    public void RecipeCheck()
    {

        Debug.Log("Recipe Check");


        if (items[0].GetFoodType() == exampleRecipe.ingredient0 && items[1].GetFoodType() == exampleRecipe.ingredient1 && items[2].GetFoodType() == exampleRecipe.ingredient2)
        {
            Instantiate(exampleRecipe.recipePrefab, this.gameObject.transform.position, Quaternion.identity);


            Debug.Log("Recipe SUCCESSS!!!!");

            //temp store
            GameObject ingredient0 = items[0].gameObject;
            GameObject ingredient1 = items[1].gameObject;
            GameObject ingredient2 = items[2].gameObject;

            RemoveItemFromList(ingredient0.GetComponent<FoodItem>());
            RemoveItemFromList(ingredient1.GetComponent<FoodItem>());
            RemoveItemFromList(ingredient2.GetComponent<FoodItem>());

            Destroy(ingredient0);
            Destroy(ingredient1);
            Destroy(ingredient2);
        }
    }


    public void RemoveItemFromList()
    {
        items.Remove(items[0]);
    }

    public void RemoveItemFromList(int i)
    {
        items.Remove(items[i]);
    }

    public void RemoveItemFromList(FoodItem item)
    {
        if (items.Contains(item))
            items.Remove(item);
    }

}
