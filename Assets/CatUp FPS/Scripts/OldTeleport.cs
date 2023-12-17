using Hertzole.GoldPlayer;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace CatUp
{
    public class OldTeleport : MonoBehaviour
    {
        [SerializeField]
        private GameObject destination;

        [SerializeField]
        private float fadeOutDuration;

        [SerializeField]
        private float fadeInDuration;

        [SerializeField]
        private Q_Vignette_Single vignette;

        private GoldPlayerController player;

        public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && destination != null)
            {
                player = other.GetComponent<GoldPlayerController>();
                Perform();
            }
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
            player.SetPositionAndRotation(destination.transform.position,destination.transform.eulerAngles.y);
        }
    }

}