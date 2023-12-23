using UnityEngine;

namespace CatUp
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        [SerializeField]
        private AudioPlayer audioPlayer;

        [SerializeField]
        private AudioClip audioClip;

        [SerializeField]
        private float volume;

        [SerializeField]
        private float pitch;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Health>().GetDamage(damage);
                audioPlayer.Play(volume,pitch, audioClip);
            }
        }
    }

}