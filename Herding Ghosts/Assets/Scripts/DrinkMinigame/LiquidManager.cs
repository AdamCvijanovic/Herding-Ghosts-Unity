using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidManager : MonoBehaviour
{
    
    bool[] allBottles = new bool[2] { false,false};
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCompletion(int num)
    {
        allBottles[num] = true;

        if (allBottles[0] && allBottles[1])
            gameObject.SetActive(false);
    }


}
