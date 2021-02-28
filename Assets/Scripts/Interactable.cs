using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
  [Header("Interaction")]
  
  [SerializeField] Type type = Type.OnCollision;



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
    }
  }

  public void BeginInteract()
  {
    interaction = true;
    begin.Invoke();
  }

  public void EndInteract()
  {
    interaction = false;
    end.Invoke();
  }
}
