using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBag : Item
{


    public IngredientItem.IngredientType ingredientType;

    public GameObject plantPrefab;



    public override IngredientItem.IngredientType GetIngredientType()
    {
        return ingredientType;
    }


}
