using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostDecorator  : PlayerStatsDecorator
{
    private float _multiplier;

    public SpeedBoostDecorator (IPlayerStats stats, float multiplier)
        : base(stats)
    {
        _multiplier = multiplier;
    }

    public override float Velocity => base.Velocity * _multiplier;
}

