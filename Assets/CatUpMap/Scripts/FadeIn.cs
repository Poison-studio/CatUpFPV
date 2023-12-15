//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UIElements;

//public class FadeIn : MonoBehaviour
//{
//    private IEnumerator FadeOut()
//    {
//        float currentTime = 0f;
//        while (currentTime < fadeOutDuration)
//        {
//            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeOutDuration);
//            if (alpha > .95)
//            {
//                background.color = new Color(255, 255, 255, 255);
//            }
//            else if (alpha < .05)
//            {
//                background.color = new Color(255, 255, 255, 0);
//            }

//            if (alpha > .95)
//            {
//                penaltyText.color = new Color(penaltyText.color.r, penaltyText.color.g, penaltyText.color.b, 255);
//            }
//            else if (alpha < .05)
//            {
//                penaltyText.color = new Color(penaltyText.color.r, penaltyText.color.g, penaltyText.color.b, 0);
//            }

//            currentTime += Time.deltaTime;
//            yield return null;
//        }
//        yield break;
//    }
//}
