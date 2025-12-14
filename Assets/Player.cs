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
        // Obtener componentes necesarios
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
        _renderer = GetComponent<MeshRenderer>();

        if (_rb == null || _audio == null || _renderer == null)
        {
            Debug.LogError("Faltan componentes necesarios en Player (Rigidbody, AudioSource o MeshRenderer)");
            return;
        }

        // Crear modelo
        _model = new Model();

        // Crear vista y pasar dependencias concretas
        _view = new View(_audio, _renderer, this);

        // Crear controlador y pasar dependencias
        _controller = new Controller(_model, _view, _rb);
    }

    void Update()
    {
        if (_controller == null) return;

        // Delegar lógica al controlador
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

    // Métodos públicos para acceder a la vista desde otras clases si se necesita
    public void PlayDamageAudio()
    {
        _view.PlayAudio();
    }

    public void FlashDamageColor()
    {
        _view.ChangeColor();
    }

    // Método para restar vida
    public void TakeDamage(int amount)
    {
        _model.SetLife(amount);
        PlayDamageAudio();
        FlashDamageColor();
    }
}

