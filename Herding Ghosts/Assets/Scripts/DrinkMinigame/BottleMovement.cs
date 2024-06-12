using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BottleMovement : MonoBehaviour
{
    bool selected = false;

    private PlayerInput playerInput;
    private InputAction rightClick;

    bool rotate = true;
    bool isTipping = false;
    public int tipAmount = 120;
    private int currentTip = 0;

    public GameObject liquid;
    public LiquidManager manager;

    public RectTransform bobaDrink;
    public RectTransform sugarDrink;

    [Range(0, 1)]
    public int drinkLayer = 0;

    public Camera camera;
    public int percentageComplete;
    public int percentagePerParticle = 50;


    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rightClick = playerInput.actions["RightClickHold"];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (selected)
        {
            MouseFollow();
        }

        if (isTipping)
            Tip(false);
    }

    public void LockToMouse()
    {
        if (!selected)
        {
            Cursor.visible = false;
            selected = true;

            rightClick.performed += TiltBottle;
            rightClick.canceled += CancelTiltBottle;
        }
        else
        {
            Cursor.visible = true;
            selected = false;
            rightClick.performed -= TiltBottle;
            rightClick.canceled -= CancelTiltBottle;
        }

    }

    public void TiltBottle(InputAction.CallbackContext context)
    {
        isTipping = true;

    }

    public void CancelTiltBottle(InputAction.CallbackContext context)
    {
        isTipping = false;
        GetComponent<RectTransform>().Rotate(new Vector3(0, 0, currentTip));
        currentTip = 0;
        liquid.SetActive(false) ;
    }

    private void MouseFollow()
    {

        Vector2 mousePosition;
        var rect = transform.parent.GetComponent<RectTransform>();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Mouse.current.position.ReadValue(), camera, out mousePosition);

        GetComponent<RectTransform>().anchoredPosition = mousePosition;


    }
    public void Tip(bool fromDrink)
    {
        if (percentageComplete <= percentagePerParticle)
        {
            if (currentTip <= tipAmount)
            {
                rotate = false;
                GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -6));
                currentTip += 6;
            }

            else
            {
                liquid.SetActive(true);

                if (fromDrink)
                {

                    percentageComplete++;
                    switch (drinkLayer)
                    {
                        case 0:
                            bobaDrink.anchoredPosition = new Vector2(bobaDrink.anchoredPosition.x, bobaDrink.anchoredPosition.y + 4f);
                            break;
                        case 1:
                            sugarDrink.anchoredPosition = new Vector2(sugarDrink.anchoredPosition.x, sugarDrink.anchoredPosition.y + 0.1f);
                            bobaDrink.anchoredPosition = new Vector2(bobaDrink.anchoredPosition.x, bobaDrink.anchoredPosition.y + 0.1f);

                            break;

                    }



                }
            }


        }

        else
        {
            liquid.SetActive(false);
            manager.UpdateCompletion(drinkLayer);

        }
    }






}
