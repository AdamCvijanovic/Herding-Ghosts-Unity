using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterBox : MonoBehaviour
{
    public GameObject plantObj;
    public PlantTimer plantTimer;
    public Transform plantHolder;
    public BoxCollider2D boxCollider;

    public SeedBag seedBag;

    public Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(plantObj != null)
        {
            interactable.UnHighlight();
            interactable.enabled = false;
            boxCollider.enabled = false;
        }
        else
        {
            interactable.enabled = true;
            boxCollider.enabled = true;
        }

    }

    public void OnInteract()
    {
        if(plantObj == null)
        {
            if (IsPlayerHoldingItem())
            {
                Debug.Log("I AM HOLDING ITEM");

                if (CheckIfHoldingSeeds())
                {
                    plantObj = Instantiate(seedBag.plantPrefab, plantHolder.transform);
                    plantObj.transform.position = plantHolder.transform.position;
                    plantTimer = plantObj.GetComponent<PlantTimer>();
                    plantTimer.parentPlanter = this;
                    
                    Debug.Log("I AM HOLDING SEEDS");

                    //interactable.enabled = false;
                    FindObjectOfType<PlayerPickup>().Drop();
                    Destroy(seedBag.gameObject);
                }
            }
        }
    }

    public void DestroySeedBag()
    {
        
    }

    public bool IsPlayerHoldingItem()
    {

        return FindObjectOfType<Player>().playerPickup._isHolding;
    }

    public bool CheckIfHoldingSeeds()
    {

        bool isHolding = false;

        if (FindObjectOfType<PlayerPickup>()._currentItem.GetType() == typeof(SeedBag))
        {
            seedBag = (SeedBag)FindObjectOfType<PlayerPickup>()._currentItem;
            isHolding = true;
        }

        return isHolding;

    }


}
