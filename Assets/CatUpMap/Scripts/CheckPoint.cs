using UnityEngine;

namespace CatUp
{
    public class CheckPoint : MonoBehaviour
    {
        //Get current active checkpoint
        public static int activeID { get; private set; } = 0;
        //CheckPoints on map
        public static int maxID { get; private set; } = 0;

        [SerializeField]
        private ParticleSystem[] particleSystems;

        [SerializeField]
        private ParticleSystem[] pickupEffict;

        [SerializeField]
        private AudioSource audio;

        public int localID { get; private set; }

        private void Awake()
        {
            localID = maxID;
            maxID++;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                activeID = localID;
                DisableEffect();

                PickupEffect();
                PlaySound();
                //Debug.Log(name);
                if(name != "Start CheckPoint")
                {
                    FindObjectOfType<ScoreManager>().FreezeScore();
                }
                //FindObjectOfType<ScoreManager>().FreezeScore();
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        private void DisableEffect()
        {
            if (particleSystems.Length == 0) return;
            foreach (ParticleSystem picked in particleSystems)
            {
                picked.Stop();
            }
        }

        private void PlaySound()
        {
            if(audio != null)
            {
                audio.gameObject.SetActive(true);
                audio.Play();
            }
            //Debug.Log();
            //audio.Play();
        }

        private void PickupEffect()
        {
            if (pickupEffict.Length == 0) return;

            foreach (ParticleSystem picked in pickupEffict)
            {
                picked.Emit(50);
            }
        }
    }

}