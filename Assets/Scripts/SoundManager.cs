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

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else if (Instance != this)
    {
      Destroy(gameObject);
    }

    DontDestroyOnLoad(gameObject);
  }

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

  // Play a random clip from an array, and randomize the pitch slightly.
  public void RandomSoundEffect(params AudioClip[] clips)
  {
    int randomIndex = Random.Range(0, clips.Length);
    float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

    EffectsSource.pitch = randomPitch;
    EffectsSource.clip = clips[randomIndex];
    EffectsSource.Play();
  }

}
