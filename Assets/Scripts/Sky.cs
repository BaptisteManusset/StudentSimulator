using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
  SpriteRenderer sprite;

  public Gradient sky;

  [Range(0, 1)] public float sali = 0;

  private void Start()
  {

    sprite = GetComponent<SpriteRenderer>();
  }


  private void Update()
  {
    sprite.color = sky.Evaluate(TimeManager.NormalizedDayAdvancement);
  }

}
