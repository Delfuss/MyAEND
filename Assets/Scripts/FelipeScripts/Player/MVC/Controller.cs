using UnityEngine;

public class Controller : Iinputs, IPlayerMovement, IPlayerState
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _model.Jump = true;
            Debug.Log("funciono");
        }
    }

    public void MovePlayer(Rigidbody rb)
    {
        Vector3 movement = new Vector3(_model.Xaxi, 0, 0.4f);
        rb.MovePosition(rb.position + movement * _model.Velocity * Time.deltaTime);
    }

    public void JumpPlayer(Rigidbody rb)
    {
        if (_model.Grounded && _model.Jump)
        {
            rb.AddForce(Vector3.up * _model.JumpForce, ForceMode.Impulse);
            _model.Jump = false;
        }
    }

    public void SetGrounded(bool value)
    {
        _model.SetGrounded(value);
    }

    public void SetLife(int value)
    {
        _model.SetLife(value);
    }
}
