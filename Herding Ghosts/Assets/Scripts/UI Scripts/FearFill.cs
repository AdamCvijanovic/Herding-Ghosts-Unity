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
    public PlayerUI _playerUI;

    public DaughterLogic _daughter;

    // Start is called before the first frame update
    void Start()
    {
        _daughter = FindObjectOfType<DaughterLogic>();
        _playerUI = FindObjectOfType<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
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
                //_playerUI.Lose();
                break;
        }



    }
}
