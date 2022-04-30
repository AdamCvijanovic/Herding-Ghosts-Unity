using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{

    public enum State { Daughter, Cauldron, Basement };
    public State previousState;
    public State currentState;

    [SerializeField]
    private Animator _anim;

    public AINavigation _navigator;
    public GameObject currentDestination;


    public float distance;
    public float minDist;

    [Header("Destinations")]
    public GameObject daughter;
    public GameObject cauldron;
    public GameObject basement;


    // Start is called before the first frame update
    void Awake()
    {

        _anim = GetComponent<Animator>();
        _navigator = GetComponent<AINavigation>();
        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();

        if(currentDestination == null)
        {
            ChangeState();
        }

        if (currentState == State.Daughter)
        {
            _navigator.SetDestination(currentDestination.transform);
        }

        if (CheckDistance())
        {
            ChangeState();
        }
    }


    public void Animate()
    {

        _anim.SetFloat("VelocityX", _navigator.agent.desiredVelocity.x);
        _anim.SetFloat("VelocityY", _navigator.agent.desiredVelocity.y);
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

                    RunState(State.Daughter);
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



        _navigator.SetDestination(currentDestination.transform);


    }

    private void RunState(State state)
    {

        previousState = currentState;
        currentState = state;

        switch (currentState)
        {
            case State.Daughter:
                FindPlayer();
                break;
            case State.Cauldron:
                FindCauldron();
                break;
            case State.Basement:
                FindBasement();
                break;
        }

        _navigator.SetDestination(currentDestination.transform);
    }

    private void FindPlayer()
    {
        currentDestination = daughter;
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
