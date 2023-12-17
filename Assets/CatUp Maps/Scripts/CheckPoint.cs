using UnityEngine;

namespace CatUp
{
    public class CheckPoint : MonoBehaviour
    {
        //Get current active checkpoint
        public static int activeID { get; private set; } = 0;

        //После инициализации эта переменная содержит в себе общее число чекпоинтов на карте
        public static int maxID { get; private set; } = 0;

        [SerializeField]
        private float freezeTime;

        [SerializeField]
        private ParticleSystem[] commonEffect;

        [SerializeField]
        private ParticleSystem[] pickupEffect;

        [SerializeField]
        private AudioSource pickupAudioEffect;

        public int localID { get; private set; }

        private void Awake()
        {
            localID = maxID;
            maxID++;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player") return;

            activeID = localID;

            DisableCommonEffect();
            PickupEffect();

            //На некоторых чекпоинтах мы не хотим проигрывать звуки, так что их можно просто удалить
            if (pickupAudioEffect != null) pickupAudioEffect.Play();


            GetComponent<BoxCollider>().enabled = false;

        }

        private void DisableCommonEffect()
        {
            if (commonEffect.Length == 0) return;
            foreach (ParticleSystem picked in commonEffect)
            {
                picked.Stop();
            }
        }

        private void PickupEffect()
        {
            if (pickupEffect.Length == 0) return;

            foreach (ParticleSystem picked in pickupEffect)
            {
                picked.Emit(50);
            }
        }
    }

}