using UnityEngine;

namespace CatUp
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        private AudioPlayer audioPlayer;

        /// <summary>
        /// Убрать эту переменную, звуки воспроизводить через игрока
        /// </summary>
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
                other.GetComponent<PlayerAccessPoint>().AudioPlayer.Play(volume, pitch, audioClip);

                other.gameObject.GetComponent<Health>().GetDamage(damage);
            }
        }
    }

}