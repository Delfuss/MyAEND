using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Iinputs,IDamageable, ILifeSubstract
{
    private Model _model;
    private View _view;
    private Rigidbody _rb;

    public IPlayerStats CurrentStats;

    public Controller(Model model, View view, Rigidbody rb)
    {
        _model = model;
        _view = view;
        _rb = rb;
    }

    public void SubtractLife()
    {
        _model.life--;
        EventsTypes.InvokeEvent(EventStrings.PlayerDamage);
    }

    public void JumpPlayer(Rigidbody _rb)
    {
        if (_model.Grounded && _model.Jump)
        {
            _rb.AddForce(Vector3.up * CurrentStats.GetJumpForce(), ForceMode.Impulse);

            _model.Jump = false;
        }
    } 

    public void ProcessInputs()
    {
       
       _model.Xaxi = Input.GetAxis("Horizontal");
        _model.Yaxi = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && _model.Grounded)
        {
            _model.Jump = true;

        }
    }

    public void TakeDamage(float damage,float force,int ForceMultiplier)
    {

        Vector3 horizontalDir = -_rb.transform.forward;
        horizontalDir.Normalize();

        Vector3 horizontalForce = horizontalDir * force;

        Vector3 verticalForce = Vector3.up * (force * 0.1f);

        _rb.AddForce(horizontalForce + verticalForce, ForceMode.Impulse);

        _view?.LifeDamageSound();
    }
}
