using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThoughtBubble : MonoBehaviour
{
    public Image destinationImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage(GameObject destinationObj)
    {
        destinationImage.sprite = destinationObj.GetComponentInChildren<SpriteRenderer>().sprite;
    }
}
