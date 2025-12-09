using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ControllerPinchos
{
    private ModelPinchos _model;
    private ViewPinchos _view;

    public ControllerPinchos(ModelPinchos model, ViewPinchos view)
    {
        _model = model;
        _view = view;
    }

    public void DamagePlayer(Player player)
    {      
        if (!_model.IsActive) return;

        player.controller.CheckDamage(_model.Damage, _model.ForceToApply,_model.ForceMultiplier);

        _view.LifeDamageEffect();
    }

}
