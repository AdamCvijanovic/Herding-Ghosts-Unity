using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;


public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private InputActions _inputActions;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 _movementVector = new Vector2();
    [SerializeField]
    private Rigidbody2D _rb;

    public Grid _grid;
    public Tilemap _tilemap;


    // Start is called before the first frame update
    void Awake()
    {
        _inputActions = new InputActions();
        _rb = GetComponent<Rigidbody2D>();
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
    void Update()
    {
        Move();

        if (_inputActions.Player.Move.WasPressedThisFrame())
        {
            Vector3Int above = new Vector3Int(_grid.WorldToCell(transform.position).x, _grid.WorldToCell(transform.position).y + 1, 0);

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

    void Move()
    {
        _movementVector = _inputActions.Player.Move.ReadValue<Vector2>();

        if (_inputActions.Player.Move.ReadValue<Vector2>().x < 0)
        {
            //Debug.Log("Moving Left");
        }
        if (_inputActions.Player.Move.ReadValue<Vector2>().x > 0)
        {
            //Debug.Log("Moving Right");
        }
        if (_inputActions.Player.Move.ReadValue<Vector2>().y < 0)
        {
            //Debug.Log("Moving Down");
        }
        if (_inputActions.Player.Move.ReadValue<Vector2>().y < 0)
        {
            //Debug.Log("Moving Up");
        }

        Vector3Int above = new Vector3Int(_grid.WorldToCell(transform.position).x, _grid.WorldToCell(transform.position).y + 1, 0);

        //if (_tilemap.GetColliderType(above) == Tile.ColliderType.Sprite)
        //{
        //    Debug.Log("ABOVE");
        //}
        //else
        //{
        //    _rb.position += _movementVector * speed * Time.deltaTime;

        //}
        _rb.position += _movementVector * speed * Time.deltaTime;

        Debug.Log("THIS IS A TEST FOR THE GIT");



    }

    private void FaceDirection()
    {

    }


}
