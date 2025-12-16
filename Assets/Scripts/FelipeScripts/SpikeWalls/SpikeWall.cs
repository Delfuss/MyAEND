using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SpikeWall : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animator;

    private ModelWalls _model;
    private ControllerWalls _controller;

    private void Awake()
    {
        _model = new ModelWalls
        {
            DamageAmount = 10f,
            IsActive = true,
        };

        ViewWalls view = new ViewWalls(audioSource, animator);

        _controller = new ControllerWalls(_model, view);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_model.IsActive)
            {
                _controller.Mechanism();
            }
        }
    }
}
