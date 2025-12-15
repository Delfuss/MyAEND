using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpeedDecorator : PlayerStatsDecorator
{
    private float _multiplier;

    public SlowSpeedDecorator(IPlayerStats stats, float multiplier)
        : base(stats)
    {
        _multiplier = multiplier;
    }

    public override float Velocity => _wrappedStats.Velocity * _multiplier;
}
