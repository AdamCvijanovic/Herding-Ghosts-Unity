using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteract : MonoBehaviour
{
    private Animator _animator;

    //audio
    public AudioSource audioCat1;
    public AudioSource audioCat2;
    public AudioSource audioCat3;
    public AudioSource audioCat4;
    private int audioRandom;
    private int audioRandomPrevious;
    private bool canPlay;

    // Start is called before the first frame update
    void Start()
    {
        canPlay = false;
        _animator = GetComponent<Animator>();
        SetInteractTrue();
        audioRandom = 1;
    }


    // Update is called once per frame
    void Update()
    {
        canPlay = true;
    }

    public void SetInteractTrue()
    {
        _animator.SetBool("isInteracted", true);

        if (canPlay)
        {
            do
            {
                audioRandom = Random.Range(1, 4);
            } while (audioRandom == audioRandomPrevious);

            audioRandomPrevious = audioRandom;

            switch (audioRandom)
            {
                case 1:
                audioCat1.Play();
                break;

                case 2:
                audioCat2.Play();
                break;

                case 3:
                audioCat3.Play();
                break;

                case 4:
                audioCat4.Play();
                break;
            }
        }

    }
    public void SetInteractFalse()
    {
        _animator.SetBool("isInteracted", false);

    }
}
