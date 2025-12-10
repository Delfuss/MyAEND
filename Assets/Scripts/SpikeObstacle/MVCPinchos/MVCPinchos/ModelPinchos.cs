using UnityEngine;

public class ModelPinchos : ITrapStats
{
    public int ForceMultiplier { get; private set; }
    public float Damage { get; private set; }

    public bool IsActive { get; private set; }

    public float ForceToApply { get; private set; }

    public ModelPinchos(float damage, float force)
    {
        Damage = damage;
        ForceToApply = force;
    } 
    
     public void SetActive(bool value)
     {
        IsActive = value;
     }
}
