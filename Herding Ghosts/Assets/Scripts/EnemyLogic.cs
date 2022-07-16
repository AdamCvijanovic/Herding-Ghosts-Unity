using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLogic : MonoBehaviour
{
    //ManagerFetch
    private DestinationManager _destMngr;
    private EnemyManager _enemyMngr;

    //EnemyParent
    private Enemy _enemy;

    public enum State {Daughter, Oven, Cauldron, Basement, Stunned, Possess, Steal };
    public State previousState;
    public State currentState;

    [SerializeField]
    private Animator _anim;


    [Header("Navigation Settings")]
    public AINavigation _navigator;
    public GameObject currentDestination;


    public float distance;
    public float minDist;

    [Header("Destinations")]
    public GameObject daughter;
    public GameObject oven;
    public GameObject cauldron;
    public GameObject basement;

    [Header("Health")]
    public float _maxHealth;
    [Range(0, 100)]
    public float _currhealth;
    public bool alive;


    [Header("Stats")]
    public float _stunTime;

    [Header("Prefabs")]
    public GameObject _banishFXPrefab;



    //private void Awake()
    //{
    //    _anim = GetComponent<Animator>();
    //    _navigator = GetComponent<AINavigation>();
    //    FetchDestinations();
    //    //ChangeState();
    //}

    // Start is called before the first frame update
    void Start()
    {
        _destMngr = FindObjectOfType<DestinationManager>();
        _enemyMngr = FindObjectOfType<EnemyManager>();

        _enemy = GetComponent<Enemy>();

        _anim = GetComponent<Animator>();
        _navigator = GetComponent<AINavigation>();
        FetchDestinations();
        ChangeState();

        
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        StateMachine();

    }


    public void FetchDestinations()
    {
        //fetch Daughter
        //if(FindObjectOfType<DaughterLogic>().gameObject != null)
        //    daughter = FindObjectOfType<DaughterLogic>().gameObject;


        //Fetch Destinations
        if(_destMngr.GetDestinations() != null)
        {
            oven = _destMngr.GetDestinationOfType(Destination.DestinationType.Oven).gameObject;
            cauldron = _destMngr.GetDestinationOfType(Destination.DestinationType.Cauldron).gameObject;
            basement = _destMngr.GetDestinationOfType(Destination.DestinationType.Basement).gameObject;
        }
    }


    //This needs to be improved
    public void StateMachine()
    {

        if (currentDestination == null)
        {
            ChangeState();
        }

        if (currentState == State.Daughter || currentState == State.Steal)
        {
            _navigator.SetDestination(currentDestination.transform);
        }

        //Move this into it's own section We need a complete state check elsewhere
        if (CheckDistance())
        {
            if (currentState == State.Daughter)
            {
                currentDestination.GetComponent<DaughterLogic>().IncreaseFear();
                BanishGhost();
            }

            if(currentState == State.Steal)
            {
                PickupItem();
            }

            if (currentState == State.Cauldron && distance <= minDist)
            {
                if (_enemy.GetEnemyPickup()._isHolding && _enemy.GetEnemyPickup().nearCauldron)
                {
                    _enemy.GetEnemyPickup().Drop();
                    ChangeState();
                }
            }

            //this is awful change it, just asking fo problems

            if (currentState != State.Steal || currentState != State.Cauldron)
            {
                ChangeState();
            }
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
        distance = Vector3.Distance(transform.position, _navigator.GetDestination());
        if (Vector3.Distance(transform.position, currentDestination.transform.position) < minDist)
        {
            reachedDest = true;
        }

        return reachedDest;
    }

    private void ChangeState()
    {


        int value = Random.Range(0, 4);


        //if(previousState == currentState)
        {
            switch (value)
            {
                case 0:
                    RunState(State.Steal);
                    break;
                case 1:
                    RunState(State.Possess);
                    break;
                case 2:
                    RunState(State.Steal);
                    break;
                case 3:
                   RunState(State.Steal);
                    break;
            }
        }

        if (previousState == currentState)
        {
            //Debug.Log("Same State");
        }


        //RunState(State.Daughter);

        //_navigator.SetDestination(currentDestination.transform);

        if (_enemy.GetEnemyPickup()._isHolding)
        {
            RunState(State.Cauldron);
        }

    }

    private void RunState(State state)
    {

        currentState = state;

        switch (currentState)
        {
            case State.Daughter:
                //FindDaughter();
                ChangeState();
                break;
            case State.Oven:
                FindOven();
                break;
            case State.Cauldron:
                FindCauldron();
                break;
            case State.Basement:
                FindBasement();
                break;
            case State.Possess:
                PossessDestination();
                break;
            case State.Steal:
                FindItemToSteal();
                break;
            case State.Stunned:
                //run particle effect + stun anim
                break;
        }

        _navigator.SetDestination(currentDestination.transform);
    }

    public void PossessDestination()
    {
        FindOven();
        _navigator.SetDestination(currentDestination.transform);
    }

    public void FindItemToSteal()
    {
        


        FoodItem[] allFoods = FindObjectsOfType<FoodItem>();
        List<FoodItem> availableItems = new List<FoodItem>();

        foreach( FoodItem f in allFoods)
        {
            if (!f._inCauldron || !f._isHeld)
            {
                availableItems.Add(f);
            }
            else
            {
                ChangeState();
            }
        }

        currentDestination = availableItems[Random.Range(0, availableItems.Count)].gameObject;


        //if (!foodObject.GetComponent<FoodItem>()._inCauldron)
        //{
        //    currentDestination = foodObject;
        //}
        //else
        //{
        //    ChangeState();
        //}

    }

    public void PickupItem()
    {
        if(currentDestination.GetComponent<FoodItem>()._inCauldron)
        {
            ChangeState();
            return;
        }

        if (_enemy.GetEnemyPickup()._currentItem == null)
        {
            if (!currentDestination.GetComponent<Item>()._isHeld)
                _enemy.GetEnemyPickup().PickupItem(currentDestination.GetComponent<Item>());
        }


        RunState(State.Cauldron);
    }

    private void FindDaughter()
    {
        currentDestination = daughter;
    }

    private void FindOven()
    {
        currentDestination = oven;
    }

    private void FindCauldron()
    {
        currentDestination = cauldron;
    }

    private void FindBasement()
    {
        currentDestination = basement;
    }

    private void GetStunned(BroomItem item)
    {
        //Add sound Effect & Particles
        Debug.Log("Ouch");

        currentState = State.Stunned;
        RunState(currentState);

        StartCoroutine(StunCountDown(_stunTime));

        TakeDamage(item.damage);

    }

    private IEnumerator StunCountDown(float time)
    {
        //STOP TRACKING

        //currentDestination = null;
        _navigator.StopNavigation();

        //COUNTER
        float counter = time;
        while(counter > 0)
        {
            yield return new WaitForSeconds(time);
            counter--;
        }

        ChangeState();
        _navigator.StartNavigation();

    }

    public void HitByBroom(GameObject broomObj)
    {

        BroomItem broomItem = broomObj.GetComponent<BroomItem>();

        GetStunned(broomItem);

        //m_hitByBroom.Invoke();
    }

    public void TakeDamage(float damageValue)
    {
        _currhealth -= damageValue;

        if (_currhealth <= 0)
        {
            BanishGhost();
        }
    }

    public void BanishGhost()
    {
        _currhealth = 0;
        
        if(alive == true)
        {
            Instantiate(_banishFXPrefab, transform.position, Quaternion.identity);
            _enemyMngr.RemoveEnemy(this.GetComponent<Enemy>());
            Destroy(this.gameObject, .2f);
        }
        alive = false;

    }
}
