using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStatsDecorator : IPlayerStats
{
    protected IPlayerStats _wrappedStats;

    protected PlayerStatsDecorator(IPlayerStats stats)
    {
        _wrappedStats = stats;
    }

    public virtual float Velocity => _wrappedStats.Velocity;
    public virtual float JumpForce => _wrappedStats.JumpForce;

    public virtual bool Jump
    {
        get => _wrappedStats.Jump;
        set => _wrappedStats.Jump = value;
    }

    public virtual int Life => _wrappedStats.Life;
    public virtual bool Grounded => _wrappedStats.Grounded;
}

