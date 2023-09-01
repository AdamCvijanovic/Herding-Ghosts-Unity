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

    //audio
    public AudioSource audioBroom;
    private float minPitch;
    private float maxPitch;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        
        minPitch = 0.7f;
        maxPitch = 1.05f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHeldAnim();
        
    }

    public void UpdateHeldAnim()
    {
        if (_isHeld)
        {
            //_anim.SetBool("Held",true);
        }
        else
        {
            //_anim.SetBool("Held", false);
        }
    }

    public void CheckPlayerDir()
    {
        //We can check playerMove script on pickup, and here can be a null check instead
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

        audioBroom.pitch = Random.Range(minPitch, maxPitch);
        audioBroom.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(parentObj != null)
        {
            if (collision.gameObject.GetComponent<GhibliGhost>())
            {
                Debug.Log("Player hit " + collision.gameObject.name);
                collision.gameObject.GetComponent<GhibliGhost>().HitByBroom(this.gameObject);
                PushObject(collision.gameObject);
            }

            if (collision.gameObject.GetComponent<GhostLogic>())
            {
                Debug.Log("Player hit " + collision.gameObject.name);
                collision.gameObject.GetComponent<GhostLogic>().HitByBroom(this.gameObject);
                PushObject(collision.gameObject);
            }
        }
    }

        

    private void PushObject(GameObject broomObj)
    {

        Vector2 dir = (broomObj.transform.position - transform.position).normalized;

        broomObj.gameObject.GetComponent<Rigidbody2D>().AddForce((dir * pushForce), ForceMode2D.Force);
    }

}
