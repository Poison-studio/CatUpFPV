using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public class Health : MonoBehaviour
    {
        public UnityEvent death;

        [SerializeField]
        private AudioSource deathAudio;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Death Zone")
            {
                death.Invoke();

                deathAudio.Play();
            }
        }
    }

}