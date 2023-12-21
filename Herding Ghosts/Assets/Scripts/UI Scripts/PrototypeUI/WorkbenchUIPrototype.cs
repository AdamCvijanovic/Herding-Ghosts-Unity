using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorkbenchUIPrototype : MonoBehaviour
{
    public GameObject workbenchPanel;

    public Canvas canvas;

    public DraggableItem dragItem;

    public Sprite cookedIngredientSprite;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePanel()
    {
        workbenchPanel.SetActive(true);
    }

    public void DeActivatePanel()
    {
        workbenchPanel.SetActive(false);
    }

    public void ActivateButton()
    {
        dragItem.GetComponent<Image>().sprite = cookedIngredientSprite;
    }

}
