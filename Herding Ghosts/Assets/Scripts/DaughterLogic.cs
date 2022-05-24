using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaughterLogic : MonoBehaviour
{
    public enum State {Cooking, Ingredients, Deliverying, Oven, Fridge, Stunned};
    public State previousState;
    public State currentState;

    [SerializeField]
    private Animator _anim;
    public AINavigation _navigator;

    public ThoughtBubble thoughtBubble;

    public GameObject currentDestination;


    public float distance;
    public float minDist;

    [Header("Destinations")]
    public GameObject cauldron;
    public GameObject barrel;
    public GameObject basement;
    public GameObject oven;
    public GameObject fridge;


    public float maxFear = 100f;

    [Range(0, 100)]
    public float fearValue;
    public float fearPercentage;

    public int tasksCompleted;
    public int numTasksToComplete;


    private float stunTimer;
    private float stunTime;


    // Start is called before the first frame update
    void Start()
    {
        _navigator = GetComponent<AINavigation>();
        _anim = GetComponent<Animator>();


        //DEstinaation Fill
        if (oven == null)
            FindObjectOfType<DestinationManager>().GetDestinationOfType(Destination.DestinationType.Oven);
        if (fridge == null)
            FindObjectOfType<DestinationManager>().GetDestinationOfType(Destination.DestinationType.Fridge);

        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();

        if (CheckDistance())
        {
            ChangeState();
            //Task Completion should really be it's own function or even an event
            tasksCompleted++;
            //This is terrible, Ideally use a Game Manager to handle this fetching nonsense
            FindObjectOfType<PlayerUI>().UpdateWinText(this);
        }

        if(tasksCompleted >= numTasksToComplete)
        {
            Debug.Log("Tasks Complete!");
            FindObjectOfType<PlayerUI>().Win();
        }
    }

    private void FixedUpdate()
    {

        StunTimer();

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
        

        int value = Random.Range(0, 5);

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
            case 3:
                RunState(State.Oven);
                break;
            case 4:
                RunState(State.Fridge);
                break;

        }

        if(previousState == currentState)
        {
            Debug.Log("Same State");
            //Best be careful with recursive functions
            ChangeState();
        }



        _navigator.SetDestination(currentDestination.transform);


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
                FindBasement();
                break;
            case State.Oven:
                FindOven();
                break;
            case State.Fridge:
                FindFridge();
                break;
            case State.Stunned:
                Stun();
                break;
        }

        _navigator.SetDestination(currentDestination.transform);
        if(currentDestination != null)
            thoughtBubble.ChangeImage(currentDestination);
    }

    public void IncreaseFear()
    {
        if(currentState != State.Stunned)
        {
            Debug.Log("I am scared");
            fearValue += 1;

            RunState(State.Stunned);

            //Death Check
            if (fearValue >= 100)
            {
                Debug.Log("Fear Too High!");

                FindObjectOfType<PlayerUI>().Lose();
            }
        }

        
    }

    private void Stun()
    {
        StunTimer();
    }

    private void StunTimer()
    {

    }

    private void FindCauldron()
    {
        currentDestination = cauldron;
    }

    private void FindBarrel()
    {
        currentDestination = barrel;
    }

    private void FindBasement()
    {
        currentDestination = basement;
    }

    private void FindOven()
    {
        if(oven == null)
            FindObjectOfType<DestinationManager>().GetDestinationOfType(Destination.DestinationType.Oven);


        currentDestination = oven;


    }

    private void FindFridge()
    {
        if (fridge == null)
            FindObjectOfType<DestinationManager>().GetDestinationOfType(Destination.DestinationType.Fridge);


        currentDestination = fridge;
    }

    public float FearPercentage()
    {
        fearPercentage = fearValue / maxFear;
        return (fearPercentage);
    }
}
