using Cinemachine;
using Hertzole.GoldPlayer;
using UnityEngine;
using Yarn.Unity;

namespace CatUp
{
    public class ActivityHandler : MonoBehaviour
    {
        private void Start()
        {
            characterController = FindObjectOfType<GoldPlayerController>();
            shotgun = FindObjectOfType<Shotgun>(true);
            dialogueRunner = FindObjectOfType<DialogueRunner>();
            interactor = FindObjectOfType<Interactor>();
            interactibleUI = GameObject.FindGameObjectWithTag("InteractibleUI");

            dialogueRunner.SaveStateToPersistentStorage("test5");
        }

        private static GoldPlayerController characterController;
        private static Shotgun shotgun;
        private static DialogueRunner dialogueRunner;
        private static Interactor interactor;
        private static GameObject interactibleUI;
        public static GameObject camera;

        [YarnCommand("StartDialogue")]
        public static void DialogueStart()
        {
            
            //dialogueRunner.Clear();
            dialogueRunner.LoadStateFromPersistentStorage("test5");
            interactibleUI.SetActive(false);
            //dialogueRunner.VariableStorage.Clear();
            //Debug.Log(dialogueRunner.VariableStorage.name);
            interactor.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            characterController.Movement.CanMoveAround = false;
            characterController.Camera.CanLookAround = false;
            //shotgun.isActive = false;
        }

        [YarnCommand("EndDialugue")]
        public static void EndDialogue()
        {
            dialogueRunner.SaveStateToPersistentStorage("test5");
            interactibleUI.SetActive(true);
            interactor.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            characterController.Movement.CanMoveAround = true;
            characterController.Camera.CanLookAround = true;
            //shotgun.isActive = true;

            if(camera != null)
            {
                camera.SetActive(false);
            }
        }
    }

    public enum ActivityState
    {
        PlayerInput,
        Dialogue
    }

}
