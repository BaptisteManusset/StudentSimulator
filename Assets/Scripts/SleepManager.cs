using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepManager : MonoBehaviour
{
  [SerializeField] int sleepTimeBoost = 5;
  int previousTimeBoost = 1;
  public void Begin()
  {
    previousTimeBoost = TimeManager.instance.TimeBoost;
    TimeManager.instance.TimeBoost = sleepTimeBoost;
    Debug.Log("Sleep");
  }

  public void End()
  {
    TimeManager.instance.TimeBoost = previousTimeBoost;
    Debug.Log("Wake-up");
  }
}
