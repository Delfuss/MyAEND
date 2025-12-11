using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseZone : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    private bool isInside = false;           

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            if (!isInside)
            {
                isInside = true;
                StartCoroutine(ActivateReverseAfterDelay(player));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.controller.SetInputStrategy(new NormalInputStrategy());
            isInside = false;
        }
    }

    private System.Collections.IEnumerator ActivateReverseAfterDelay(Player player)
    {
        yield return new WaitForSeconds(delay);

        if (isInside)
        {
            player.controller.SetInputStrategy(new InvertedInputStrategy());
        }
    }
}
