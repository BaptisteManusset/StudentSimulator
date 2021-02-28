using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{

  [SerializeField] [Tag] string ObjectTag;

  enum ActionOnStart
  {
    nothing = 0,
    OnEnter = 1,
    OnExit = 2
  }

  [SerializeField] ActionOnStart actionOnStart = ActionOnStart.nothing;


  [Header("Events")]
  [SerializeField] UnityEvent onEnter;
  [SerializeField] UnityEvent OnExist;


  private void Start()
  {
    switch (actionOnStart)
    {
      case ActionOnStart.OnEnter:
        onEnter.Invoke();
        break;
      case ActionOnStart.OnExit:
        OnExist.Invoke();
        break;
    }
  }


  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag(ObjectTag)) onEnter.Invoke();
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag(ObjectTag)) OnExist.Invoke();
  }
}
