using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointMovement : MoveStrategy
{
    public PointToPointMovement(Transform transform, float speed) : base(transform, speed)
    { }

    public override void ExecuteMove()
    {
       // this._transform.position = _transform.Translate(_transform.right * _speed * Time.deltaTime);
    }
}
