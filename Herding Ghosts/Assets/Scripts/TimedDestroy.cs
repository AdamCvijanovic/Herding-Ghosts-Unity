using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltTile : MonoBehaviour
{

    public float timer = 10.0f;

    public SaltItem saltItem;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Timer()
    {

    }
}
