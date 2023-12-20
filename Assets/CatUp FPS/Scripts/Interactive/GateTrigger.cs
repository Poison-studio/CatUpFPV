using UnityEngine;

namespace CatUp
{
    public class GateTrigger : Interactable
    {
        [SerializeField]
        private Animator animator;

        private int behaviour = 0;

        public override void Interact(GameObject interactor)
        {
            if(behaviour == 0)
            {
                interactableQueue.Interact(interactor);
                behaviour++;
            }
            else if(behaviour == 1)
            {
                base.Interact(interactor);
                animator.SetTrigger("OpenGate");
            }
        }
    }

}