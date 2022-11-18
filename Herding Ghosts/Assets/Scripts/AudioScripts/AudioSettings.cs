using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioSettings : MonoBehaviour
{
    FMOD.Studio.EventInstance SfxVolumeTestEvent;

    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus Sfx;
    float MasterVolume = 1.0f;
    float MusicVolume = 1.0f;
    float SfxVolume = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        Sfx = FMODUnity.RuntimeManager.GetBus("bus:/Master/Sfx");

        SfxVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/CoinsSound");
    }

    // Update is called once per frame
    void Update()
    {
        Master.setVolume(MasterVolume);
        Music.setVolume(MusicVolume);
        Sfx.setVolume(SfxVolume);
    }

    public void MasterVolumeLevel(float newMasterVolume)
    {
        MasterVolume = newMasterVolume;
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
    }

    public void SfxVolumeLevel(float newSfxVolume)
    {
        SfxVolume = newSfxVolume;

        FMOD.Studio.PLAYBACK_STATE PbState;
        SfxVolumeTestEvent.getPlaybackState(out PbState);
        if(PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SfxVolumeTestEvent.start();
        }
    }
}