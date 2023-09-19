using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ChallengeTwo.Infrastructure.Loading
{
    //this class is responsible for displaying loading ui.
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        #region Fields
        //the parent RectTransform panel for all loading ui.  
        [SerializeField]
        private RectTransform _UIpanelRectTransform;

        //the parent gameObject for all laodiing ui.  

        [SerializeField]
        private GameObject _UIparent;

        //the slider  for showing loadiing progress .  

        [SerializeField]
        private Slider _loadingSlider;

        //the  speed of  showing/hiding the ui . 

        [SerializeField]
        private float _fadeSpeed;
        #endregion

        #region Methods

        //scales up the ui panel.
        public async UniTask FadeIn()
        {
            if (_UIpanelRectTransform != null)
            {
                _UIpanelRectTransform.localScale = Vector3.zero;
            }

            if (_UIparent != null)
            {
                _UIparent.SetActive(true);
            }

            var lerp = 0f;
            while (lerp < 1)
            {
                if (_UIpanelRectTransform == null)
                {
                    return;
                }
                _UIpanelRectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
                lerp += UnityEngine.Time.deltaTime * _fadeSpeed;
                await UniTask.Yield();
            }
            _UIpanelRectTransform.localScale = Vector3.one;
            await UniTask.Delay(500);
        }

        //scales Down the ui panel.

        public async UniTask FadeOut()
        {
            var lerp = 1f;
            while (lerp > 0)
            {
                if (_UIpanelRectTransform == null)
                {
                    return;
                }
                _UIpanelRectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
                lerp -=UnityEngine.Time.deltaTime * _fadeSpeed;
                await UniTask.Yield();
            }
            _UIpanelRectTransform.localScale = Vector3.zero;
            if (_UIparent != null)
            {
                _UIparent.SetActive(false);
            }
            await UniTask.Delay(500);

        }

        //updates the slider value.
        public void UpdateProgress(float progress)
        {
            _loadingSlider.value = progress;
        }
      
        #endregion
    }
}
