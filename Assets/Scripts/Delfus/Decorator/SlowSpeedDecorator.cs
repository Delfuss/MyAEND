using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpeedDecorator : PlayerStatsDecorator
{
    public SlowSpeedDecorator(IPlayerStats innerStats) : base(innerStats) { }

    public override float GetVelocity() => _innerStats.GetVelocity() * 0.2f;
}
