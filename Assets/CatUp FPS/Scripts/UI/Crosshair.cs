using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CatUp
{
    public class Crosshair : MonoBehaviour
    {
        [SerializeField]
        private Image crosshair;

        [SerializeField]
        private float fadeOutDuration;

        Coroutine coroutine;

        public void GetDamage()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            coroutine = StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            float currentTime = 0f;

            while (currentTime < fadeOutDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeOutDuration);

                crosshair.color = new Color(crosshair.color.r, crosshair.color.g, crosshair.color.b, alpha);

                currentTime += Time.deltaTime;

                yield return null;
            }

            yield break;
        }
    }
}