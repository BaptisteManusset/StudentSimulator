using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Sky : MonoBehaviour
{
  SpriteRenderer sprite;
  private float defaultIntensity;
  public Gradient sky;
  public AnimationCurve lightPower;
  [SerializeField] Light2D light;
  [Range(0, 1)] public float sali = 0;

  [Header("Sound")]
  public AnimationCurve soundNight;
  public AudioSource sourceNight;

  [Space()]
  public AnimationCurve soundDay;
  public AudioSource sourceDay;
  private void Start()
  {
    sprite = GetComponent<SpriteRenderer>();
    defaultIntensity = light.intensity;
  }


  private void Update()
  {
    sprite.color = sky.Evaluate(TimeManager.NormalizedDayAdvancement);
    light.intensity = lightPower.Evaluate(TimeManager.NormalizedDayAdvancement);


    sourceNight.volume = Mathf.Clamp(soundNight.Evaluate(TimeManager.NormalizedDayAdvancement), 0, 1);
    sourceDay.volume = Mathf.Clamp(soundDay.Evaluate(TimeManager.NormalizedDayAdvancement), 0, 1);
  }
}
