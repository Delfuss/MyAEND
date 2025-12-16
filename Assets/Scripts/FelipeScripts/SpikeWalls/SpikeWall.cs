using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]

public class SpikeWall : MonoBehaviour
{
    private ControllerWalls _Controller;
    private AudioSource _audio;
    private Animator _anim;

    private ModelWalls _Model;
    private ViewWalls _View;
   
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        _Model = new ModelWalls(
        );

        _View = new ViewWalls(
            _audio,
            _anim
        );

        _Controller = new ControllerWalls(_Model, _View);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Model.IsActive = true;
            _Controller.Execute();
        }
    }
}
