using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FootstepAudio : MonoBehaviour
{
    public AudioSource audioFootsteps;
    private bool isWalking;
    private float audioPitch;

    void Start()
    {
        isWalking = false;
    }

    void Update()
    {
        if (Keyboard.current[Key.W].wasPressedThisFrame || Keyboard.current[Key.A].wasPressedThisFrame || Keyboard.current[Key.S].wasPressedThisFrame || Keyboard.current[Key.D].wasPressedThisFrame)
        {
            //audioFootsteps.Play();
            //isWalking = true;
        }
        else if (Keyboard.current[Key.W].wasPressedThisFrame == false && Keyboard.current[Key.A].wasPressedThisFrame == false && Keyboard.current[Key.S].wasPressedThisFrame == false && Keyboard.current[Key.D].wasPressedThisFrame == false)
        {
           //audioFootsteps.Stop();
        }
    }
}
