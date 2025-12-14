using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveStrategy
{
    protected Transform _transform;
    protected float _speed;

    protected MoveStrategy(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public abstract void ExecuteMove();
}
