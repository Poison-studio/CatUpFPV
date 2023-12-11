using Hertzole.GoldPlayer;
using System.Collections;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

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
        private AudioSource reloadingSoundEffect;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private GameObject bullet;

        private int remainBullets;

        public bool isActive;

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
            FindObjectOfType<PlayerHealth>().death.AddListener(OnPlayerDeath);
        }

        void Update()
        {
            if (!isActive) return;

            if (Time.timeScale == 0) return;
            shootDelayTimer -= Time.deltaTime;

            if (shootDelayTimer > 0) return;

            if (Input.GetMouseButtonDown(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Empty"))
            {
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R) && animator.GetCurrentAnimatorStateInfo(0).IsName("Empty"))
            {
                Reload();
            }

            //if (Input.GetKey(KeyCode.LeftShift))
            //{
            //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Empty"))
            //    {
            //        animator.SetBool("Running", true);
            //    }

            //}
            //else
            //{
            //    animator.SetBool("Running", false);
            //}
        }

        private void Reload()
        {
            animator.SetTrigger("Reload");
            reloadingSoundEffect.Play();

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

            //GameObject bullet1 = Instantiate(bullet, shells[remainBullets].transform);
            //bullet1.transform.parent = null;
            //bullet1.transform.localScale = Vector3.one;
            //bullet1.AddComponent<Rigidbody>();
            ////bullet1.GetComponent<Rigidbody>().AddForce(transform.up * 10 - transform.right * 10 + transform.forward);
            //bullet1.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(10,30) - transform.right * Random.Range(10, 30) + transform.forward);
            shells[remainBullets].SetActive(false);
            

            remainBullets--;

            shootDelayTimer = shootDelay;

            #region Shoot Logic

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootMask))
            {
                if (hit.collider.gameObject.tag == "Skeleton")
                {
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

        private void OnPlayerDeath()
        {
            GetComponent<BoxCollider>().enabled = true;
            Rigidbody body = gameObject.AddComponent<Rigidbody>();
            body.AddForce((transform.forward * 10 + transform.up * 60/* + transform.right*15*/));
            this.enabled = false;
            animator.enabled = false;
        }
    }
}

