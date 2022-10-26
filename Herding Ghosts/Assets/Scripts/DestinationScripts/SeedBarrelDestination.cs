using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBarrelDestination : Destination
{
    public Interactable interactable;

    public GameObject UIPanel;

    public Transform spawnPosition;


    public List<GameObject> seedbagPrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if(UIPanel == null)
            UIPanel = FindObjectOfType<CanvasManager>().seedBarrelUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateSeedBarrelUI()
    {
        FindObjectOfType<CanvasManager>().SeedBarrelActivate();
    }

    public void SpawnSeedBag(IngredientItem.IngredientType ingredientType)
    {
        Debug.Log("IngredientType: " + ingredientType);

        foreach (GameObject i in seedbagPrefabs)
        {
            if (i.GetComponent<SeedBag>().GetIngredientType() == ingredientType)
            {
                Instantiate(i, spawnPosition.transform.position, Quaternion.identity);
            }
        }
    }

}
