using ChallengeTwo.VisualLayer.Car;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ChallengeTwo.VisualLayer.Menus
{
    [RequireComponent(typeof(Button))]
    public class OpenScanningMenu:MonoBehaviour
    {
        #region Injects
        // the menus Manager that holds the the functions to show/hide menus .
        [Inject]
        private IMenusManager _menusManager;

        //the car ui for hiding it when opening the scanning ui
        [Inject]
        private CarUi _carUi;
        #endregion

        #region Fields
        //the button for opening the menu
        private Button _button;
        #endregion

        #region Methods
        //caching the button and subscribing to its onclick event.
        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OpenMenu);
        }

        //opening menu.
        public async void OpenMenu()
        {
            await _menusManager.ShowMenu("Scanning");
            _carUi.SetActive(false);
        }
    }
    #endregion
}

