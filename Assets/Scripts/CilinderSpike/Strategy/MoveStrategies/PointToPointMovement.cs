using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointMovement : MoveStrategy
{
    public PointToPointMovement(Transform transform, float speed) : base(transform, speed)
    { }

    public override void ExecuteMove()
    {
       //this._transform.position = _transform.Translate(this.transform.position this.transform.position + new Vector3 (0,0,4)* _speed * Time.deltaTime);
    }
}
