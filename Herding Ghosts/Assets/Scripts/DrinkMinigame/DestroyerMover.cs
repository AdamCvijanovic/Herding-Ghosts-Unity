using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerMover : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(transform.parent.GetComponent<RectTransform>().position) + offset;
    }
}
