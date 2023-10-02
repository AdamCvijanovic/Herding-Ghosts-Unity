using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveSpirit_Script : MonoBehaviour
{
    private Animator _animator;
    
    //audio
    public AudioSource audioFire1;
    public AudioSource audioFire2;
    public AudioSource audioFire3;
    public AudioSource audioFire4;
    private int audioRandom;
    private int audioRandomPrevious;
    private bool canPlay;
    private float minPitch;
    private float maxPitch;

    // Start is called before the first frame update
    void Start()
    {
        canPlay = false;
        _animator = GetComponent<Animator>();
        SetInteractTrue();
        audioRandom = 1;
        minPitch = 0.95f;
        maxPitch = 1.05f;
    }

    
    // Update is called once per frame
    void Update()
    {
        canPlay = true;
    }

    public void SetInteractTrue()
    {
        _animator.SetBool("isInteracted", true);

        if(canPlay)
        {
            do
            {
                audioRandom = Random.Range(1, 4);
            } while (audioRandom == audioRandomPrevious);

            audioRandomPrevious = audioRandom;
            
            switch (audioRandom)
            {
                case 1:
                audioFire1.pitch = Random.Range (minPitch, maxPitch);
                audioFire1.Play();
                break;

                case 2:
                audioFire2.pitch = Random.Range (minPitch, maxPitch);
                audioFire2.Play();
                break;

                case 3:
                audioFire3.pitch = Random.Range (minPitch, maxPitch);
                audioFire3.Play();
                break;

                case 4:
                audioFire4.pitch = Random.Range (minPitch, maxPitch);
                audioFire4.Play();
                break;
            }
        }

    }
     public void SetInteractFalse()
    {
        _animator.SetBool("isInteracted", false);

    }
}
