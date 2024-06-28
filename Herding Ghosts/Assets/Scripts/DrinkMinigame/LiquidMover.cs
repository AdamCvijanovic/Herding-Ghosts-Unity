using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LiquidMover : MonoBehaviour
{
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) + offset;
    }
}
