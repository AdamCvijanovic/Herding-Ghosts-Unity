using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropAudioManager : MonoBehaviour
{
    public static CropAudioManager instance;
    public AudioSource audioCropPull;
    private float minPitch;
    private float maxPitch;

    void Start()
    {
        minPitch = 0.9f;
        maxPitch = 1.1f;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayCropAudio()
    {
        if (audioCropPull != null)
        {
            audioCropPull.pitch = Random.Range(minPitch, maxPitch);
            audioCropPull.Play();
        }
        else
        {
            Debug.LogWarning("Crop audio cannot be found!");
        }
    }
}
