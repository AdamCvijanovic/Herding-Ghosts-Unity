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

    public GameObject controlUI;


    public float stunTime;
    public float graceTime;
    public bool invulnerable;


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

            if(tasksCompleted == numTasksToComplete)
            {
            FindObjectOfType<PlayerUI>().Win();
            //controlUI.SetActive(false);
            }
        }

        
    }

    private void FixedUpdate()
    {


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

        State newState = new State();

       
        switch (value)
        {
            case 0:
                newState = State.Cooking;
                break;
            case 1:
                newState = State.Ingredients;
                break;
            case 2:
                newState = State.Deliverying;
                break;
            case 3:
                newState = State.Oven;
                break;
            case 4:
                newState = State.Fridge;
                break;

        }
        

        if(newState == currentState)
        {
            Debug.Log("Same State");
            //Best be careful with recursive functions
            ChangeState();
        }
        else
        {
            RunState(newState);
            _navigator.SetDestination(currentDestination.transform);
        }
    }

    private void RunState(State state)
    {
        if(state != State.Stunned)
        {
            previousState = currentState;
        }
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
        if(!invulnerable)
        {
            invulnerable = true;
            if(currentState != State.Stunned)
            {
                fearValue += 1;

                //RunState(State.Stunned);
                Stun();
                //Death Check
                if (fearValue >= 100)
                {
                    FindObjectOfType<PlayerUI>().Lose();
                }
            }
        }
        
    }

    private void SwapInvulnerability()
    {
        invulnerable = !invulnerable;
    }

    private void Stun()
    {
        //SwapInvulnerability();
        _navigator.StopNavigation();
        Invoke("StunTimer", stunTime);
        Invoke("SwapInvulnerability", graceTime);
    }

    private void StunTimer()
    {
        _navigator.StartNavigation();
        
        //ChangeState();
        //SwapInvulnerability();


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
