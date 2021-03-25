using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

  Coroutine waiting;

  [Header("Interaction")]

  [SerializeField] Type type = Type.OnCollision;


  [SerializeField] bool waitingToInteract = true;
  bool readyToInteract = false;


  [Header("Cost")] [Expandable] public Data data;


  [ReadOnly] public bool interaction = false;



  public UnityEvent begin;
  public UnityEvent end;




  enum Type
  {
    OnCollision,
    AlwaysActive
  }



  public void InstantInteract()
  {
    if (data)
    {
      StatsManager.ChangeAll(
       data.energy,
       data.mental,
       data.food
       );

      Debug.Log("Instant");
    }
  }


  private void FixedUpdate()
  {
    if (interaction || type == Type.AlwaysActive)
    {
      if (data)
      {
        StatsManager.ChangeAll(
        data.energy * Time.fixedDeltaTime,
        data.mental * Time.fixedDeltaTime,
        data.food * Time.fixedDeltaTime
        );
      }
    } else
    {

    }
  }



  public void WaitForInteract()
  {
    ObjetOverlay.ShowE(this);
    waiting = StartCoroutine(nameof(Waiting));

    BeginForInteract();

  }

  //public void EnableInteract()
  //{
  //  readyToInteract = true;
  //}

  IEnumerator Waiting()
  {

    if (waitingToInteract) yield return new WaitUntil(() => readyToInteract);
    readyToInteract = false;

  }

  private void BeginForInteract()
  {
    interaction = true;
    begin.Invoke();
  }

  public void EndInteract()
  {
    interaction = false;
    end.Invoke();
    ObjetOverlay.HideE();
  }
}
