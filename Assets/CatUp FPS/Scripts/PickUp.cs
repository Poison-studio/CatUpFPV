using UnityEngine;

namespace CatUp
{
    public class PickUp : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private string interactableText;
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private bool disableafterpickup;
        public string text
        {
            get
            {
                return interactableText;
            }
            set
            {
                interactableText = value;
            }
        }

        public void Interact()
        {
            if(disableafterpickup)
            {
                gameObject.SetActive(false);
            }
            audioSource.Play();
        }
    }

}