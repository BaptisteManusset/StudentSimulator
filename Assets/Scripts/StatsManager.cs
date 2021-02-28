using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
  public static StatsManager instance;

  [Header("Variables")]
  [SerializeField] FloatReference energy;
  [SerializeField] FloatReference mental;
  [SerializeField] FloatReference food;

  [Header("Variables Max")]
  [SerializeField] FloatReference sleepMax;
  [SerializeField] FloatReference mentalMax;
  [SerializeField] FloatReference foodMax;


  public bool sleep = false;
 





  private void Awake()
  {
    if (instance == null)
      instance = this;

    SetEnergy(sleepMax.Value);
    SetMental(mentalMax.Value);
    SetFood(foodMax.Value);
  }

 public static void ChangeAll(float energyValue, float mentalValue, float foodValue)
  {
    StatsManager.instance.energy.Value += energyValue;
    StatsManager.instance.mental.Value += mentalValue;
    StatsManager.instance.food.Value += foodValue;
  }


  public static void ChangeEnergy(float value) => StatsManager.instance.energy.Value += value;
  public static void SetEnergy(float value) => StatsManager.instance.energy.Value = value;

  public static void ChangeMental(float value) => StatsManager.instance.mental.Value += value;
  public static void SetMental(float value) => StatsManager.instance.mental.Value = value;

  public static void ChangeFood(float value) => StatsManager.instance.food.Value += value;
  public static void SetFood(float value) => StatsManager.instance.food.Value = value;
}
