using UnityEngine;

namespace CatUp
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField]
        protected string interactableText;

        [HideInInspector]
        public string InteractableText => interactableText;

        [SerializeField]
        protected bool disableObjectAfterInteract;

        [SerializeField]
        protected bool disableColliderAfterInteract;

        [SerializeField]
        protected BoxCollider colliderToDisable;

        [SerializeField]
        protected AudioClip[] audioClips;

        [SerializeField]
        protected float audioVolume;

        [SerializeField]
        protected float audioPitch;

        [SerializeField]
        protected Interactable interactableQueue;

        public virtual void Interact(GameObject interactor)
        {
            interactor.GetComponent<PlayerAccessPoint>().AudioPlayer.PlayAudio(audioClips, audioVolume, audioPitch);

            if (disableColliderAfterInteract) colliderToDisable.enabled = false;

            if (disableObjectAfterInteract) gameObject.SetActive(false);
        }

        public virtual void EnableCollider()
        {
            GetComponent<BoxCollider>().enabled = true;
        }

        public virtual void EnableCollider(BoxCollider colliderToEnable)
        {
            colliderToDisable.enabled = true;
        }
    }

}