using TMPro;
using UnityEngine;

namespace CatUp
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField]
        private float interactRange;

        [SerializeField]
        private TextMeshProUGUI interactableText;

        public bool active { get; set; } = true;

        private void Update()
        {
            Ray r = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {

                if (hitInfo.collider.gameObject.TryGetComponent(out Interactable picked))
                {

                    if (Input.GetKeyDown(KeyCode.E) && active)
                    {
                        picked.Interact(gameObject);
                    }

                    interactableText.text = picked.InteractableText;
                    
                }
                else
                {
                    interactableText.text = "";
                }
            }
            else
            {
                interactableText.text = "";
            }
        }
    }
}