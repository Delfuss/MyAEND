using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IDamageable
{
    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;
    private Rigidbody _rb;

    private View _view;
    public Model model;
    public Controller controller;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();

        _view = new View(_audioSource, _meshRenderer, this);
        model = new Model();
        model.CurrentStats = model;
        controller = new Controller(model, _view, _rb);

        SpikeObstacle[] spikes = FindObjectsOfType<SpikeObstacle>();
        foreach (var spike in spikes)
        {
         spike.Initialize(new ModelPinchos(0.5f, 100f), new ViewPinchos(spike.GetComponent<AudioSource>(), spike.GetComponent<Animator>(), spike.GetComponent<Renderer>()),this);
        }
    }

    void Update()
    {
        controller.ProcessInputs();
        model.JumpPlayer(_rb);
        model.MovePlayer(_rb);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            model.Grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            model.Grounded = false;
    }

    public void TakeDamage(float damage, float force, int forceMultiplier)
    {
        // Aquí aplicás la lógica de daño, por ejemplo:
        Debug.Log($"Player recibe {damage} de daño con fuerza {force} x {forceMultiplier}");
        // Podés aplicar fuerza al Rigidbody si querés
    }
}
