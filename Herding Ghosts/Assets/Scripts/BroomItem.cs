using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomItem : Item
{

    [SerializeField]
    private Animator _anim;

    public PlayerMove playerMoveScript;

    public PolygonCollider2D swingCollider;

    public float pushForce;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPlayerDir()
    {
        playerMoveScript = parentObj.GetComponent<PlayerMove>();

        if(playerMoveScript._direction == PlayerMove.Direction.Up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (playerMoveScript._direction == PlayerMove.Direction.Down)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (playerMoveScript._direction == PlayerMove.Direction.Left)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (playerMoveScript._direction == PlayerMove.Direction.Right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }


    public override void Activate()
    {

        CheckPlayerDir();

        _anim.SetTrigger("Swing");
        Debug.Log("Swing");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(parentObj != null)
        {
            if (collision.gameObject.GetComponent<EnemyLogic>())
            {
                Debug.Log("Player hit " + collision.gameObject.name);
                collision.gameObject.GetComponent<EnemyLogic>().HitByBroom(this.gameObject);
                PushObject(collision.gameObject);
            }
        }
    }

        

    private void PushObject(GameObject broomObj)
    {

        Vector2 dir = (transform.position - broomObj.transform.position).normalized;

        broomObj.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.right * pushForce), ForceMode2D.Force);
    }

}
