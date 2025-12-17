using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class JumpBoostPowerUp : MonoBehaviour
{
    public float duration = 3f;
    public float jumpMultiplier = 2f;

    private AudioSource _audio;

    private IForceJump _ForceMethod;
    [SerializeField] MonoBehaviour _Script;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();

        _ForceMethod = _Script as IForceJump;
    }

    private void OnTriggerEnter(Collider other)
    {     

        if (other.TryGetComponent<Player>(out var player))
        {
            _ForceMethod.ForceJump(2f);

            player.ApplyTemporaryDecorator(
                stats => new JumpBoostDecorator(stats, jumpMultiplier),
                duration
            );

            _audio.Play();
            Destroy(gameObject, _audio.clip.length);
        }
    }
}
