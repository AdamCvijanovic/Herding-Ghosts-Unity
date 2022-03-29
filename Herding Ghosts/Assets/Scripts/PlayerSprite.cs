using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField]
    private PlayerMove _playerMove;
    public SpriteRenderer _sprRnd;

    public Sprite _up;
    public Sprite _down;
    public Sprite _left;
    public Sprite _right;

    // Start is called before the first frame update
    void Start()
    {
        _sprRnd = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpriteUp()
    {
        _sprRnd.sprite = _up;
    }

    public void SpriteDown()
    {
        _sprRnd.sprite = _down;
    }

    public void SpriteLeft()
    {
        _sprRnd.sprite = _left;
    }

    public void SpriteRight()
    {
        _sprRnd.sprite = _right;
    }

    public void SpriteDirection(PlayerMove.Direction direction)
    {
        switch (direction)
        {
            case PlayerMove.Direction.Up:
                _sprRnd.sprite = _up;
                break;
            case PlayerMove.Direction.Down:
                _sprRnd.sprite = _down;
                break;
            case PlayerMove.Direction.Left:
                _sprRnd.sprite = _left;
                break;
            case PlayerMove.Direction.Right:
                _sprRnd.sprite = _right;
                break;
        }


    }


}
