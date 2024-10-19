using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private static AudioManager instance;
    //public AudioMixerGroup audioMixer;
    // Start is called before the first frame update

    private void Start()
    {

    }
    void Awake()
    {
        /*
        if (instance != null && instance.gameObject.name == gameObject.name)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        */

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            //s.source.outputAudioMixerGroup = audioMixer;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;

        s.source.Stop();
    }

    public bool StillPlaying(string name)
    {
        Sound s = Array.Find(sounds, item => item.name == name);
        if (s.source.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.PlayOneShot(s.clip);
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }
    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.UnPause();
    }

    public void LowerVolume(string name, float minus)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume -= minus;
    }

    public void RaiseVolume(string name, float plus)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume += plus;
    }

    public void SetVolume(string name, float set)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = set;
    }

    public void Destroy(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        Destroy(s.source.gameObject);
    }
}
