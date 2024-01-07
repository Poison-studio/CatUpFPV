using UnityEngine;

namespace CatUp
{
    public class PickUpBullets : Interactable
    {
        [SerializeField]
        private int bulletsCount;

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);

            interactor.GetComponent<PlayerAccessPoint>().WeaponHandler.ShotgunBullets.AddBullets(bulletsCount);
            //interactor.GetComponent<PlayerAccessPoint>().WeaponHandler.PickedWeapon.WeaponClip.AddBullets(bulletsCount);

        }
    }

}