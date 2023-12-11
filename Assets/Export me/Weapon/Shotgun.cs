using Hertzole.GoldPlayer;
using System.Collections;
using UnityEngine;

namespace CatUp
{
    public class Shotgun : MonoBehaviour
    {
        [SerializeField]
        private LayerMask shootMask;

        [SerializeField]
        private GoldPlayerController playerController;

        [SerializeField]
        private Recoil recoilScript;

        [SerializeField]
        private AudioSource shootSoundEffect;

        [SerializeField]
        private AudioSource noAmmoSoundEffect;

        [SerializeField]
        private Animator animator;

        private int remainBullets;

        [SerializeField]
        private int totalBulletsCount;

        [Tooltip("Время между выстрелами")]
        [SerializeField]
        private float shootDelay;

        //Нужно убрать эту переменную и брать время напрямую из аниматора
        [Tooltip("Время, которое игрок не сможет стрелять во время перезарядки")]
        [SerializeField]
        private float reloadDelay;

        //Во время перезарядки нужно показать гильзы на оружии, переменная showShellsDelay позволяет определить, когда именно гильзы появятся.
        [SerializeField]
        private float showShellsDelay;

        private float shootDelayTimer;

        [SerializeField]
        private GameObject[] shells;

        [SerializeField]
        private ParticleSystem[] shootParticleEffect;
        

        void Start()
        {
            shootDelayTimer = shootDelay;
            remainBullets = totalBulletsCount;
        }

        void Update()
        {
            shootDelayTimer -= Time.deltaTime;

            if (shootDelayTimer > 0) return;

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }

        private void Reload()
        {
            animator.SetTrigger("Reload");

            remainBullets = totalBulletsCount;
            shootDelayTimer = reloadDelay;

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


        private void Shoot()
        {
            if (remainBullets < 0)
            {
                noAmmoSoundEffect.Play();
                return;
            }

            shells[remainBullets].SetActive(false);

            remainBullets--;

            shootDelayTimer = shootDelay;

            #region Shoot Logic

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootMask))
            {
                if (hit.collider.gameObject.tag == "Skeleton")
                {
                    Debug.Log("Git skeleton");
                    hit.collider.gameObject.GetComponent<DestroyMe>().Destroy();
                }
            }

            #endregion

            #region Shoot Visual & Audio Effects

            playerController.Camera.CameraShake(2, 2, 1);
            playerController.Camera.ApplyRecoil(3f, 1f);

            recoilScript.ApplyRecoil();

            shootSoundEffect.Play();

            foreach (ParticleSystem picked in shootParticleEffect)
            {
                picked.Emit(100);
            }

            #endregion
        }
    }
}

