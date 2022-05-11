using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltItem : Item
{
    public GameObject _saltlinePrefab;

    public int _spawnDistance;

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
        Instantiate(_saltlinePrefab, transform.position + (transform.forward * _spawnDistance), transform.rotation);

        //call navmesh singleton (Need to update navmesh but i dno why it doesn't work)
        FindObjectOfType<NavMeshManager>().UpdateNavMesh();
        // destroy this object
        Destroy(this.gameObject);

    }

}
