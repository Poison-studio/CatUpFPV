using Hertzole.GoldPlayer;
using System.Collections;
using UnityEngine;
using static Unity.VisualScripting.Member;

namespace CatUp
{
    public class GateTrigger : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private string interactionText;

        [SerializeField]
        private DialogueTrigger trigger;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip[] clips;

        private int behaviour;

        public string InteractableText
        {
            get
            {
                return interactionText;
            }
            set
            {
                interactionText = value;
            }
        }

        public void Interact()
        {
            if(behaviour == 0)
            {
                trigger.Interact();
                behaviour++;
            }
            else if(behaviour == 1)
            {
                animator.SetTrigger("OpenGate");
                StartCoroutine(playAudioSequentially());
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        IEnumerator playAudioSequentially()
        {
            yield return null;

            //1.Loop through each AudioClip
            for (int i = 0; i < clips.Length; i++)
            {
                //2.Assign current AudioClip to audiosource
                audioSource.clip = clips[i];
                if(i == 0)
                {
                    audioSource.pitch = 1.25f;
                }
                else
                {
                    audioSource.pitch = 1f;
                }

                //3.Play Audio
                audioSource.Play();

                //4.Wait for it to finish playing
                while (audioSource.isPlaying)
                {
                    yield return null;
                }

                this.enabled = false;

                //5. Go back to #2 and play the next audio in the adClips array
            }

            FollowTarget[] targets = FindObjectsOfType<FollowTarget>();

            foreach (FollowTarget target in targets)
            {
                target.SetupTarget(FindObjectOfType<GoldPlayerController>().transform);
                target.Follow();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            behaviour = 0;
        }
    }

}