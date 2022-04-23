using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaughterLogic : MonoBehaviour
{
    public enum State {Cooking, Ingredients, Deliverying };
    public State previousState;
    public State currentState;

    public AINavigation navigator;
    public GameObject currentDestination;


    public float distance;
    public float minDist;

    [Header("Destinations")]
    public GameObject cauldron;
    public GameObject barrel;
    public GameObject exit;


    [Range(0, 100)]
    public float fearValue;

    // Start is called before the first frame update
    void Start()
    {
        navigator = GetComponent<AINavigation>();
        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {


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

                    RunState(State.Cooking);
                    break;
                case 1:
                    RunState(State.Ingredients);
                    break;
                case 2:
                    RunState(State.Deliverying);
                    break;
            }
        }

        if(previousState == currentState)
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
            case State.Cooking:
                FindCauldron();
                break;
            case State.Ingredients:
                FindBarrel();
                break;
            case State.Deliverying:
                DeliverFood();
                break;
        }

        navigator.SetDestination(currentDestination.transform);
    }

    private void FindCauldron()
    {
        currentDestination = cauldron;
    }

    private void FindBarrel()
    {
        currentDestination = barrel;
    }

    private void DeliverFood()
    {
        currentDestination = exit;
    }
}
