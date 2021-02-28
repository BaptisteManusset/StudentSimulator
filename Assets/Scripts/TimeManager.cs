using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

  public static TimeManager instance;

  private void Awake()
  {
    if (instance == null)
      instance = this;
  }


  [Header("Cost")]
  [SerializeField] float mental = 0;
  [SerializeField] float food = 0;
  [SerializeField] float energy = 0;

  public enum Day
  {
    Lundi,
    Mardi,
    Mercredi,
    Jeudi,
    Vendredi,
    Samedi,
    Dimanche
  }

  [Header("Temps")]
  public Day dayOfWeek = Day.Lundi;
  public int dayCount = 0;
  public int hour = 0;
  public int min = 0;
  public int counter = 0;


  [SerializeField] int timeSpeed = 1;
  [SerializeField] int timeBoost = 1;

  public int TimeBoost { get => timeBoost; set => timeBoost = value; }
  public static float NormalizedDayAdvancement { get => ((float)instance.counter) / (60 * 24) % 1; }


  public static int GetTimeInSecond()
  {
    return instance.min;
  }


  private void FixedUpdate()
  {
    TimeProgression();




    if (mental != 0) StatsManager.ChangeMental(-(mental * Time.fixedDeltaTime));
    if (food != 0) StatsManager.ChangeFood(-(food * Time.fixedDeltaTime));
    if (energy != 0) StatsManager.ChangeEnergy(-(energy * Time.fixedDeltaTime));
  }

  private void TimeProgression()
  {
    int increase = timeSpeed * timeBoost;

    min += increase;
    counter += increase;

    if (min >= 60)
    {
      hour++;
      min = 0;
    }
    if (hour >= 24)
    {
      dayCount++;
      hour = 0;
      dayOfWeek++;
    }
    dayOfWeek = (Day)((int)dayOfWeek % 7);
  }
}
