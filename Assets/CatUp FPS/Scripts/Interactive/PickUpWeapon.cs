using UnityEngine;

namespace CatUp
{
    public class PickUpWeapon : Interactable
    {
        [SerializeField]
        private Animator animator;

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);

            //interactor.GetComponent<Shotgun>().isActive = true;

            animator.SetTrigger("Show");
        }
    }

}