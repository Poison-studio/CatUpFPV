using System.Collections;
using UnityEngine;

namespace CatUp
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        public void PlayAudio(AudioClip[] audioClips, float volume, float pitch) => StartCoroutine(IPlayAudio(audioClips, volume, pitch));

        private IEnumerator IPlayAudio(AudioClip[] audioClips, float volume, float pitch)
        {
            audioSource.volume = volume;
            audioSource.pitch = pitch;

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
