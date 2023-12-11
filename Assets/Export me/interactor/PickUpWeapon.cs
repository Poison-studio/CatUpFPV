using UnityEngine;

namespace CatUp
{
    public class PickUpWeapon : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private GameObject weapon;

        [SerializeField]
        private string textMessage;
        public string text 
        {
            get
            {
                return textMessage;
            }
            set
            {
                textMessage = value;
            }
        }

        [SerializeField]
        private AudioSource pickupAudio;

        public void Interact()
        {
            weapon.SetActive(true);
            weapon.GetComponent<Shotgun>().isActive = true;
            animator.SetTrigger("Show");
            pickupAudio.Play();
            gameObject.SetActive(false);

        }
    }

}