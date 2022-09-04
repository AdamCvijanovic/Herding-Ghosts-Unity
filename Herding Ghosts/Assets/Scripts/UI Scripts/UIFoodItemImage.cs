using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFoodItemImage : MonoBehaviour
{
    [SerializeField]
    private Customer _customer;

    public Image _foodItemImage;

    //public FoodItem.FoodType foodType;

    // Start is called before the first frame update
    void Start()
    {
        _foodItemImage = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public void SelectFoodImage(FoodItem.FoodType foodtype)
    {
        CustomerManager mngr = _customer.GetCustomerManager();
        GameObject foodPrefab = mngr.FindFoodFromEnum(foodtype);

        if (foodPrefab != null)
        {
            Debug.Log("Food Sprite " + foodPrefab.GetComponent<FoodItem>().foodSprite.name);

            Debug.Log("Sprite  Field" + _foodItemImage.sprite.name);
            _foodItemImage.sprite = foodPrefab.GetComponent<FoodItem>().foodSprite;

        }
        else
        {
            Debug.Log("Food Prefab is null");
        }

        //_foodItemImage.sprite = _customer.GetCustomerManager().FindFoodFromEnum(foodtype).GetComponentInChildren<SpriteRenderer>().sprite;
    }

    public void EnableImage()
    {
        _foodItemImage.gameObject.SetActive(true);
    }

    public void DisableImage()
    {
        _foodItemImage.gameObject.SetActive(false);
    }

    public void UpdateTextUse(string text)
    {

    }
}
