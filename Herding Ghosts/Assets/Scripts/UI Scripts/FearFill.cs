using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearFill : MonoBehaviour
{

    public Image _fearFill;
    public GameObject _fear;

    public Image portrait;

    public Sprite portrait1;
    public Sprite portrait2;
    public Sprite portrait3;
    public GameObject _loseMenu;
    public GameObject _UIBaseElements;
    public GameObject _controlUI;

    public DaughterLogic _daughter;

    // Start is called before the first frame update
    void Start()
    {
        _daughter = FindObjectOfType<DaughterLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_daughter != null)
            UpdateFill();
    }

    void UpdateFill()
    {
        _fearFill.fillAmount = 1-_daughter.FearPercentage();

        switch (_daughter.FearPercentage())
        {
            case <= 0.4f:
                portrait.sprite = portrait1;
                break;
            case >0.4f and <= 0.75f:
                portrait.sprite = portrait2;
                break;
            case >0.75f and <= 1f:
                portrait.sprite = portrait3;
                break;
            case >= 1.0f:
                //_UIBaseElements.SetActive(true);
                //_loseMenu.SetActive(true);
                //_controlUI.SetActive(false);
                //Time.timeScale = 0f;
                break;
        }



    }
}
