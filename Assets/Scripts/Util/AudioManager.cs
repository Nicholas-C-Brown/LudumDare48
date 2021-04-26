using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound GameMusic1
    {
        get; private set;
    }
    public Sound GameMusic2
    {
        get; private set;
    }

    public Sound ShopMusic
    {
        get; private set;
    }

    public Sound CurrentMusic
    {
        get; private set;
    }
    public void ChangeMusic(Sound newTrack)
    {
        if (CurrentMusic != null) Stop(CurrentMusic.Name);
        CurrentMusic = newTrack;
        Play(CurrentMusic.Name);
    }


    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;

            sound.Source.loop = sound.Loop;

            sound.Source.playOnAwake = false;
        }

        GameMusic1 = findSound("Boneyard");
        GameMusic2 = findSound("Pain Engine");
        ShopMusic = findSound("Dim");
    }

    public void PlayRandomGameMusic()
    {
        int r = UnityEngine.Random.Range(0, 2);
        print(r);
        switch (r)
        {
            case 0:
                ChangeMusic(GameMusic1);
                break;
            case 1:
                ChangeMusic(GameMusic2);
                break;
        }
    }

    public void Play(string name)
    {
        Sound s = findSound(name);
        if (s != null)
            s.Source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound s = findSound(name);
        if (s != null)
            s.Source.PlayOneShot(s.Clip);
    }

    public void Pause(string name)

    {
        Sound s = findSound(name);
        if (s != null)
            s.Source.Pause();
    }

    public void Stop(string name)
    {
        Sound s = findSound(name);
        if (s != null)
            s.Source.Stop();
    }

    private Sound findSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + s + " does not exist");
            return null;
        }

        return s;
    }


}
