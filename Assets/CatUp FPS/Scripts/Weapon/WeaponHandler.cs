using Hertzole.GoldPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatUp
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField]
        private GoldPlayerController goldPlayerController;

        [SerializeField]
        private PlayerAccessPoint playerAccessPoint;

        [SerializeField]
        private Transform spawnPoint;

        private Weapon pickedWeapon;
        public Weapon PickedWeapon => pickedWeapon;

        [SerializeField]
        private List<Weapon> weapons;

        private Vector3 currentWeaponRotation;
        private Vector3 targetWeaponRotation;

        [SerializeField] private float impactSharpness;
        [SerializeField] private float impactReturnSpeed;


        private WeaponClip shotgunBullets;
        public WeaponClip ShotgunBullets
        {
            get
            {
                return shotgunBullets == null ? shotgunBullets = new WeaponClip() : shotgunBullets;
            }
            private set
            {
                shotgunBullets = value;
            }
        }

        public void Start()
        {
            weapons = new List<Weapon>();
        }

        public void Update()
        {
            targetWeaponRotation = Vector3.Lerp(targetWeaponRotation, Vector3.zero, impactReturnSpeed * Time.deltaTime);
            currentWeaponRotation = Vector3.Slerp(currentWeaponRotation, targetWeaponRotation, impactSharpness * Time.fixedDeltaTime);
            transform.localRotation = Quaternion.Euler(currentWeaponRotation);
        }

        public void Shoot()
        {
            pickedWeapon?.Shoot();
        }

        public void Reload()
        {
            pickedWeapon?.Reload();
        }

        Coroutine coroutine;

        public void SwapWeapon(int weaponNumber)
        {
            if (weaponNumber > weapons.Count - 1) return;
            if (weapons[weaponNumber] == pickedWeapon) return;
            if (coroutine != null) return;

            if (pickupCoroutine != null) return;

            coroutine = StartCoroutine(SwapWeapon());


            IEnumerator SwapWeapon()
            {
                pickedWeapon.Hide();

                yield return new WaitForSeconds(.9f);

                //pickedWeapon.gameObject.SetActive(false);

                pickedWeapon = weapons[weaponNumber];
                //pickedWeapon.gameObject.SetActive(true);
                pickedWeapon.PickupWeapon();

                yield return new WaitForSeconds(.2f);

                coroutine = null;
                yield return null;

            }
        }


        Coroutine pickupCoroutine;

        public void PickupWeapon(GameObject weaponToPickup)
        {
            if (pickedWeapon != null)
            {
                GameObject newWeaponGameObject = Instantiate(weaponToPickup, spawnPoint);

                Weapon newWeapon = newWeaponGameObject.GetComponent<Weapon>();
                newWeapon.WeaponClip = ShotgunBullets;

                weapons.Add(newWeapon);
                newWeapon.wasFire.AddListener(ApplyImpact);
                playerAccessPoint.PlayerDeath.AddListener(newWeapon.DropWeapon);
                foreach (Crosshair crosshair in FindObjectsOfType<Crosshair>())
                {
                    newWeapon.wasFireHit.AddListener(crosshair.GetDamage);
                }
                //newWeapon.gameObject.SetActive(false);
                return;
            }
            pickupCoroutine = StartCoroutine(PickupWeapon());

            IEnumerator PickupWeapon()
            {

                GameObject newWeaponGameObject = Instantiate(weaponToPickup, spawnPoint);

                Weapon newWeapon = newWeaponGameObject.GetComponent<Weapon>();
                newWeapon.WeaponClip = ShotgunBullets;

                weapons.Add(newWeapon);

                pickedWeapon = newWeapon;
                yield return new WaitForSeconds(.7f);
                pickedWeapon.PickupWeapon();

                pickedWeapon.wasFire.AddListener(ApplyImpact);

                playerAccessPoint.PlayerDeath.AddListener(pickedWeapon.DropWeapon);

                foreach (Crosshair crosshair in FindObjectsOfType<Crosshair>())
                {
                    pickedWeapon.wasFireHit.AddListener(crosshair.GetDamage);
                }

                yield return new WaitForSeconds(.4f);

                pickupCoroutine = null;

                yield return null;
            }
        }

        private void ApplyImpact(ShootInfo shootInfo)
        {
            goldPlayerController.Camera.CameraShake(shootInfo.shootImpact.cameraShakeFrequency, shootInfo.shootImpact.cameraShakeMagnitude, shootInfo.shootImpact.cameraShakeDuration);
            goldPlayerController.Camera.ApplyRecoil(shootInfo.shootImpact.cameraRecoilAmount, shootInfo.shootImpact.cameraRecoilTime);

            targetWeaponRotation += new Vector3(Random.Range(-shootInfo.shootImpact.weaponRecoilX, shootInfo.shootImpact.weaponRecoilX),
                Random.Range(-shootInfo.shootImpact.weaponRecoilY, shootInfo.shootImpact.weaponRecoilY), Random.Range(-shootInfo.shootImpact.weaponRecoilZ, shootInfo.shootImpact.weaponRecoilZ));
        }
    }

}