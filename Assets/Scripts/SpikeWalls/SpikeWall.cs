using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]


public class SpikeWall : MonoBehaviour
{
    private ModelWalls _model;
    private ControllerWalls _controller;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        _model = new ModelWalls
        {
            DamageAmount = 10f,
            IsActive = true,
            HasCollided = false
        };

        ViewWalls view = new ViewWalls(audioSource, animator);

        _controller = new ControllerWalls(_model, view);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _model.IsActive = true;
            if (_model.IsActive)
            {
                _model.HasCollided = true;
                _controller.Mechanism();
            }
        }   
    }
}
