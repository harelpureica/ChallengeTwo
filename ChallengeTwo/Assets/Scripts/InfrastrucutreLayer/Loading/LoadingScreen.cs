using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ChallengeTwo.Infrastructure.Loading
{
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        #region Fields
        //the parent panel for all laodiing ui.  
        [SerializeField]
        private RectTransform UIpanelRectTransform;

        //the parent gameObject for all laodiing ui.  

        [SerializeField]
        private GameObject UIparent;

        //the slider  for showing loadiing progress .  

        [SerializeField]
        private Slider loadingSlider;

        //the  speed of  showing/hiding ui . 

        [SerializeField]
        private float fadeSpeed;
        #endregion

        #region Methods

        //scales up the ui panel.
        public async UniTask FadeIn()
        {
            if (UIpanelRectTransform != null)
            {
                UIpanelRectTransform.localScale = Vector3.zero;
            }

            if (UIparent != null)
            {
                UIparent.SetActive(true);
            }

            var lerp = 0f;
            while (lerp < 1)
            {
                if (UIpanelRectTransform == null)
                {
                    return;
                }
                UIpanelRectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
                lerp += UnityEngine.Time.deltaTime * fadeSpeed;
                await UniTask.Yield();
            }
            UIpanelRectTransform.localScale = Vector3.one;
            await UniTask.Delay(500);
        }

        //scales Down the ui panel.

        public async UniTask FadeOut()
        {
            var lerp = 1f;
            while (lerp > 0)
            {
                if (UIpanelRectTransform == null)
                {
                    return;
                }
                UIpanelRectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
                lerp -=UnityEngine.Time.deltaTime * fadeSpeed;
                await UniTask.Yield();
            }
            UIpanelRectTransform.localScale = Vector3.zero;
            if (UIparent != null)
            {
                UIparent.SetActive(false);
            }
            await UniTask.Delay(500);

        }

        //updates the slider value.
        public void UpdateProgress(float progress)
        {
            loadingSlider.value = progress;
        }
      
        #endregion
    }
}
