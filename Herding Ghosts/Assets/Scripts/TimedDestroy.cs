using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{

    public float timer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
