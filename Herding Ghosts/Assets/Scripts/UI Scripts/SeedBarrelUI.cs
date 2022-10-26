using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedBarrelUI : MonoBehaviour
{
    public List<SeedButtonUI> seedBagButtons = new List<SeedButtonUI>();

    public SeedButtonUI _selectedSeedbag;

    public TextMeshProUGUI itemDescriptionText;

    public Image itemDisplayImage;

    SeedBarrelDestination seedBarrel;



    // Start is called before the first frame update
    void Start()
    {
        seedBarrel = FindObjectOfType<SeedBarrelDestination>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectIngredient(SeedButtonUI seedbutton)
    {
        _selectedSeedbag = seedbutton;
        itemDisplayImage.sprite = seedbutton.seedSprite;
        itemDescriptionText.text = seedbutton.seedDescription;
    }

    public void SpawnSeedBag(IngredientItem.IngredientType ingredient)
    {
        seedBarrel.SpawnSeedBag(ingredient);
    }

    public void TakeButton()
    {
        if (_selectedSeedbag != null)
        {
            SpawnSeedBag(_selectedSeedbag.ingredientType);
            Deactivate();
        }

    }

    public void Activate()
    {

    }

    public void Deactivate()
    {
        FindObjectOfType<CanvasManager>().SeedBarrelDeactivate();
    }
}
