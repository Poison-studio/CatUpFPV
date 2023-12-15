using TMPro;
using UnityEngine;
using Yarn.Unity;

namespace CatUp
{
    interface IInteractable
    {
        public string text { get; set; }
        public void Interact();
    }

    public class Interactor : MonoBehaviour
    {
        [SerializeField]
        private float interactRange;

        [SerializeField]
        private TextMeshProUGUI viewText;

        [SerializeField]
        private DialogueAdvanceInput advanceInput;

        private void Update()
        {
            Ray r = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {

                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable picked))
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        picked.Interact();
                        //hitInfo.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        advanceInput.dialogueView.UserRequestedViewAdvancement();
                    }

                    viewText.text = picked.text;
                }
                else
                {
                    viewText.text = "";
                }
            }
            else
            {
                viewText.text = "";
            }
        }

    }
}