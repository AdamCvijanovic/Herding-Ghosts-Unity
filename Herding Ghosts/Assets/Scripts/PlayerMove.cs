using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;


public class PlayerMove : MonoBehaviour
{

    //privates
    private Player _player;
    [SerializeField]
    private InputActions _inputActions;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Vector2 _movementVector = new Vector2();
    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    [Min(0.001f)]
    private float _accel;

    private float lastFrameX = 0;
    private float lastFrameY = 0;
    //publlic 

    public enum Direction { Up, Down, Left, Right, None };
    public Direction _direction = Direction.None;
    public Direction _colDir = Direction.None;
    //public Grid _grid;
    //public Tilemap _tilemap;

    public Animator _anim;

    //audio
    public AudioSource audioCuteFootsteps;
    private bool isPlayingCuteFootsteps;
    //private bool isPlayingWoodFootsteps;
    //private bool isPlayingStoneFootsteps;
    //private float minPitch;
    //private float maxPitch;
    //private bool isOnWoodFloor;

    //public AudioSource audioWoodFootsteps1;
    //public AudioSource audioWoodFootsteps2;
    //public AudioSource audioWoodFootsteps3;
    //public AudioSource audioWoodFootsteps4;

    //public AudioSource audioStoneFootsteps1;
    //public AudioSource audioStoneFootsteps2;
    //public AudioSource audioStoneFootsteps3;
    //public AudioSource audioStoneFootsteps4;

    //private int randomWoodFootstep;
    //private int randomStoneFootstep;


    // Start is called before the first frame update
    void Awake()
    {
        _player = GetComponent<Player>();
        _direction = Direction.None;
        _colDir = Direction.None;
        _inputActions = new InputActions();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        isPlayingCuteFootsteps = false;
        //isPlayingWoodFootsteps = false;
        //isPlayingStoneFootsteps = false;
        //isOnWoodFloor = true;
        //minPitch = 0.92f;
        //maxPitch = 1.08f;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (isOnWoodFloor)
        {
            Debug.Log("Am standing on wooden floor woo");
        }

        else
        {
            Debug.Log("Am no longer standing on it :(");
        }
        */
        Move();
        

        if (_inputActions.Player.Move.ReadValue<Vector2>().y < 0 || _inputActions.Player.Move.ReadValue<Vector2>().y > 0 || _inputActions.Player.Move.ReadValue<Vector2>().x < 0 || _inputActions.Player.Move.ReadValue<Vector2>().x > 0)
        {
            //audioCuteFootsteps.pitch = Random.Range(minPitch, maxPitch);
            if (!isPlayingCuteFootsteps)
            {
                audioCuteFootsteps.Play();
                isPlayingCuteFootsteps = true;
            }

            /*
            if (!isPlayingWoodFootsteps && isOnWoodFloor)
            {
                audioWoodFootsteps1.Play();
                isPlayingWoodFootsteps = true;
            }
            */
        }
        else
        {
            if (isPlayingCuteFootsteps)
            {
                audioCuteFootsteps.Stop();
                isPlayingCuteFootsteps = false;
            }
            /*

            if (isPlayingWoodFootsteps)
            {
                audioWoodFootsteps1.Stop();
                //audioWoodFootsteps2.Stop();
                //audioWoodFootsteps3.Stop();
                //audioWoodFootsteps4.Stop();
                isPlayingWoodFootsteps = false;
            }

            if (!isOnWoodFloor)
            {
                audioWoodFootsteps1.Stop();
                isPlayingWoodFootsteps = false;
            }

            if (isPlayingStoneFootsteps)
            {
                //audioStoneFootsteps1.Stop();
                //audioStoneFootsteps2.Stop();
                //audioStoneFootsteps3.Stop();
                //audioStoneFootsteps4.Stop();
                isPlayingStoneFootsteps = false;
            }
            */
        }


        //if (_inputActions.Player.Move.ReadValue<Vector2>().x == 0 && _inputActions.Player.Move.ReadValue<Vector2>().y == 0)
        //{
          //  audioFootsteps.Stop();
        //}

        if (_inputActions.Player.Move.WasPressedThisFrame())
        {
            //Vector3Int above = new Vector3Int(_grid.WorldToCell(transform.position).x, _grid.WorldToCell(transform.position).y + 1, 0);

            //if (_tilemap.GetColliderType(above) == Tile.ColliderType.Sprite)
            //{
            //    Debug.Log("ABOVE");
            //}

            //Debug.Log("KEY PRESSED" +
            //_grid.WorldToCell(transform.position).x + ", " +
            //_grid.WorldToCell(transform.position).y + ", " +
            //_tilemap.GetColliderType(above).ToString());

            //_tilemap.GetColliderType(_grid.WorldToCell(transform.position));

        }
    }

