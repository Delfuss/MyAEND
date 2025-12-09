using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Iinputs
{
    private Model _model;
    private View _view;
    private Rigidbody _rb;
    public Controller(Model model, View view, Rigidbody rb)
    {
        _model = model;
        _view = view;
        _rb = rb;
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

    public void CheckDamage(float damage,float force)
    {
            _model.SubtractLife();
        
        if (_rb != null)
            _rb.AddForce(Vector3.up * force, ForceMode.Impulse);

        _view?.LifeDamageSound();
    }
}
