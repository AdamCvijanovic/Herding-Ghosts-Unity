using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private InputActions _inputActions;
    [SerializeField]
    private float speed;


    // Start is called before the first frame update
    void Awake()
    {
        _inputActions = new InputActions();
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


    }

    void Move()
    {
        _inputActions.Player.Move.ReadValue<Vector2>();

        if (_inputActions.Player.Move.ReadValue<Vector2>().x < 0)
        {
            Debug.Log("Moving Left");
        }
        if (_inputActions.Player.Move.ReadValue<Vector2>().x > 0)
        {
            Debug.Log("Moving Right");
        }
        if (_inputActions.Player.Move.ReadValue<Vector2>().y < 0)
        {
            Debug.Log("Moving Down");
        }
        if (_inputActions.Player.Move.ReadValue<Vector2>().y < 0)
        {
            Debug.Log("Moving Up");
        }

        transform.position += new Vector3(_inputActions.Player.Move.ReadValue<Vector2>().x, _inputActions.Player.Move.ReadValue<Vector2>().y, 0) * speed * Time.deltaTime;



    }
}
