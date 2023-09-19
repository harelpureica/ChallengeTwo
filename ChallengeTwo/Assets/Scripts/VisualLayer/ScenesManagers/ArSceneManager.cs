using ChallengeTwo.InfrastrucutreLayer.Inputs;
using ChallengeTwo.VisualLayer.AR;
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using UnityEngine;
using Zenject;
using ChallengeTwo.VisualLayer.Car;
using Niantic.ARDK.Extensions.Meshing;
using ChallengeTwo.VisualLayer.Menus;
using ChallengeTwo.Infrastructure.Logging;

namespace ChallengeTwo.VisualLayer
{
    //this class is responsible for managing the scene elements.
    public class ArSceneManager:IInitializable 
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
        private ARFeaturesManager _arScanning;

        //the class the manages the all menus.
        [Inject]
        private IMenusManager _menusManager;

        //the class the manages the cars ui(wheel,pedals)
        [Inject]
        private CarUi _carUi;

        //helper debuging class for logging.
        [Inject]
        private TextLogger _loger;

        //the scaning ui menu.
        [Inject]
        private IScanningMenu _scaningMenu;

        //the class that responsible for placing the car on ground.
        [Inject]
        private CarPlacer _carPlacer;
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
        //subscribes to the sessions init event.
        public void Initialize()
        {
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
            await _menusManager.ShowMenu("Scanning");
            _scaningMenu.PlaceClick -= PlaceCarRoutine;
            _scaningMenu.PlaceClick += PlaceCarRoutine;
        }
        // placing the car when user touches the screen and switching to the car's ui.
        private async void PlaceCarRoutine()
        {
            await _carPlacer.SpawnCarRoutine();
            await _menusManager.HideMenus();
            _carUi.SetActive(true);
        }

        #endregion
    }
}
