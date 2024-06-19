using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerMover : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 offset;

    public Camera camera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos;
        var rect = transform.parent.GetComponent<RectTransform>();

        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, transform.parent.GetComponent<RectTransform>().position, null, out pos);

        transform.position = new Vector2(pos.x,pos.y) + offset;
    }
}
