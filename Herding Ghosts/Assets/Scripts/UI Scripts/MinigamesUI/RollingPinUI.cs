using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RollingPinUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 rollingPinPosition = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        rollingPinPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("START DRAG ROLLING PIN");


        //transform.SetParent(transform.root);
        //transform.SetAsLastSibling();

    }

    public void OnDrag(PointerEventData eventData)
    {
        
        rollingPinPosition.y = eventData.position.y;

        transform.position = rollingPinPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("END DRAG ROLLING PIN");
    }

}
