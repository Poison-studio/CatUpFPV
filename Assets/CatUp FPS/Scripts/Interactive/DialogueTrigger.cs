using Hertzole.GoldPlayer;
using UnityEngine;
using Yarn.Unity;

namespace CatUp
{
    public class DialogueTrigger : Interactable
    {
        private static DialogueTrigger active;

        private DialogueRunner dialogueRunner;
        private SaveLoadSystem saveLoadSystem;

        [SerializeField]
        private GameObject virtualCamera;

        [SerializeField]
        private string dialogieToTrigger;

        [SerializeField]
        private Animator animator;

        public GameObject interactor { get; private set; }

        private void Start()
        {
            dialogueRunner = FindObjectOfType<DialogueRunner>();
            saveLoadSystem = FindObjectOfType<SaveLoadSystem>();
        }

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);

            active = this;

            this.interactor = interactor;

            dialogueRunner.StartDialogue(dialogieToTrigger);

            if (virtualCamera != null)
            {
                virtualCamera.SetActive(true);
            }

            if (animator != null)
            {
                animator.SetBool("Talk", true);
            }
        }

        [YarnCommand("StartDialogue")]
        public static void StartDialogue()
        {
            active.interactor.GetComponent<Interactor>().active = false;
            active.interactor.GetComponent<GoldPlayerController>().Movement.CanMoveAround = false;
            active.interactor.GetComponent<GoldPlayerController>().Camera.CanLookAround = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            active.saveLoadSystem.Load();
        }

        [YarnCommand("EndDialugue")]
        public static void EndDialogue()
        {
            active.interactor.GetComponent<Interactor>().active = true;
            active.interactor.GetComponent<GoldPlayerController>().Movement.CanMoveAround = true;
            active.interactor.GetComponent<GoldPlayerController>().Camera.CanLookAround = true;

            if(active.virtualCamera != null)
            {
                active.virtualCamera.SetActive(false);
            }

            active.EnableCollider(active.colliderToDisable);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            active.saveLoadSystem.Save();

            if (active.animator != null)
            {
                active.animator.SetBool("Talk", false);
            }

        }
    }
}