using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMovement : MoveStrategy
{
    public StaticMovement(Transform transform, float speed) : base(transform, speed)
    { }

    public override void ExecuteMove()
    {
      _transform.Rotate(0,_speed * Time.deltaTime,0);
    }
}
