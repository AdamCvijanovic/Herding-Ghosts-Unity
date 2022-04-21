using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLogic : MonoBehaviour
{

    enum State { Searching, Cooking, Deliverying };
    State currentState;

    public AINavigation navigator;
    public GameObject currentDestination;

    public GameObject player;

    public float minDist;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().gameObject;
        navigator = GetComponent<AINavigation>();
        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeState()
    {
        
        currentDestination = player;


        navigator.SetDestination(currentDestination.transform);

    }
}
