using UnityEngine;

namespace CatUp
{
    public class Shotgun : Weapon
    {
        [SerializeField]
        private Transform shootPosition;

        [SerializeField]
        private GameObject InGameCrosshair;

        public override void Shoot()
        {
            //Не уверен, что эта строчка кода должна быть тут
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;

            if (WeaponClip.CurrentBullets <= 0)
            {
                noAmmoSoundEffect.Play();
                return;
            }

            if (shootTimer > 0) return;

            shootTimer = shootDelay;

            shootSoundEffect.Play();

            WeaponClip.CurrentBullets--;

            RaycastHit hit;


            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, shootMask))
            {

                if (hit.collider.gameObject.tag == "Skeleton")
                {
                    hit.collider.gameObject.GetComponent<Health>().GetDamage(1);
                    wasFireHit.Invoke();
                }
            }


            wasFire.Invoke(new ShootInfo(shootImpact, this));

            foreach (ParticleSystem picked in shootParticles)
            {
                picked.Emit(100);
            }
        }
    }
}