using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalInputStrategy : IInputStrategy
{
    public float GetHorizontal() => Input.GetAxis("Horizontal");
    public float GetVertical() => Input.GetAxis("Vertical");
}
