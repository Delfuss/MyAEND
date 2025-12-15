using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelWalls : IDamageAmount,IActive
{ 
 public float DamageAmount { get; set; }
 public bool IsActive { get; set; }
 //public bool HasCollided { get; set; }
}
