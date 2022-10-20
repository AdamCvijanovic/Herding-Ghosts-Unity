using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Script : MonoBehaviour
{
    public Animator spideranim; 
    public bool spiderAlone = true;
    public float spiderCounter = 5.0f;

    private float maxCount;

    // Start is called before the first frame update
    void Start()
    {
        maxCount = spiderCounter;
        spideranim.Play("Spider_In");
    }

    // Update is called once per frame
    void Update()
    {
        if(spiderCounter > 0 && spiderAlone == true)
        {
            spiderCounter -= Time.deltaTime;
        }
        
        if(spiderCounter <= 0 && spiderAlone == true)
        {
            spideranim.Play("Spider_Exit");
            spiderAlone = false;

        }
    }

     public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            spideranim.Play("Spider_BackIn");
            spiderAlone = false;
        }
    } 

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            spiderCounter = maxCount;
            spiderAlone = true;
        }
    } 

}
