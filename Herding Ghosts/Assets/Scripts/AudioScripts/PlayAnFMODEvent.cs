using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnFMODEvent : MonoBehaviour
{
    [SerializeField]
    private string soundChoice;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundEvent()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/" + soundChoice);
    }
}
