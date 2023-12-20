using UnityEngine;

namespace CatUp
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private int damage;

        [SerializeField]
        private AudioSource damageAudio;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerHealth>().GetDamage(damage);
                damageAudio.Play();
            }
        }

        private void Start()
        {
            FindObjectOfType<PlayerHealth>().death.AddListener(OnPlayerDeath);
        }

        private void OnPlayerDeath()
        {
            gameObject.SetActive(false);
        }
    }

}