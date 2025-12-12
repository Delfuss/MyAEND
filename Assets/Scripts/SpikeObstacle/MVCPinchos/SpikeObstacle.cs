using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(MeshRenderer))]
public class SpikeObstacle : MonoBehaviour
{
    private ITrapStats _ModelInterface;
    private IDamages _ViewInterface;
    private IDamageable _DamageInterface;

    [SerializeField] AudioSource _AudioSource;
    [SerializeField] Animator _Animator;
    [SerializeField] Renderer _Renderer;


    private void Start()
    {

        _ModelInterface = new ModelPinchos(0.5f,5f);
        _ViewInterface = new ViewPinchos(_AudioSource,_Animator,_Renderer);

    }

    public void Initialize(ITrapStats model, IDamages view, IDamageable player)
    {
        _ModelInterface = model;
        _ViewInterface = view;
        _DamageInterface = player;
    }

    private IEnumerator FlashRedThenOriginal(float duration)
    {
        // Guardamos el color original
        Color originalColor = _Renderer.material.color;

        // Ponemos rojo
        _ViewInterface.SetColor(Color.red);

        // Esperamos el tiempo indicado
        yield return new WaitForSeconds(duration);

        // Volvemos al color original
        _ViewInterface.SetColor(originalColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!other.CompareTag("Player")) return;

            _DamageInterface.TakeDamage(_ModelInterface.Damage, _ModelInterface.ForceToApply, _ModelInterface.ForceMultiplier);

            StartCoroutine(FlashRedThenOriginal(1));

            _ViewInterface.LifeDamageEffect();
        }
    }

}
