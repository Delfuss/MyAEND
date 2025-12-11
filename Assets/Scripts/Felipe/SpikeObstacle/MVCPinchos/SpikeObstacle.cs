using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(MeshRenderer))]
public class SpikeObstacle : MonoBehaviour
{
    private ITrapStats _ModelInterface;
    private ILifeDamage _ViewInterface;
    private IDamageable _DamageInterface;

    [SerializeField] AudioSource _AudioSource;
    [SerializeField] GameObject _Particles;
    [SerializeField] Animator _Animator;

    private void Start()
    {

        _ModelInterface = new ModelPinchos(0.5f,5f);
        _ViewInterface = new ViewPinchos(_AudioSource,_Particles,_Animator);
    }

    public void Initialize(ITrapStats model, ILifeDamage view, IDamageable player)
    {
        _ModelInterface = model;
        _ViewInterface = view;
        _DamageInterface = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Colisiono bien");
            if (!other.CompareTag("Player")) return;

            _DamageInterface.TakeDamage(_ModelInterface.Damage, _ModelInterface.ForceToApply, _ModelInterface.ForceMultiplier);

            _ViewInterface.LifeDamageEffect();
        }
    }

}
