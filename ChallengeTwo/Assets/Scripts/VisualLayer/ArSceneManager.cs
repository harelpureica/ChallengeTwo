using ChallengeTwo.InfrastrucutreLayer.Inputs;
using ChallengeTwo.VisualLayer.AR;
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using UnityEngine;
using Zenject;
using ChallengeTwo.VisualLayer.Car;
using Unity.VisualScripting;
using Cysharp.Threading.Tasks;
using Niantic.ARDK.Extensions.Meshing;
using Niantic.ARDK.Extensions.Scanning;
using ChallengeTwo.VisualLayer.Menus;

namespace ChallengeTwo.VisualLayer
{
    public class ArSceneManager:MonoBehaviour 
    {
        #region Injects

        //the cars spawner.

        [Inject]
        private CarSpawner _carSpawner;  
        
        //the input provider.

        [Inject]
        private IInputManager _inputManager;

        //the class that manages ar real time meshing features

        [Inject]
        private ARMeshManager _arMeshManager;

        //the class that manages  ARMeshManager ,ARScanManager and the current IScanningmenu ,enable/disables the managers featurs by ui input.
        [Inject]
        private ARScaning _arScanning;

        //the class the manages the all menus.
        [Inject]
        private IMenusManager _menusManager;

        //the class the manages the cars ui(wheel,pedals)
        [Inject]
        private CarUi _carUi;

        //helper debuging class for logging.
        [Inject]
        private Loger _loger;

        //the scaning ui menu.
        [Inject]
        private IScanningMenu _scaningMenu;
        #endregion

        #region Fields
        // a refrence to the ARSession, to know to start features only after the session initialized.
        private IARSession _session;

        //the instance of the spawned car.
        private CarManagerBase _carManager;

        //a flag to know if  the player currently trying to place a car. 
        private bool _placingCar;
       
        #endregion


        #region mathods
        //disables the ARScanning  and subscribes to the sessions init event.
        public void Start()
        {
            _arScanning.enabled=false;
            ARSessionFactory.SessionInitialized -= OnSessionInitialized;
            ARSessionFactory.SessionInitialized += OnSessionInitialized;
        }       
        //caching the session and setting up the scene.
        private void OnSessionInitialized(AnyARSessionInitializedArgs args)
        {
            _session = args.Session;
            Setup();
        }
        //setting screen orientation,enabling scanning menu ui and subscirbing SpawnCarRoutine method to place car event
        private async void Setup()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            _arScanning.enabled = true;            
            await _menusManager.ShowMenu("Scanning");
            _scaningMenu.PlaceClick -= SpawnCarRoutine;
            _scaningMenu.PlaceClick += SpawnCarRoutine;
            _placingCar = false;
        }
        //tries to spawn car  each time player touches screen using car spawner(raycasts) until car is spawned and then hides scanning menu.
        private async void  SpawnCarRoutine()
        {
            if(_placingCar)
            {
                return;
            }
            _placingCar = true;
            if (_carManager != null)
            {
                Destroy(_carManager.gameObject);    
                _carManager = null;
            }
            while (_carManager == null)
            {
                if (_inputManager.IsClicking())
                {

                    _carManager = _carSpawner.TrySpawnCar(50, _inputManager.GetMousePosition());
                    _loger.Log($"_carManager:{_carManager}");
                }
                await UniTask.Yield();
            }
            await _menusManager.HideMenus();
            _carUi.SetActive(true);
            _placingCar = false;
        }      
        #endregion
    }
}
