using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedInputStrategy : IInputStrategy
{
    public float GetHorizontal() => -Input.GetAxis("Horizontal");
    public float GetVertical() => -Input.GetAxis("Vertical");
}
