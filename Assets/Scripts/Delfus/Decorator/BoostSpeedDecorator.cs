using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeedDecorator : PlayerStatsDecorator
{
    public BoostSpeedDecorator(IPlayerStats innerStats) : base(innerStats) { }

    public override float GetVelocity() => _innerStats.GetVelocity() * 4f;
}

