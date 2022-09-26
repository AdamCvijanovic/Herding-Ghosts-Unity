using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantryUI : MonoBehaviour
{
    public List<IngredientButtonPantry> ingredientButtons = new List<IngredientButtonPantry>();

    PantryDestination pantry;

    // Start is called before the first frame update
    void Start()
    {
        pantry = FindObjectOfType<PantryDestination>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnIngredient(IngredientItem.IngredientType ingredient)
    {
        pantry.SpawnIngredient(ingredient);
    }

    public void Activate()
    {

    }

    public void Deactivate()
    {
        FindObjectOfType<IngameMenus>().PantryDeactivate();
    }
}
