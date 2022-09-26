using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantryDestination : Destination
{
    public Interactable interactable;


    public GameObject UIPanel;

    public Transform spawnPosition;


    public List<IngredientItem> ingredients = new List<IngredientItem>();

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePantryUI()
    {
        FindObjectOfType<IngameMenus>().PantryActivate();
    }
}
