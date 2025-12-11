using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Iinputs,IDamageable
{
    private Model _model;
    private View _view;
    private Rigidbody _rb;

    private IInputStrategy _inputStrategy;

    public Controller(Model model, View view, Rigidbody rb)
    {
        _model = model;
        _view = view;
        _rb = rb;

        _inputStrategy = new NormalInputStrategy(); 
    }

    public void SetInputStrategy(IInputStrategy strategy)
    {
        _inputStrategy = strategy;
    }

    public void ProcessInputs()
    {
        _model.Xaxi = _inputStrategy.GetHorizontal();
        _model.Yaxi = _inputStrategy.GetVertical();

        if (Input.GetKeyDown(KeyCode.Space) && _model.Grounded)
        {
            _model.Jump = true;
        }
    }

    public void TakeDamage(float damage,float force,int ForceMultiplier)
    {
            _model.SubtractLife();

        Vector3 horizontalDir = -_rb.transform.forward;
        horizontalDir.Normalize();

        Vector3 horizontalForce = horizontalDir * force;

        Vector3 verticalForce = Vector3.up * (force * 0.1f);

        _rb.AddForce(horizontalForce + verticalForce, ForceMode.Impulse);

        _view?.LifeDamageSound();
    }
}
