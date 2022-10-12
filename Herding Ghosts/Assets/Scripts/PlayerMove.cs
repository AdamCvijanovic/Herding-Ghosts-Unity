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

    //publlic 

    public enum Direction { Up, Down, Left, Right, None };
    public Direction _direction = Direction.None;
    public Direction _colDir = Direction.None;
    //public Grid _grid;
    //public Tilemap _tilemap;

    public Animator _anim;


    // Start is called before the first frame update
    void Awake()
    {
        _player = GetComponent<Player>();
        _direction = Direction.None;
        _colDir = Direction.None;
        _inputActions = new InputActions();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
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
        Move();

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

        Vector2 desiredVelocity = _movementVector.normalized * _speed;

        _rb.AddForce((desiredVelocity - _rb.velocity) / _accel);

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        _colDir = Direction.None;
    }



}
