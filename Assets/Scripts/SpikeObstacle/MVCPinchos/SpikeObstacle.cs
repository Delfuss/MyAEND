using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SpikeObstacle : MonoBehaviour,IDisable
{
    public ModelPinchos GetModel() => model;

    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;

    private ViewPinchos _view;
    public ModelPinchos model;
    private ControllerPinchos controller;

    [SerializeField] private GameObject _ParticleSystem;

    [SerializeField] private Animator _Anim;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();

        _view = new ViewPinchos(_audioSource,_ParticleSystem,_Anim);

        model = new ModelPinchos();
  
        controller = new ControllerPinchos(model, _view);

        _view.Initialize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                StartCoroutine(DisableParticles());

                controller.DamagePlayer(player);
            }
        }
    }

    public IEnumerator DisableParticles()
    { 
      yield return new WaitForSeconds(2);
        _ParticleSystem.SetActive(false);
    }

}
