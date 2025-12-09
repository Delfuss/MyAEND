using UnityEngine;

public class ModelPinchos : IUnactiveTrap
{
    
    public float Damage { get; private set; } = 0.5f;

    public bool IsActive { get; private set; } = true;

    public float ForceToApply { get; private set; } = 10f;

    public ModelPinchos(float damage = 0.5f, float force = 10f)
    {
        Damage = damage;
        ForceToApply = force;
    }


   
    public void Unactive(bool Value)
    { 
      IsActive = Value;
    }
}
