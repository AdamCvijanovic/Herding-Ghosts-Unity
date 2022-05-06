using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLogic : MonoBehaviour
{

    public enum State { Player, Daughter, Cauldron, Basement, Stunned };
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
    public GameObject player;
    public GameObject daughter;
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
        player = FindObjectOfType<PlayerMove>().gameObject;
        daughter = FindObjectOfType<DaughterLogic>().gameObject;

        cauldron = DestinationManager.DestinationManagerSGLTN.GetDestinationOfType(Destination.DestinationType.Cauldron).gameObject;
        basement = DestinationManager.DestinationManagerSGLTN.GetDestinationOfType(Destination.DestinationType.Basement).gameObject;
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
        distance = Vector3.Distance(transform.position, _navigator.GetDestination());
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
            case State.Stunned:
                //run particle effect + stun anim
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
            Debug.Log("Am Bamished");
            Instantiate(_banishFXPrefab, transform.position, Quaternion.identity);
            EnemyManager.EnemyManagerSGLTN.RemoveEnemy(this.GetComponent<Enemy>());
            Destroy(this.gameObject, .2f);
        }
        alive = false;

    }
}
