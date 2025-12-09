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
        //if (_model.IsActive == false)
        //  return;

        // EventsTypes.InvokeEvent(EventStrings.PlayerDamage);



        //player.controller.CheckDamage(_model.Damage, _model.ForceToApply);


        // player.controller.CheckDamage(_model.Damage,_model.ForceToApply);

        // _view.LifeDamageEffect();

        if (!_model.IsActive) return;

        // 1️⃣ Aplicar daño y fuerza al player
        player.controller.CheckDamage(_model.Damage, _model.ForceToApply);

        // 2️⃣ Activar efectos visuales y sonido del spike
        _view.LifeDamageEffect();

    }

}
