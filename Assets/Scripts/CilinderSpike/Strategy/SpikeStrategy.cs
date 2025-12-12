using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeStrategy : MonoBehaviour
{
    MoveStrategy _MovementStrategy;
    MoveStrategy _StaticStrategy;

    MoveStrategy _CurrentStrategy;

    public bool Move = false;

    private void Start()
    {
        //SetMovement(Move);
        _MovementStrategy = new PointToPointMovement(transform, 2);
        _StaticStrategy = new StaticMovement(transform, 200f);
    }

    private void Update()
    {
        if (Move == true)
        { 
         _CurrentStrategy = _MovementStrategy;
        }

        if (Move == false)
        {
         _CurrentStrategy = _StaticStrategy;
        }

        _CurrentStrategy.ExecuteMove();
    }

    //public void SetMovement(bool Move)
   // {
       // if (Move == false)
        //{
           // _moveStrategy = new 
        //}

        //else if (Move == true)
        //{
           // _moveStrategy = 
        //}
    //}
}
