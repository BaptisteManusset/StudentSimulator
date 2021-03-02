using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public AudioSource EffectsSource;
  public AudioSource MusicSource;

  public float LowPitchRange = .95f;
  public float HighPitchRange = 1.05f;

  public static SoundManager Instance = null;


  public AudioLibrary audioLibrary;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    } else if (Instance != this)
    {
      Destroy(gameObject);
    }

    //DontDestroyOnLoad(gameObject);
  }



  public static void Play(string key) => Play(GetAudioByKey(key));

  public static void Play(AudioClip clip)
  {
    Instance.EffectsSource.clip = clip;
    Instance.EffectsSource.Play();
  }



  public static void PlayMusic(AudioClip clip)
  {
    Instance.MusicSource.clip = clip;
    Instance.MusicSource.Play();
  }

  public static void PlayMusic(string key) => PlayMusic(GetAudioByKey(key));



  // Play a random clip from an array, and randomize the pitch slightly.
  public void RandomSoundEffect(params AudioClip[] clips)
  {
    int randomIndex = Random.Range(0, clips.Length);
    float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

    EffectsSource.pitch = randomPitch;
    EffectsSource.clip = clips[randomIndex];
    EffectsSource.Play();
  }


  public static AudioClip GetAudioByKey(string key)
  {
    for (int i = 0; i < Instance.audioLibrary.list.Count; i++)
    {
      if (Instance.audioLibrary.list[i].key == key)
      {
        return Instance.audioLibrary.list[i].audio;
      }
    }
    return null;
  }
}
