using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public abstract class Weapon : MonoBehaviour
    {
        public UnityEvent<ShootImpact> wasFire;

        [SerializeField]
        protected ShootImpact shootImpact;

        [SerializeField]
        protected LayerMask shootMask;

        [SerializeField]
        protected ParticleSystem[] shootParticles;

        [SerializeField]
        protected AudioSource shootSoundEffect;

        [SerializeField]
        protected AudioSource noAmmoSoundEffect;

        [SerializeField]
        protected AudioSource reloadingSoundEffect;

        [SerializeField]
        protected Animator animator;

        [SerializeField]
        protected int maxAmmo;

        [SerializeField]
        protected float shootDelay;

        [SerializeField]
        protected float reloadDelay;

        protected float shootTimer;

        private int currentAmmo;
        protected int CurrentAmmo
        {
            get
            {
                return currentAmmo;
            }
            set
            {
                if (value < 0) return;

                currentAmmo = value;
            }
        }

        public void Start()
        {
            shootTimer = 0;
            CurrentAmmo = maxAmmo;
        }

        public abstract void Shoot();

        public abstract void Reload();

        public virtual void DropWeapon()
        {
            GetComponent<BoxCollider>().enabled = true;

            Rigidbody body = gameObject.AddComponent<Rigidbody>();
            body.AddForce((transform.forward * 10 + transform.up * 60));
        }

        protected virtual void Update()
        {
            shootTimer -= Time.deltaTime;
        }
    }
}