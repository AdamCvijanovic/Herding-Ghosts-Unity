using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemPortrait : MonoBehaviour
{

    public Image itemImage;
    public CustomerManager customerManager;
    public Sprite defaultSprite;

    public GameObject ingredientFrame1;
    public GameObject ingredientFrame2;
    public GameObject ingredientFrame3;

    // Start is called before the first frame update
    void Start()
    {
        customerManager = FindObjectOfType<CustomerManager>();
        if(itemImage.sprite != null)
        {
            defaultSprite = itemImage.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCustomer()
    {
        Customer currentCustomer = customerManager.GetCurrentCustomer();
    }

    public void UpdateImage(Image image)
    {
        itemImage.sprite = image.sprite;

        ingredientFrame1.GetComponent<Image>();
    }

    public void ResetImage()
    {
        itemImage.sprite = defaultSprite;
    }
}
