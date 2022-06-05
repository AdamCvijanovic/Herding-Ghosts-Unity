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

    public ThoughtBubble _thoughtBubble;

    public GameObject _currentDestination;
    public ParticleSystem _particles;



    public float _distance;
    public float _minDist;

    [Header("Destinations")]
    public GameObject _cauldron;
    public GameObject _barrel;
    public GameObject _basement;
    public GameObject _oven;
    public GameObject _fridge;


    public float _maxFear = 100f;

    [Range(0, 100)]
    public float _fearValue;
    public float _fearPercentage;

    public int _tasksCompleted;
    public int _numTasksToComplete;

    public GameObject _controlUI;

    public float _stunTime;
    public float _graceTime;
    public bool _invulnerable;


    // Start is called before the first frame update
    void Start()
    {
        _navigator = GetComponent<AINavigation>();
        _anim = GetComponent<Animator>();


        //DEstinaation Fill
        if (_oven == null)
            FindObjectOfType<DestinationManager>().GetDestinationOfType(Destination.DestinationType.Oven);
        if (_fridge == null)
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
            _tasksCompleted++;
            //This is terrible, Ideally use a Game Manager to handle this fetching nonsense
            FindObjectOfType<PlayerUI>().UpdateWinText(this);

            if(_tasksCompleted == _numTasksToComplete)
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
        
        _distance = Vector3.Distance(transform.position, _currentDestination.transform.position);
        if (Vector3.Distance(transform.position, _currentDestination.transform.position) < _minDist)
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
            _navigator.SetDestination(_currentDestination.transform);
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

        _navigator.SetDestination(_currentDestination.transform);
        if(_currentDestination != null)
            _thoughtBubble.ChangeImage(_currentDestination);
    }

    public void IncreaseFear()
    {
        if(!_invulnerable)
        {
            _invulnerable = true;
            if(currentState != State.Stunned)
            {
                _fearValue += 1;

                //RunState(State.Stunned);
                Stun();
                //Death Check
                if (_fearValue >= 100)
                {
                    FindObjectOfType<PlayerUI>().Lose();
                }
            }
        }
        
    }

    private void SwapInvulnerability()
    {
        _invulnerable = !_invulnerable;
    }

    private void Stun()
    {
        //SwapInvulnerability();
        _navigator.StopNavigation();
        _particles.Play();
        Invoke("StunTimer", _stunTime);
        Invoke("SwapInvulnerability", _graceTime);
    }

    private void StunTimer()
    {
        _navigator.StartNavigation();
        _particles.Pause();
        //ChangeState();
        //SwapInvulnerability();


    }

    private void FindCauldron()
    {
        _currentDestination = _cauldron;
    }

    private void FindBarrel()
    {
        _currentDestination = _barrel;
    }

    private void FindBasement()
    {
        _currentDestination = _basement;
    }

    private void FindOven()
    {
        if(_oven == null)
            FindObjectOfType<DestinationManager>().GetDestinationOfType(Destination.DestinationType.Oven);


        _currentDestination = _oven;


    }

    private void FindFridge()
    {
        if (_fridge == null)
            FindObjectOfType<DestinationManager>().GetDestinationOfType(Destination.DestinationType.Fridge);


        _currentDestination = _fridge;
    }

    public float FearPercentage()
    {
        _fearPercentage = _fearValue / _maxFear;
        return (_fearPercentage);
    }
}
