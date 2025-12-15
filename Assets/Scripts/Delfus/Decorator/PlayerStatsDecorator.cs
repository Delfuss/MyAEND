using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStatsDecorator //: //IPlayerStats
{
    protected IPlayerStats _innerStats;

    protected PlayerStatsDecorator(IPlayerStats innerStats)
    {
        _innerStats = innerStats;
    }

   // public virtual float GetVelocity() => _innerStats.GetVelocity();
   // public virtual float GetJumpForce() => _innerStats.GetJumpForce();
}

