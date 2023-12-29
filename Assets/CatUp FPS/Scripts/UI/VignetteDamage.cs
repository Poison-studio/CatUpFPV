using System.Collections;
using UnityEngine;

namespace CatUp
{
    public class VignetteDamage : MonoBehaviour
    {
        [SerializeField]
        private Q_Vignette_Single vignette;

        [SerializeField]
        private float fadeOutDuration;

        public void GetDamage()
        {
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            float currentTime = 0f;

            while (currentTime < fadeOutDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeOutDuration);

                vignette.mainColor =  new Color(vignette.mainColor.r, vignette.mainColor.g, vignette.mainColor.b, alpha);

                currentTime += Time.deltaTime;

                yield return null;
            }

            yield break;
        }
    }

}