using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStats 
{
    float Velocity { get; }
    float JumpForce { get; }
    bool Jump { get; }
    int life { get; }
}
