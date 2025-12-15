using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private Model _baseModel;              
    private IPlayerStats _currentStats;        

    private Controller _controller;
    private Rigidbody _rb;

    private AudioSource _audioSource;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        Animator animator = GetComponent<Animator>();

        _baseModel = new Model();
        _currentStats = _baseModel;

        View view = new View(_audioSource, renderer, this, animator, _baseModel);

        _controller = new Controller(_baseModel, view, _rb);
    }

    private void LateUpdate()
    {
        _controller.ProcessInputs();
    }

    private void FixedUpdate()
    {
        _controller.MovePlayer(_rb);
        _controller.JumpPlayer(_rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _controller.SetGrounded(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _controller.SetGrounded(false);
    }

    public void ApplyTemporaryDecorator(
        System.Func<IPlayerStats, IPlayerStats> decoratorFactory,
        float duration)
    {
        StopAllCoroutines(); 

        _currentStats = decoratorFactory(_currentStats);
        ApplyStatsToModel(_currentStats);

        StartCoroutine(RemoveDecoratorAfter(duration));
    }

    private IEnumerator RemoveDecoratorAfter(float duration)
    {
        yield return new WaitForSeconds(duration);

        _currentStats = _baseModel;
        _baseModel.ResetStats();
    }

    private void ApplyStatsToModel(IPlayerStats stats)
    {
        _baseModel.ApplyStats(
            stats.Velocity,
            stats.JumpForce
        );
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;
        _audioSource.PlayOneShot(clip);
    }
    public void SetInputStrategy(IInputStrategy strategy)
    {
        _controller.SetInputStrategy(strategy);
    }
}
