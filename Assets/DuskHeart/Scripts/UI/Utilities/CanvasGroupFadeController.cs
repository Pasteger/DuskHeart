using System.Collections;
using UnityEngine;

namespace DuskHeart.Scripts.UI.Utilities
{
    public class CanvasGroupFadeController : MonoBehaviour
    {
        public IEnumerator Play(CanvasGroup canvasGroup, float duration, int targetAlpha)
        {
            yield return StartCoroutine(FadeCoroutine(canvasGroup, duration, targetAlpha));
        }

        public IEnumerator Show(CanvasGroup canvasGroup, float duration)
        {
            yield return StartCoroutine(FadeCoroutine(canvasGroup, duration, 1));
            canvasGroup.gameObject.SetActive(true);
            canvasGroup.interactable = true;
        }

        public IEnumerator Hide(CanvasGroup canvasGroup, float duration)
        {
            canvasGroup.interactable = false;
            yield return StartCoroutine(FadeCoroutine(canvasGroup, duration, 0));
            canvasGroup.gameObject.SetActive(false);
        }


        private IEnumerator FadeCoroutine(CanvasGroup canvasGroup, float duration, int targetAlpha)
        {
            var startAlpha = canvasGroup.alpha;
            var elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                var newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
                canvasGroup.alpha = newAlpha;
                yield return null;
            }

            canvasGroup.alpha = targetAlpha;
        }
    }
}