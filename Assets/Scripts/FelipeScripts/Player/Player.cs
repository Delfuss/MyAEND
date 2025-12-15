using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private Iinputs _input;
    private IPlayerMovement _movement;
    private IPlayerState _state;
    private IPlayAnimation _view;

    private Rigidbody _rb;
   public Controller controller;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        var audio = GetComponent<AudioSource>();
        var renderer = GetComponent<MeshRenderer>();
        var anim = GetComponent<Animator>();
        Model model = new Model();
       View view = new View(audio, renderer, this,anim,model);
         controller = new Controller(model, view, _rb);

        _input = controller;
        _movement = controller;
        _state = controller;
        _view = view;
    }

    private void LateUpdate()
    {
        _input.ProcessInputs();

    }

    private void FixedUpdate()
    {
        _movement.MovePlayer(_rb);
        _movement.JumpPlayer(_rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _state.SetGrounded(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _state.SetGrounded(false);
    }
}
