using System.Collections;
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
        protected bool disableAfterInteract;

        [SerializeField]
        protected AudioClip[] audioClips;

        [SerializeField]
        protected AudioSource audioSource;

        public virtual void Interact(GameObject interactor)
        {
            PlayAudio();

            if (disableAfterInteract) gameObject.SetActive(false);
        }

        public void PlayAudio() => StartCoroutine(IPlayAudio());

        private IEnumerator IPlayAudio()
        {
            yield return null;

            for (int i = 0; i < audioClips.Length; i++)
            {
                audioSource.clip = audioClips[i];

                audioSource.Play();

                while (audioSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
    }

}