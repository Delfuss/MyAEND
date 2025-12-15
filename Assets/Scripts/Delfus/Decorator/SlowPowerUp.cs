using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SlowPowerUp : MonoBehaviour
{
    public float duration = 5f;
    public float slowMultiplier = 0.5f;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.ApplyTemporaryDecorator(
                stats => new SlowSpeedDecorator(stats, slowMultiplier),
                duration
            );

            _audio.Play();

            Destroy(gameObject, _audio.clip.length);
        }
    }
}
