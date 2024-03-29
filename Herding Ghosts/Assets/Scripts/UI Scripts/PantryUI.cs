using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PantryUI : MonoBehaviour
{
    public List<IngredientButtonPantry> ingredientButtons = new List<IngredientButtonPantry>();

    public IngredientButtonPantry _selectedIngredient;

    public TextMeshProUGUI itemDescriptionText;

    public Image itemDisplayImage;

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

    public void SelectIngredient(IngredientButtonPantry ingredientbutton)
    {
        _selectedIngredient = ingredientbutton;
        itemDisplayImage.sprite = ingredientbutton.ingredientSprite;
        itemDescriptionText.text = ingredientbutton.ingredientDescription;
    }

    public void SpawnIngredient(IngredientItem.IngredientType ingredient)
    {
        pantry.SpawnIngredient(ingredient);
    }

    public void TakeButton()
    {
        if(_selectedIngredient != null)
        {
            SpawnIngredient(_selectedIngredient.ingredientType);
            Deactivate();
        }
        
    }

    public void Activate()
    {

    }

    public void Deactivate()
    {
        FindObjectOfType<CanvasManager>().PantryDeactivate();
    }
}
