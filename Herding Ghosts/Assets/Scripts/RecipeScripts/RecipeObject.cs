using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Recipes")]

public class RecipeObject : ScriptableObject
{
    public FoodItem.FoodType ingredient1;
    public FoodItem.FoodType ingredient2;
    public FoodItem.FoodType ingredient3;

    public GameObject recipePrefab;
}
