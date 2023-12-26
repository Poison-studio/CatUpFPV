using Cinemachine;
using System.Collections;
using UnityEngine;

namespace CatUp
{
    public class Shotgun : Weapon
    {
        [SerializeField]
        private GameObject[] shells;

        [SerializeField]
        private Transform shootPosition;

        protected override void Update()
        {
            base.Update();

            //Debug.DrawRay(shootPosition.transform.position, shootPosition.transform.forward*1000,Color.red);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1000, Color.red);
        }

        public override void Reload()
        {
            //Не уверен, что эта строчка кода должна быть тут
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;

            if (shootTimer > 0) return;

            animator.SetTrigger("Reload");

            CurrentAmmo = maxAmmo;
            shootTimer = reloadDelay;

            reloadingSoundEffect.Play();

            StartCoroutine(ShowShells());

            IEnumerator ShowShells()
            {
                yield return new WaitForSeconds(.5f);

                foreach (GameObject go in shells)
                {
                    go.SetActive(true);
                }

                yield return null;
            }
        }

        public override void Shoot()
        {
            //Не уверен, что эта строчка кода должна быть тут
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;

            if (CurrentAmmo <= 0)
            {
                noAmmoSoundEffect.Play();
                return;
            }

            if (shootTimer > 0) return;

            shootTimer = shootDelay;

            shootSoundEffect.Play();

            CurrentAmmo--;

            shells[CurrentAmmo].SetActive(false);

            RaycastHit hit;

            if (Physics.Raycast(shootPosition.transform.position, shootPosition.transform.forward, out hit, Mathf.Infinity, shootMask))
            {

                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Skeleton")
                {
                    hit.collider.gameObject.GetComponent<Health>().GetDamage(1);
                }
            }

            wasFire.Invoke(shootImpact);

            foreach (ParticleSystem picked in shootParticles)
            {
                picked.Emit(100);
            }
        }
    }

}