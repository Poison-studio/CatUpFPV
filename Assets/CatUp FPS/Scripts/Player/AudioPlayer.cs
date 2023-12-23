using System.Collections;
using UnityEngine;

namespace CatUp
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] audioClips;

        [SerializeField]
        private AudioSource audioSource;

        public void Play(float volume, float pitch, params AudioClip[] audioClips) => StartCoroutine(IPlayAudio(audioClips, volume, pitch));

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

        public void Play(int clipNumber, float volume, float pitch) => Play(volume, pitch, audioClips[clipNumber]);
    }
}
