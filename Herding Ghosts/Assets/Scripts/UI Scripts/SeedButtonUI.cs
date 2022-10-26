using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedButtonUI : MonoBehaviour
{
    public IngredientItem.IngredientType ingredientType;

    public SeedBarrelUI seedBarrelUI;

    public string seedDescription;

    public Sprite seedSprite;

    // Start is called before the first frame update
    void Start()
    {
        seedBarrelUI = GetComponentInParent<SeedBarrelUI>();
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
        if (seedBarrelUI != null)
        {
            seedBarrelUI.SelectIngredient(this);
        }
    }

    public void SpawnIngredient()
    {
        if (seedBarrelUI != null)
            seedBarrelUI.SpawnSeedBag(ingredientType);
    }
}
