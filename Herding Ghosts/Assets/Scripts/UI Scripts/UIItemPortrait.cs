using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemPortrait : MonoBehaviour
{

    public Image itemImage;
    public CustomerManager customerManager;

    // Start is called before the first frame update
    void Start()
    {
        customerManager = FindObjectOfType<CustomerManager>();
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
    }
}
