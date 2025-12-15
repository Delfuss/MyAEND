using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeStrategy : MonoBehaviour
{
    MoveStrategy _MoveStrategy;


    private void Update()
    {
        if (_MoveStrategy != null) _MoveStrategy.ExecuteMove();

    }

    public void SetStrategy(MoveStrategy _Strategy)
    { 
      _MoveStrategy = _Strategy;  
    }
}