    public void PlayerInput(InputAction.CallbackContext context)
    {
        _movementVector = context.ReadValue<Vector2>();

        ////this too
        //if (_inputActions.Player.Move.ReadValue<Vector2>().y > 0)
        //{
        //    //Debug.Log("Moving Up");
        //    _direction = Direction.Up;

        //    //if (_colDir == Direction.Up)
        //    //{
        //    //    _movementVector.y = 0;
        //    //}

        //}
        //if (_inputActions.Player.Move.ReadValue<Vector2>().y < 0)
        //{
        //    //Debug.Log("Moving Down");
        //    _direction = Direction.Down;

        //    //if (_colDir == Direction.Down)
        //    //{
        //    //    _movementVector.y = 0;
        //    //}
        //}
        //if (_inputActions.Player.Move.ReadValue<Vector2>().x < 0)
        //{
        //    //Debug.Log("Moving Left");
        //    _direction = Direction.Left;

        //    //if (_colDir == Direction.Left)
        //    //{
        //    //    _movementVector.x = 0;
        //    //}
        //}
        //if (_inputActions.Player.Move.ReadValue<Vector2>().x > 0)
        //{
        //    //Debug.Log("Moving Right");
        //    _direction = Direction.Right;

        //    //if (_colDir == Direction.Right)
        //    //{
        //    //    _movementVector.x = 0;
        //    //}
        //}
    }

    void Move()
    {

        //_movementVector = _inputActions.Player.Move.ReadValue<Vector2>();


        //this too
        if (_inputActions.Player.Move.ReadValue<Vector2>().y > 0)
        {
            //Debug.Log("Moving Up");
            _direction = Direction.Up;

         

        }
        if (_inputActions.Player.Move.ReadValue<Vector2>().y < 0)
        {
            //Debug.Log("Moving Down");
            _direction = Direction.Down;

         
        }
        if (_inputActions.Player.Move.ReadValue<Vector2>().x < 0)
        {
            //Debug.Log("Moving Left");
            _direction = Direction.Left;

    
        }
        if (_inputActions.Player.Move.ReadValue<Vector2>().x > 0)
        {
            //Debug.Log("Moving Right");
            _direction = Direction.Right;

        }

        //_playerSprite.SpriteDirection(_direction);

        //Vector3Int above = new Vector3Int(_grid.WorldToCell(transform.position).x, _grid.WorldToCell(transform.position).y + 1, 0);

        //if (_tilemap.GetColliderType(above) == Tile.ColliderType.Sprite)
        //{
        //    Debug.Log("ABOVE");
        //}
        //else
        //{
        //    _rb.position += _movementVector * speed * Time.deltaTime;

        //}


        Debug.DrawLine(transform.position, (transform.position + new Vector3(_movementVector.x, _movementVector.y)));

        //_rb.position += _movementVector.normalized * _speed * Time.deltaTime;

        Vector2 desiredVelocity = _movementVector.normalized * _speed ;


        if (Mouse.current != null && Mouse.current.rightButton.isPressed || Gamepad.current != null && Gamepad.current.rightShoulder.isPressed)
        {
            
            _rb.AddForce((desiredVelocity * 3 - _rb.velocity) / _accel);
           
        }
        else
            _rb.AddForce((desiredVelocity - _rb.velocity) / _accel);

        if((_rb.velocity.x < 0.5f && _rb.velocity.x > -0.5f) && (_rb.velocity.y < 0.5f && _rb.velocity.y> -0.5f))
        {
            _rb.velocity = new Vector2(0,0);

        }




        Animate();

        //Debug.Log("Velocity magnitude " + _rb.velocity.magnitude);


    }

    public void Animate()
    {
        _anim.SetBool("Holding", _player.playerPickup._isHolding);
        _anim.SetFloat("VelocityX", _rb.velocity.x);
        _anim.SetFloat("VelocityY", _rb.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 norm = collision.GetContact(0).normal;

        Debug.DrawLine(transform.position, norm);

        if (norm.x > 0)
        {
            //Debug.Log("LEFT");
            _colDir = Direction.Left;
        }
        if (norm.x < 0)
        {
            //Debug.Log("RIGHT");
            _colDir = Direction.Right;
        }
        if (norm.y > 0)
        {
            //Debug.Log("DOWN");
            _colDir = Direction.Down;
        }
        if (norm.y < 0)
        {
            //Debug.Log("UP");
            _colDir = Direction.Up;
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WoodFloor"))
        {
            isOnWoodFloor = true;
        }
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        _colDir = Direction.None;

        if (collision.CompareTag("WoodFloor"))
        {
            isOnWoodFloor = false;
        }
    }
    */

    


}
