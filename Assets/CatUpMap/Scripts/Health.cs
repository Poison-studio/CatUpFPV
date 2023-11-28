using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public class Health : MonoBehaviour
    {
        public UnityEvent death;

        [SerializeField]
        private AudioSource audio;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Death Zone")
            {
                Debug.Log("Death");
                death.Invoke();

                audio.Play();
            }
        }
    }

}