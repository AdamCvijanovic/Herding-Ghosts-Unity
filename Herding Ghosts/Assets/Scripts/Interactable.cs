using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{


    //Interaction system
    public SpriteRenderer sprRndr;

    public Material defaultMaterial;
    public Material highlightMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Interaction Systems
    public void Highlight()
    {
        if (highlightMaterial != null)
            sprRndr.material = highlightMaterial;
    }

    public void UnHighlight()
    {
        if (defaultMaterial != null)
        {
            sprRndr.material = defaultMaterial;
        }
        //if item highlighted, unhiglight

    }

}
