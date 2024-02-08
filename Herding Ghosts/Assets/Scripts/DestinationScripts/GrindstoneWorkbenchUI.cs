using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrindstoneWorkbenchUI : MonoBehaviour
{
    public GrindstoneWorkstation _grindstoneWorksation;

    public GameObject workbenchPanel;

    public Canvas canvas;

    public DraggableGrindstone draggableGrindstone;

    public Slider grindSlider;
    public float incrementValue;

    public Button flourButton;

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

    public void SetWindowWorkstation(GrindstoneWorkstation _grindstoneWorksationIn)
    {
        _grindstoneWorksation = _grindstoneWorksationIn;
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
        _grindstoneWorksation.ProcessFood();
    }

    public void UpdateDragItem(Item item)
    {
        dragItem.image.sprite = item.sprRndr.sprite;
    }

    public void ProgressGrindSlider()
    {
        if(grindSlider.value >= grindSlider.maxValue)
        {
            FullGrindSlider();
        }
        else
        {
            grindSlider.value += (grindSlider.maxValue / incrementValue);
            DisableFlourButton();
        }

    }

    private void FullGrindSlider()
    {
        EnableFlourButton();

    }

    public void ResetGrindSlider()
    {
        grindSlider.value = 0;
    }

    public void SpawnFlourButton()
    {
        ResetGrindSlider();
        DisableFlourButton();
        _grindstoneWorksation.SpawnFlour();
    }

    public void EnableFlourButton()
    {
        flourButton.gameObject.SetActive(true);
    }

    public void DisableFlourButton()
    {
        flourButton.gameObject.SetActive(false);
    }

}

