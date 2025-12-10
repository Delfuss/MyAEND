using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrapStats
{
    float Damage { get; }
    float ForceToApply { get; }
    int ForceMultiplier { get; }
    bool IsActive { get; }
}

