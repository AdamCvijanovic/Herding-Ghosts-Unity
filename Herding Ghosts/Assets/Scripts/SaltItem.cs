using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltItem : Item
{
    public GameObject _saltlinePrefab;
    public GameObject _saltTileGO;

    public SpriteRenderer saltItemSprite;

    public int _spawnDistance;

    public float barrierTime;

    //public bool _dropped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {

        parentObj.GetComponent<PlayerPickup>().Drop();
        SaltSwap();

    }
    public void SaltSwap()
    {
        // spawn salt line infront of player
        //Instantiate(_saltlinePrefab, transform.position + (transform.forward * _spawnDistance), transform.rotation);

        _saltTileGO.SetActive(true);

        //call navmesh singleton (Need to update navmesh but i dno why it doesn't work)
        FindObjectOfType<NavMeshManager>().UpdateNavMesh();


        DisableSaltItem();
        Invoke("RenableSaltItem", barrierTime);

        // destroy this object
        //Destroy(this.gameObject);

    }

    public void DisableSaltItem()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        saltItemSprite.enabled = false;
    }

    public void RenableSaltItem()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        saltItemSprite.enabled = true;
        _saltTileGO.SetActive(false);

    }

}
