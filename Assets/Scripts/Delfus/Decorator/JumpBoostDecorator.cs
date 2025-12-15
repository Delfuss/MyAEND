using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostDecorator : PlayerStatsDecorator
{
    public JumpBoostDecorator(IPlayerStats innerStats) : base(innerStats) { }

    //public override float GetJumpForce() => _innerStats.GetJumpForce() * 5f;
}
