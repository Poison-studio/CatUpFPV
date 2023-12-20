using Hertzole.GoldPlayer;
using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public class PlayerHealth : MonoBehaviour
    {
        public UnityEvent death;
        public UnityEvent getDamage;
        public UnityEvent respawn;

        [SerializeField]
        private AudioSource waterSplashAudio;

        [SerializeField]
        private int waterDamage;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private GoldPlayerController controller;

        [SerializeField]
        private AudioSource deathSound;

        private int health = 3;

        private bool isDeath = false;

        private void Start()
        {
            death.AddListener(OnDeath);
        }

        public int Health 
        { 
            get
            {
                return health;
            }
            private set
            {
                if (isDeath) return;

                health = value;

                getDamage.Invoke();

                if(health <= 0)
                {
                    isDeath = true;
                    death.Invoke();
                    animator.SetTrigger("Player Death");
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Death Zone")
            {
                GetDamage(waterDamage);
                if(Health > 0)
                {
                    respawn.Invoke();
                }
                //death.Invoke();
                //respawn.Invoke();

                waterSplashAudio.Play();
            }
        }

        public void GetDamage(int damage)
        {
            Health -= damage;
            controller.Camera.CameraShake(2,2,1);
        }

        private void OnDeath()
        {
            deathSound.Play();
        }
    }

}