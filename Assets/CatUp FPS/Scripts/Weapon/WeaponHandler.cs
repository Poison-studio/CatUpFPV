using Hertzole.GoldPlayer;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace CatUp
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField]
        private GoldPlayerController goldPlayerController;

        private Weapon pickedWeapon;

        [SerializeField]
        private List<Weapon> weapons;

        private Vector3 currentWeaponRotation;
        private Vector3 targetWeaponRotation;

        [SerializeField] private float impactSharpness;
        [SerializeField] private float impactReturnSpeed;


        public void Start()
        {
            weapons = new List<Weapon>();
            //pickedWeapon.wasFire.AddListener(ApplyImpact);
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

        public void SwapWeapon()
        {

        }

        public void PickupWeapon(GameObject weaponToPickup)
        {
            GameObject newWeaponGameObject = Instantiate(weaponToPickup);
            newWeaponGameObject.transform.parent = transform;
            Weapon newWeapon = newWeaponGameObject.GetComponent<Weapon>();
            weapons.Add(newWeapon);

            pickedWeapon = newWeapon;
            pickedWeapon.PickupWeapon();

            pickedWeapon.wasFire.AddListener(ApplyImpact);
        }

        private void ApplyImpact(ShootImpact shootImpact)
        {
            goldPlayerController.Camera.CameraShake(shootImpact.cameraShakeFrequency, shootImpact.cameraShakeMagnitude, shootImpact.cameraShakeDuration);
            goldPlayerController.Camera.ApplyRecoil(shootImpact.cameraRecoilAmount,shootImpact.cameraRecoilTime);

            targetWeaponRotation += new Vector3(Random.Range(-shootImpact.weaponRecoilX, shootImpact.weaponRecoilX), Random.Range(-shootImpact.weaponRecoilY, shootImpact.weaponRecoilY), Random.Range(-shootImpact.weaponRecoilZ, shootImpact.weaponRecoilZ));
        }
    }

}