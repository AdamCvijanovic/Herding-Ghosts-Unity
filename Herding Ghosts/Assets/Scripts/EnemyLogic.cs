using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{

    public enum State { Player, Cauldron, Basement };
    public State previousState;
    public State currentState;

    public AINavigation navigator;
    public GameObject currentDestination;


    public float distance;
    public float minDist;

    [Header("Destinations")]
    public GameObject player;
    public GameObject cauldron;
    public GameObject basement;


    // Start is called before the first frame update
    void Start()
    {
        navigator = GetComponent<AINavigation>();
        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {

        if(currentState == State.Player)
        {
            navigator.SetDestination(currentDestination.transform);
        }

        if (CheckDistance())
        {
            ChangeState();
        }
    }

    private bool CheckDistance()
    {
        bool reachedDest = false;
        distance = Vector3.Distance(transform.position, currentDestination.transform.position);
        if (Vector3.Distance(transform.position, currentDestination.transform.position) < minDist)
        {
            reachedDest = true;
        }

        return reachedDest;
    }

    private void ChangeState()
    {


        int value = Random.Range(1, 3);

        //if(previousState == currentState)
        {
            switch (value)
            {
                case 0:

                    RunState(State.Player);
                    break;
                case 1:
                    //RunState(State.Cauldron);
                    break;
                case 2:
                   // RunState(State.Basement);
                    break;
            }
        }

        if (previousState == currentState)
        {
            Debug.Log("Same State");
        }



        navigator.SetDestination(currentDestination.transform);


    }

    private void RunState(State state)
    {

        previousState = currentState;
        currentState = state;

        switch (currentState)
        {
            case State.Player:
                FindPlayer();
                break;
            case State.Cauldron:
                FindCauldron();
                break;
            case State.Basement:
                FindBasement();
                break;
        }

        navigator.SetDestination(currentDestination.transform);
    }

    private void FindPlayer()
    {
        currentDestination = player;
    }

    private void FindCauldron()
    {
        currentDestination = cauldron;
    }

    private void FindBasement()
    {
        currentDestination = basement;
    }

}
