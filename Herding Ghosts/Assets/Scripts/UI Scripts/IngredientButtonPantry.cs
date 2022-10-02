using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientButtonPantry : MonoBehaviour
{
    public IngredientItem.IngredientType ingredientType;

    public PantryUI pantryUI;

    public string ingredientDescription;

    public Sprite ingredientSprite;

    // Start is called before the first frame update
    void Start()
    {
        pantryUI = GetComponentInParent<PantryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IngredientItem.IngredientType GetIngredientType()
    {
        return ingredientType;
    }

    public void SelectIngredient()
    {
        if(pantryUI != null)
        {
            pantryUI.SelectIngredient(this);
        }
    }

    public void SpawnIngredient()
    {
        if (pantryUI != null)
            pantryUI.SpawnIngredient(ingredientType);
    }
}
