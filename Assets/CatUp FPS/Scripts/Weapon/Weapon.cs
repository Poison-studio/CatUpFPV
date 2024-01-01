using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public abstract class Weapon : MonoBehaviour
    {
        public UnityEvent<ShootInfo> wasFire;
        public UnityEvent wasFireHit;

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
        protected float shootDelay;

        [SerializeField]
        protected float reloadDelay;

        public WeaponClip WeaponClip;

        public UnityEvent<WeaponClip> reload;


        protected float shootTimer;

        public virtual void Start()
        {
            shootTimer = 0;
        }

        public abstract void Shoot();

        public virtual void Reload()
        {
            if (shootTimer > 0) return;

            //Не уверен, что эта строчка кода должна быть тут
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;

            //BulletsInWeapon = BulletsOutWeapon;
            WeaponClip.Reload();

            reload.Invoke(WeaponClip);
            animator.SetTrigger("Reload");

            shootTimer = reloadDelay;

            //reload.Invoke();

            reloadingSoundEffect.Play();
        }

        public virtual void DropWeapon()
        {
            Debug.Log("Drop weapon");
            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().enabled = true;

            transform.parent = null;

            Rigidbody body = gameObject.AddComponent<Rigidbody>();
            body.AddForce((transform.forward * -300 + transform.up * 50 + transform.right * 100));
        }

        public void Hide()
        {
            if(animator!= null)
            {
                animator.SetTrigger("Hide");
            }
        }

        public virtual void PickupWeapon()
        {
            if(animator != null)
            {
                animator.SetTrigger("Show");
            }
        }

        protected virtual void Update()
        {
            shootTimer -= Time.deltaTime;
        }
    }
}