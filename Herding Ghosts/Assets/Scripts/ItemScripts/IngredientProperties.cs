using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientProperties : MonoBehaviour
{
    public enum IngredientGroup {Base, Meat, Veggie, Spice, Drink };
    [SerializeField]
    public IngredientGroup ingredientGroup;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IngredientGroup GetIngredientGroup()
    {
        return ingredientGroup;
    }

    public void propertyCombiner()
    {

    }


}

public class FoodProduct
{


}
