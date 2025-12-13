using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model :  IPlayerStats,IMoreStats
{
    public float Velocity { get; private set; } = 5f;

    public float Xaxi { get; set; } = 5f;

    public float Yaxi { get; set; } = 5f;

    public float JumpForce { get; private set; } = 4f;

    public bool Jump { get; set; } = false;

    public bool Grounded { get; set; } = true;

    public int life { get; private set; } = 4;
}
