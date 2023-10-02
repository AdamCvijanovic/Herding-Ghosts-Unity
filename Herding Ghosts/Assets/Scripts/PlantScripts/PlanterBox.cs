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

    //audio
    public AudioSource audioCrop1;
    public AudioSource audioCrop2;
    public AudioSource audioCrop3;
    public AudioSource audioCrop4;
    public AudioSource audioCrop5;

    private float minPitch;
    private float maxPitch;
    private int randomAudio;


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        boxCollider = GetComponent<BoxCollider2D>();
        minPitch = 0.8f;
        maxPitch = 1.2f;
        randomAudio = 1;
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
                    //play audio here
                    PlayCropAudio();
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

    //audio
    private void PlayCropAudio()
    {
        randomAudio = Random.Range(1, 5);
        switch (randomAudio)
        {
            case 1:
            audioCrop1.pitch = Random.Range(minPitch, maxPitch);
            audioCrop1.Play();
            break;

            case 2:
            audioCrop2.pitch = Random.Range(minPitch, maxPitch);
            audioCrop2.Play();
            break;

            case 3:
            audioCrop3.pitch = Random.Range(minPitch, maxPitch);
            audioCrop3.Play();
            break;

            case 4:
            audioCrop4.pitch = Random.Range(minPitch, maxPitch);
            audioCrop4.Play();
            break;

            case 5:
            audioCrop5.pitch = Random.Range(minPitch, maxPitch);
            audioCrop5.Play();
            break;
        }

    }


}
