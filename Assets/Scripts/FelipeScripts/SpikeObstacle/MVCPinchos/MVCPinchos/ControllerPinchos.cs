using UnityEngine;

public class ControllerPinchos : ITrapDamageDealer
{
    private readonly ITrapStats _model;

    public ControllerPinchos(ITrapStats model)
    {
        _model = model;
    }

     
    public void DealDamage(IDamageable player)
    {
        player.TakeDamage(_model.Damage, _model.ForceToApply, _model.ForceMultiplier);
    }
}
