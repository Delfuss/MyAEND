using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostPowerUp : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private float duration = 5f;

   // private void OnTriggerEnter(Collider other)
   // {
       // if (other.TryGetComponent<Player>(out var player))
       // {
           // sound?.Play();

           // player.ApplyTemporaryDecorator(
              //  new JumpBoostDecorator(player.model.CurrentStats),
               // duration
          //  );

          //  Destroy(gameObject);
        //}
   // }
}
