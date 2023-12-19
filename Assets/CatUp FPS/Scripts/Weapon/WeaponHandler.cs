using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField]
        private GoldPlayerController goldPlayerController;

        //Сериализация ВРЕМЕННАЯ
        [SerializeField]
        private Weapon pickedWeapon;

        private Weapon[] weapons;

        private Vector3 currentWeaponRotation;
        private Vector3 targetWeaponRotation;

        [SerializeField] private float impactSharpness;
        [SerializeField] private float impactReturnSpeed;


        public void Start()
        {
            pickedWeapon.wasFire.AddListener(ApplyImpact);
        }

        public void Update()
        {
            targetWeaponRotation = Vector3.Lerp(targetWeaponRotation, Vector3.zero, impactReturnSpeed * Time.deltaTime);
            currentWeaponRotation = Vector3.Slerp(currentWeaponRotation, targetWeaponRotation, impactSharpness * Time.fixedDeltaTime);
            transform.localRotation = Quaternion.Euler(currentWeaponRotation);
        }

        public void Shoot()
        {
            pickedWeapon.Shoot();
        }

        public void Reload()
        {
            pickedWeapon.Reload();
        }

        public void SwapWeapon()
        {

        }

        private void ApplyImpact(ShootImpact shootImpact)
        {
            goldPlayerController.Camera.CameraShake(shootImpact.cameraShakeFrequency, shootImpact.cameraShakeMagnitude, shootImpact.cameraShakeDuration);
            goldPlayerController.Camera.ApplyRecoil(shootImpact.cameraRecoilAmount,shootImpact.cameraRecoilTime);

            targetWeaponRotation += new Vector3(Random.Range(-shootImpact.weaponRecoilX, shootImpact.weaponRecoilX), Random.Range(-shootImpact.weaponRecoilY, shootImpact.weaponRecoilY), Random.Range(-shootImpact.weaponRecoilZ, shootImpact.weaponRecoilZ));
        }
    }

}