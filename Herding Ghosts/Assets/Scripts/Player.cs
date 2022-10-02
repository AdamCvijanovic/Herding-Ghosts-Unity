using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerMove playerMove;
    public PlayerPickup playerPickup;
    //public PlayerSprite playerSprite;

    public CauldronDestination nearCauldron;
    public Inventory nearInventory;

    //Worldspace/Local UI Element controllers
    public TutorialText helpText;

    // Start is called before the first frame update
    void Start()
    {
        if (playerMove == null)
            playerMove = GetComponent<PlayerMove>();

        if (playerPickup == null)
            playerPickup = GetComponent<PlayerPickup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Destination>())
        {
            Destination.DestinationType colType = collision.gameObject.GetComponent<Destination>().GetDestinationType();
            if (colType == Destination.DestinationType.Cauldron)
            {
                //in retrospect we could have just checked for cauldron destination
                nearCauldron = collision.gameObject.GetComponent<CauldronDestination>();
                nearInventory = collision.gameObject.GetComponent<Inventory>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (nearCauldron != null)
        {
            nearCauldron = null;
        }

        if (nearInventory != null)
        {
            nearInventory = null;
        }
    }


}
