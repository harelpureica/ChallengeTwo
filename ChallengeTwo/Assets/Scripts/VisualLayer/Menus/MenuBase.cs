using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Menus
{
    public abstract class MenuBase :MonoBehaviour
    {
        //the   main parent panel of the menu
        [Inject(Id ="Panel")]        
        protected RectTransform _panel;

        //the menus manager.
        [Inject]
        protected IMenusManager _menusManager;

        #region Properties        
        public abstract string MenuName { get; }

        public bool IsVisible => _visible;

        #endregion

        #region Fields

        protected bool _visible;

        #endregion

        #region Methods
        //adds dynamicly the menu to let the menuManager manage it.
        private void Awake()
        {
            _menusManager.AddMenu(this);
        }
        //removes dynamicly the menu.

        private void OnDisable()
        {
            _menusManager.RemoveMenu(this);
        }

        //show the ui  panel by scaling the panel .
        public virtual async UniTask ShowAsync(float transitiontime)
        {
            _visible = true;
            _panel.gameObject.SetActive(true);
            var lerp = 0f;
            while(lerp<1)
            {
                _panel.localScale = Vector3.Lerp(Vector3.zero,Vector3.one,lerp);
                lerp += Time.deltaTime/ transitiontime;
                await UniTask.Yield();
            }
            _panel.localScale = Vector3.one;
        }

        //hiding the ui  panel by scaling the panel .

        public virtual async UniTask HideAsync(float transitiontime)
        {
            _visible = false;
            var lerp = 0f;
            while (lerp < 1)
            {
                _panel.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, lerp);
                lerp += Time.deltaTime/transitiontime;
                await UniTask.Yield();
            }
            _panel.localScale = Vector3.zero;
            _panel.gameObject.SetActive(false);


        }

        //show the ui  panel immediately by .

        public virtual void ShowImmediate()
        {
            _visible = true;
            _panel.localScale = Vector3.one;
            _panel.gameObject.SetActive(true);
        }

        //Hides  the ui  panel immediately .

        public virtual void HideImmediate()
        {
            _visible = false;
            _panel.localScale = Vector3.zero;
            _panel.gameObject.SetActive(false);
        }
        #endregion
    }
}
