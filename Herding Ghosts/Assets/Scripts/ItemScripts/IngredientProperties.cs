using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientProperties : MonoBehaviour
{
    public enum IngredientGroup {Base, Meat, Veggie, Fruit, Spice, Drink };
    [SerializeField]
    public IngredientGroup ingredientGroup;

    public List<IngredientGroup> ingrdntPropertiesList = new List<IngredientGroup>();


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

    public List<IngredientGroup> GetListIngredientGroup()
    {
        return ingrdntPropertiesList;
    }

    public void propertyCombiner()
    {

    }


}

public class FoodProduct
{


}
