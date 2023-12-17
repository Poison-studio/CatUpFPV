using Cinemachine;
using UnityEngine;
using Yarn.Unity;

namespace CatUp
{
    public class DialogueTrigger : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private DialogueRunner dialogueRunner;

        [SerializeField]
        private GameObject virtualCamera;

        //[SerializeField]
        //private LineView lineView;

        [SerializeField]
        private string text1;

        [SerializeField]
        private string dialogieToTrigger;

        [SerializeField]
        private Animator animator;

        public string text
        {
            get
            {
                return text1;
            }
            set
            {
                text1 = value;
            }
        }

        public void Interact()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            dialogueRunner.StartDialogue(dialogieToTrigger);
            if (virtualCamera != null)
            {
                virtualCamera.SetActive(true);
                ActivityHandler.camera = virtualCamera;
            }

            if (animator != null)
            {
                animator.SetBool("Talk", true);
            }

            
            //if (gameObject.GetComponent<BoxCollider>())
            //{
            //    gameObject.GetComponent<BoxCollider>().enabled = false;

            //}
        }

        public void Update()
        {
            Debug.Log(dialogueRunner.IsDialogueRunning);

            if(!dialogueRunner.IsDialogueRunning)
            {

                if (animator != null)
                {
                    animator.SetBool("Talk", false);
                }
            }
        }
    }
}