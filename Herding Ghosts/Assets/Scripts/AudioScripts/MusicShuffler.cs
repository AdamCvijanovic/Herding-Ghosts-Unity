using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicShuffler : MonoBehaviour
{
    public AudioSource pattisserieSong1;
    public AudioSource pattisserieSong2;
    public AudioSource pattisserieSong3;
    public AudioSource pattisserieSong4;
    public AudioSource pattisserieSong5;
    public AudioSource pattisserieSong6;

    private bool isMusicPlaying;

    private int randomNumber;
    private int prevRandomNumber;

    void Start()
    {
        isMusicPlaying = false;
    }

    void Update()
    {
        if (pattisserieSong1.isPlaying || pattisserieSong2.isPlaying || pattisserieSong3.isPlaying || pattisserieSong4.isPlaying || pattisserieSong5.isPlaying || pattisserieSong6.isPlaying)
        {
            isMusicPlaying = true;
        }
        else
        {
            isMusicPlaying = false;
        }

        if (!isMusicPlaying)
        {
            do
            {
                randomNumber = Random.Range(1, 7);
            } while (randomNumber == prevRandomNumber);

            prevRandomNumber = randomNumber;

            switch (randomNumber)
            {
                case 1:
                pattisserieSong1.Play();
                break;

                case 2:
                pattisserieSong2.Play();
                break;

                case 3:
                pattisserieSong3.Play();
                break;

                case 4:
                pattisserieSong4.Play();
                break;

                case 5:
                pattisserieSong5.Play();
                break;

                case 6:
                pattisserieSong6.Play();
                break;
            }
        }
    }
}
