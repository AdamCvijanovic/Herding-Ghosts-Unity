using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObjects : MonoBehaviour
{
    public GameObject _saltlinePrefab;

    public int _spawnDistance;

    public bool _dropped;


    void Start()
    {
        _dropped = false;
    }

 
    void Update()
    {
        if(_dropped == true && this.name == "Saltshaker")
        {
            SaltSwap();
            _dropped = false;
        }
    }


    public void TheItemWasDropped()
    {
        _dropped = true;
    }


    public void SaltSwap()
    {
            // spawn salt line infront of player
            Instantiate(_saltlinePrefab, transform.position+(transform.forward*_spawnDistance), transform.rotation);
            // destroy this object
            Destroy(this.gameObject);

    }


}
