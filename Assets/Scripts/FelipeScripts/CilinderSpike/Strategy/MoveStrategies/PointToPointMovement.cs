using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PointToPointMovement : MoveStrategy
{
    Vector3 StartPos;
    Vector3 EndPos;
    float t;
    bool AbleToMove;

    public PointToPointMovement(Transform transform, float speed) : base(transform, speed)
    {
         StartPos = transform.position;
         EndPos = transform.position + new Vector3 (2,0,0);
         t = 0;
    }

    public override void ExecuteMove()
    {
        float dir = AbleToMove ? 1f : -1f; 

        t += Time.deltaTime * _speed * dir;

        if (t >= 1f)
        {
            t = 1f;
            AbleToMove = false;
        }
        else if (t <= 0f)
        {
            t = 0f;
            AbleToMove = true;
        }

        _transform.position = Vector3.Lerp(StartPos, EndPos, t);
    }
}
