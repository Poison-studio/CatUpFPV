using UnityEngine;

namespace CatUp
{
    public class PickUpWeapon : Interactable
    {
        [SerializeField]
        private GameObject weaponPrefab;

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);

            interactor.GetComponent<PlayerAccessPoint>().WeaponHandler.PickupWeapon(weaponPrefab);
        }
    }

}