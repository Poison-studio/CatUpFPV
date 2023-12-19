using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public class CheckPoint : MonoBehaviour
    {
        public static UnityEvent<Transform> newCheckpointActivated;

        //Текущий активированный чекпоинт
        private static Transform activeCheckPoint;

        [SerializeField]
        private string interactWithTag;

        [SerializeField]
        private ParticleSystem[] loopParticles;

        [SerializeField]
        private ParticleSystem[] pickupParticles;

        [SerializeField]
        private AudioSource pickupAudio;

        [Tooltip("Проигрывать эффекты при использовании чекпоинта")]
        [SerializeField]
        private bool playPickupEffect;

        [Tooltip("Будет ли чекпоинт вызывать newCheckpointActivated эвент при активации чекпоинта")]
        [SerializeField]
        private bool useNotifyEvent;

        private void Awake()
        {
            if(newCheckpointActivated ==  null)
            {
                newCheckpointActivated = new UnityEvent<Transform>();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != interactWithTag) return;

            activeCheckPoint = transform;

            if(newCheckpointActivated != null && useNotifyEvent)
            {
                newCheckpointActivated.Invoke(transform);
            }

            if (playPickupEffect)
            {
                //Stop loop particles
                foreach (ParticleSystem picked in loopParticles)
                {
                    picked.Stop();
                }

                //Play pickup particles
                foreach (ParticleSystem picked in pickupParticles)
                {
                    picked.Emit(50);
                }

                //Play pickup sound
                pickupAudio.Play();
            }

            GetComponent<BoxCollider>().enabled = false;
        }

        public static Transform GetActiveCheckPoint() => activeCheckPoint;
    }
}