using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostDecorator : PlayerStatsDecorator
{
    private float _multiplier;

    public JumpBoostDecorator(IPlayerStats stats, float multiplier)
        : base(stats)
    {
        _multiplier = multiplier;
    }

    public override float JumpForce => _wrappedStats.JumpForce * _multiplier;
}
