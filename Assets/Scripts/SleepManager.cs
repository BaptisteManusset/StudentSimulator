using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepManager : MonoBehaviour
{
  [SerializeField] int sleepTimeBoost = 5;
  int previousTimeBoost = 1;

  [SerializeField] Transform zzzz;
  [SerializeField] Transform player;
  [SerializeField] Vector2 offset;

  bool sleeping = false;
  public void Begin()
  {
    sleeping = true;
    previousTimeBoost = TimeManager.instance.TimeBoost;
    TimeManager.instance.TimeBoost = sleepTimeBoost;
    Debug.Log("Sleep");

  }

  private void Update()
  {
    if (sleeping)
      zzzz.position = player.position + (Vector3)offset;

  }

  public void End()
  {
    sleeping = false;
    TimeManager.instance.TimeBoost = previousTimeBoost;
    Debug.Log("Wake-up");
  }
}
