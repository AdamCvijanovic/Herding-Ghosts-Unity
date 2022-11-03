using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhibliGhost : MonoBehaviour
{
    
    [Header("Health")]
    public float _maxHealth;
    [Range(0, 100)]
    public float _currhealth;
    public bool alive;

    [Header("Stats")]
    public float _stunTime;

    [Header("Prefabs")]
    public GameObject _banishFXPrefab;
    public GameObject _ectoplasmPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void HitByBroom(GameObject broomObj)
    {

        BroomItem broomItem = broomObj.GetComponent<BroomItem>();

        GetStunned(broomItem);

        //m_hitByBroom.Invoke();
    }

    private void GetStunned(BroomItem item)
    {
        //Add sound Effect & Particles
        Debug.Log("Ouch");

        //currentState = State.Stunned;
        //RunState(currentState);

        //StartCoroutine(StunCountDown(_stunTime));

        TakeDamage(item.damage);

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
            Instantiate(_ectoplasmPrefab, transform.position, Quarternion.identity);
            //_ghostMngr.RemoveGhost(this.GetComponent<Ghost>());
            Destroy(this.gameObject, .2f);
        }
        alive = false;

    }
}
