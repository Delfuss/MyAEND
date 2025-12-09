using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();

        _view = new ViewPinchos(_audioSource,_ParticleSystem);

        model = new ModelPinchos();
  
        controller = new ControllerPinchos(model, _view);

        _view.Initialize();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
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
