using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerUI playerUI;
    public PlayerMove playerMove;
    public PlayerPickup playerPickup;
    //public PlayerSprite playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        if (playerUI == null)
            playerUI = FindObjectOfType<PlayerUI>();

        if (playerMove == null)
            playerMove = GetComponent<PlayerMove>();

        if (playerPickup == null)
            playerPickup = GetComponent<PlayerPickup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
