using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField]
    private Transform _Player;

    public float offset = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Player != null)
        {
            if (_Player.position.y >= transform.position.y + offset)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 7;

            }

            else
            {
                GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
        }
    }
}
