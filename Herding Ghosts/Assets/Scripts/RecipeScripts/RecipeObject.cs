using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Recipes")]

public class RecipeObject : ScriptableObject
{
    public IngredientItem.IngredientType ingredient0;
    public IngredientItem.IngredientType ingredient1;
    public IngredientItem.IngredientType ingredient2;

    public GameObject recipePrefab;
}
