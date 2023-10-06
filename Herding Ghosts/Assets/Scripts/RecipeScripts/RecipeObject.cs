using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Recipes")]

public class RecipeObject : ScriptableObject
{
    public IngredientItem.IngredientType[] ingredient = new IngredientItem.IngredientType[3];


    public GameObject recipePrefab;
}
