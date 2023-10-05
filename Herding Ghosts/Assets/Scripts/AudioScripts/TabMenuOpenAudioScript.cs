using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TabMenuOpenAudioScript : MonoBehaviour
{
    //there's probably a much better way of doing this...
    public bool isGrimoireOpen;
    public AudioSource audioMenuOpen;
    public AudioSource audioMenuExit;

    void Start()
    {
        isGrimoireOpen = false;
    }

    void Update()
    {
        if (Keyboard.current[Key.Tab].wasPressedThisFrame && isGrimoireOpen == false)
        {
            audioMenuOpen.Play(0);
            isGrimoireOpen = true;
        }
        else if (Keyboard.current[Key.Tab].wasPressedThisFrame && isGrimoireOpen == true)
        {
            audioMenuExit.Play(0);
            isGrimoireOpen = false;
        }
    }
}
