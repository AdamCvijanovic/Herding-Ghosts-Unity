using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotiRat_Script : MonoBehaviour
{
    public Animator Roti_Animator; 
    public bool rotiAlone = true;
    public float rotiCounter = 5.0f;

    private float maxCount;

    // Start is called before the first frame update
    void Start()
    {
        maxCount = rotiCounter;
        Roti_Animator.Play("Roti_Wave"); //idle anim (spider in)
    }

    // Update is called once per frame
    /*void Update()
    {
        if(rotiCounter > 0 && rotiAlone == true)
        {
            rotiCounter -= Time.deltaTime;
        }
        
        if(rotiCounter <= 0 && rotiAlone == true)
        {
            Roti_Animator.Play("Roti_Wave"); // was spider exit anim
            rotiAlone = false;

        }
    }*/

     public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Roti_Animator.Play("Roti_FadeOff"); // was spider back in anim
            rotiAlone = false;
        }
    } 

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            rotiCounter = maxCount;
            rotiAlone = true;
        }
    } 

}
