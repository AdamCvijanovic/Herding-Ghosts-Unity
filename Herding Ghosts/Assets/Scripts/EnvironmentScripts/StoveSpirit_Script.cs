using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveSpirit_Script : MonoBehaviour
{
    private Animator _animator;
    

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        SetInteractTrue();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInteractTrue()
    {
        _animator.SetBool("isInteracted", true);

    }
     public void SetInteractFalse()
    {
        _animator.SetBool("isInteracted", false);

    }
}
