using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLogic : MonoBehaviour
{

    public enum State { Player, Daughter, Cauldron, Basement, Stun };
    public State previousState;
    public State currentState;

    [SerializeField]
    private Animator _anim;

    public AINavigation _navigator;
    public GameObject currentDestination;


    public float distance;
    public float minDist;

    [Header("Destinations")]
    public GameObject player;
    public GameObject daughter;
    public GameObject cauldron;
    public GameObject basement;


    // Start is called before the first frame update
    void Start()
    {

        _anim = GetComponent<Animator>();
        _navigator = GetComponent<AINavigation>();
        ChangeState();

        
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        StateMachine();

    }


    public void StateMachine()
    {
        if (currentDestination == null)
        {
            ChangeState();
        }

        if (currentState == State.Daughter)
        {
            _navigator.SetDestination(currentDestination.transform);
        }

        if (CheckDistance())
        {
            if (currentState == State.Daughter)
            {
                //Debug.Log("Get Scared");
                currentDestination.GetComponent<DaughterLogic>().IncreaseFear();
            }

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


        int value = Random.Range(0, 3);

        //if(previousState == currentState)
        {
            switch (value)
            {
                case 0:

                    RunState(State.Player);
                    break;
                case 1:
                    RunState(State.Daughter);
                    break;
                case 2:
                    RunState(State.Cauldron);
                    break;
                case 3:
                   RunState(State.Basement);
                    break;
            }
        }

        if (previousState == currentState)
        {
            //Debug.Log("Same State");
        }



        //_navigator.SetDestination(currentDestination.transform);


    }

    private void RunState(State state)
    {

        currentState = state;

        switch (currentState)
        {
            case State.Player:
                FindPlayer();
                break;
            case State.Daughter:
                FindDaughter();
                break;
            case State.Cauldron:
                FindCauldron();
                break;
            case State.Basement:
                FindBasement();
                break;
            case State.Stun:
                StartCoroutine(StunCountDown(3));
                break;
        }

        _navigator.SetDestination(currentDestination.transform);
    }

    private void FindDaughter()
    {
        currentDestination = daughter;
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

    private void GetStunned()
    {
        //RunState(State.Stun);
        Debug.Log("Ouch");

        currentState = State.Stun;
        RunState(currentState);

        //StartCoroutine(StunCountDown(3));

    }


    private IEnumerator StunCountDown(int seconds)
    {
        //STOP TRACKING

        //currentDestination = null;
        _navigator.StopNavigation();

        //COUNTER
        int counter = seconds;
        while(counter > 0)
        {
            yield return new WaitForSeconds(seconds);
            Debug.Log("Counter = " + counter);
            counter--;
        }

        ChangeState();
        _navigator.StartNavigation();



    }



    public void HitByBroom(GameObject broomObj)
    {
        GetStunned();

        //m_hitByBroom.Invoke();


    }


  
}
