using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomItem : MonoBehaviour
{

    [SerializeField]
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        _anim.SetTrigger("Swing");
    }
}
