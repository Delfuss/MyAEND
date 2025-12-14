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
         EndPos = transform.position + new Vector3 (0,0,3);
         t = 0;
    }

    public override void ExecuteMove()
    {
        float dir = AbleToMove ? 1f : -1f; // es si move es true dor vale 1 sino es -1 dir.

        t += Time.deltaTime * _speed * dir;  // si se mueve la trampa multiplico por 1 si no por -1 (dir) por ende va en negativo o positivo

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
