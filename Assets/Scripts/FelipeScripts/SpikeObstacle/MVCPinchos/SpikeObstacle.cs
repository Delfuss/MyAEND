using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SpikeObstacle : MonoBehaviour
{
    private ITrapStats _model;
    private IDamages _view;
    private IColorable _colorable;
    private IDamageable _damageable;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Animator _animator;
    [SerializeField] private Renderer _renderer;

    private void Awake()
    {
        _model = new ModelPinchos(0.5f, 5f);
        _view = new ViewPinchos(_audioSource, _animator, _renderer);

        _colorable = _view as IColorable;
    }

    public void Initialize(ITrapStats model, IDamages view, IDamageable player)
    {
        _model = model;
        _view = view;
        _damageable = player;

        _colorable = view as IColorable;
    }

    private IEnumerator FlashColor(float duration)
    {
        if (_colorable == null) yield break;

        Color original = _renderer.material.color;

        _colorable.SetColor(Color.red);
        yield return new WaitForSeconds(duration);
        _colorable.SetColor(original);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _damageable?.TakeDamage(
            _model.Damage,
            _model.ForceToApply,
            _model.ForceMultiplier
        );

        StartCoroutine(FlashColor(1f));
        _view.LifeDamageEffect();
    }
}
