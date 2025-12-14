using UnityEngine;

public class Player : MonoBehaviour
{
    private Model _model;
    private View _view;
    private Controller _controller;
    private Rigidbody _rb;
    private AudioSource _audio;
    private MeshRenderer _renderer;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
        _renderer = GetComponent<MeshRenderer>();

        if (_rb == null || _audio == null || _renderer == null)
        {
            Debug.LogError("Faltan componentes necesarios en Player (Rigidbody, AudioSource o MeshRenderer)");
            return;
        }

        _model = new Model();

        _view = new View(_audio, _renderer, this);

        _controller = new Controller(_model, _view, _rb);
    }

    void Update()
    {
        if (_controller == null) return;

        _controller.ProcessInputs();
        _controller.MovePlayer(_rb);
        _controller.JumpPlayer(_rb);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _model.SetGrounded(true);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _model.SetGrounded(false);
    }

    public void PlayDamageAudio()
    {
        _view.PlayAudio();
    }

    public void FlashDamageColor()
    {
        _view.ChangeColor();
    }

    public void TakeDamage(int amount)
    {
        _model.SetLife(amount);
        PlayDamageAudio();
        FlashDamageColor();
    }
}

