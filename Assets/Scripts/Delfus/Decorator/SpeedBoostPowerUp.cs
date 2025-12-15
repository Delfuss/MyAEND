using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpeedBoostPowerUp : MonoBehaviour
{
    public float duration = 5f;
    public float speedMultiplier = 2f;

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
                stats => new SpeedBoostDecorator(stats, speedMultiplier),
                duration
            );

            _audio.Play();
            Destroy(gameObject, _audio.clip.length);
        }
    }
}
