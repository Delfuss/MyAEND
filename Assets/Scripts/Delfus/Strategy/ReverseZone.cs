using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ReverseZone : MonoBehaviour
{
    [SerializeField] private float delay = 1f;

    private AudioSource _audio;
    private Coroutine _reverseCoroutine;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            if (_reverseCoroutine != null)
                StopCoroutine(_reverseCoroutine);

            _reverseCoroutine = StartCoroutine(ReverseAfterDelay(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.SetInputStrategy(new NormalInputStrategy());

            if (_reverseCoroutine != null)
            {
                StopCoroutine(_reverseCoroutine);
                _reverseCoroutine = null;
            }
        }
    }

    private IEnumerator ReverseAfterDelay(Player player)
    {
        yield return new WaitForSeconds(delay);

        _audio.Play();

        player.SetInputStrategy(new InvertedInputStrategy());
    }
}
