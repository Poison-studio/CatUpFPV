using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField]
        private AudioClip audioClip;

        [SerializeField]
        private float pitch;

        [SerializeField]
        private float volume;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Player") return;

            other.GetComponent<Health>().GetDamage(1);
            other.GetComponent<PlayerAccessPoint>().AudioPlayer.Play(volume, pitch, audioClip);
            other.GetComponent<GoldPlayerController>().SetPositionAndRotation(CheckPoint.GetActiveCheckPoint().transform.position,
                CheckPoint.GetActiveCheckPoint().transform.eulerAngles.y);
        }
    }
}