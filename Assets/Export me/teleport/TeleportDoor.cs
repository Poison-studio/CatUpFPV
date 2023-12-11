using UnityEngine;
using System.Collections;
using Hertzole.GoldPlayer;

namespace CatUp
{
    public class TeleportDoor : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Transform destination;

        [SerializeField]
        private Q_Vignette_Single vignette;

        [SerializeField]
        private AudioSource openDoorSound;

        [SerializeField]
        private float fadeOutDuration;

        [SerializeField]
        private float fadeInDuration;

        [SerializeField]
        private string uiText;
        public string text 
        {
            get
            {
                return uiText;
            }
            set
            {
                uiText = value;
            }
        }

        public void Interact()
        {
            openDoorSound.Play();
            Perform();
        }

        public void Perform()
        {
            StartCoroutine(FadeInOut());
        }

        IEnumerator FadeInOut()
        {
            //player.enabled = false;
            float currentTime = 0f;

            while (currentTime < fadeInDuration)
            {
                float alpha = Mathf.Lerp(0f, 1f, currentTime / fadeInDuration);
                //vignette.mainColor = new Color(vignette.mainColor.r, vignette.mainColor.g, vignette.mainColor.b, alpha);
                //vignette.SetVignetteMainScale(alpha*5);
                vignette.mainScale = alpha * 5f;
                currentTime += Time.deltaTime;
                yield return null;
            }

            currentTime = 0f;
            TeleportPlayer();

            while (currentTime < fadeOutDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeOutDuration);
                //vignette.mainColor = new Color(vignette.mainColor.r, vignette.mainColor.g, vignette.mainColor.b, alpha);
                //vignette.SetVignetteMainScale(alpha*5);
                vignette.mainScale = alpha * 5f;
                currentTime += Time.deltaTime;
                yield return null;
            }

            vignette.mainScale = 0f;
            //player.enabled = true;
            yield break;
        }
        private void TeleportPlayer()
        {
            FindObjectOfType<GoldPlayerController>().SetPositionAndRotation(destination.transform.position, destination.transform.eulerAngles.y);
        }
    }

}