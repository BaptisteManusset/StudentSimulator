using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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
  [SerializeField] string soundEnter = "click";
  [SerializeField] UnityEvent onExist;
  [SerializeField] string soundExist = "click";


  private void Start()
  {
    switch (actionOnStart)
    {
      case ActionOnStart.OnEnter:
        OnEnter();
        break;
      case ActionOnStart.OnExit:
        OnExist();
        break;
    }
  }

  private void OnExist()
  {
    if (soundExist.Length > 0) SoundManager.PlayMusic(soundEnter);

    onExist.Invoke();
  }

  private void OnEnter()
  {
    if (soundEnter.Length > 0) SoundManager.PlayMusic(soundExist);

    onEnter.Invoke();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag(ObjectTag)) OnEnter();
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag(ObjectTag)) onExist.Invoke();
  }
}
