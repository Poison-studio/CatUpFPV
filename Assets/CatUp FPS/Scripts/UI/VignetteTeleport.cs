using System.Collections;
using UnityEngine;

namespace CatUp
{
    public class VignetteTeleport : MonoBehaviour
    {
        [SerializeField]
        private Q_Vignette_Single vignette;

        public void FadeInOut(float fadeDuration)
        {
            StartCoroutine(IFadeInOut(fadeDuration));
        }

        private IEnumerator IFadeInOut(float fadeDuration)
        {
            float currentTime = 0f;

            while (currentTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(0f, 1f, currentTime / fadeDuration);
                vignette.mainScale = alpha * 5f;
                currentTime += Time.deltaTime;
                yield return null;
            }

            currentTime = 0f;

            while (currentTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeDuration);
                vignette.mainScale = alpha * 5f;
                currentTime += Time.deltaTime;
                yield return null;
            }

            vignette.mainScale = 0f;
            yield break;
        }
    }

}