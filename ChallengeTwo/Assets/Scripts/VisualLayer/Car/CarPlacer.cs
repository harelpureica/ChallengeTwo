
using ChallengeTwo.Infrastructure.Logging;
using ChallengeTwo.InfrastrucutreLayer.Inputs;
using ChallengeTwo.InfrastrucutreLayer.MonoUtils;
using Cysharp.Threading.Tasks;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    //this class is responsible for placing the car in the scene.
    public class CarPlacer
    {
        #region Injects
        //a service that provides mono functions (instantiate,destroy etc...),used to destroy the old car when placing a new car 
        [Inject]
        private MonoService _monoService;

        //the spawner of the car,spawns the car using the car factory.
        [Inject]
        private CarSpawner _spawner;

        //the input provider.
        [Inject]
        private IInputManager _inputManager;

        //helper debug class for displaying text in run time.
        [Inject]
        private TextLogger _textLogger;
        
        //the cars ui gets input from steering Wheel and pedals buttons.
        [Inject]
        private CarUi _carUi;

        #endregion

        #region Fields

        private bool _placingCar;

        private CarManagerBase _carManager;

        #endregion

        //tries to spawn a car  each time player touches screen using car spawner(raycasts) until car is spawned and then hides scanning menu.
        public async UniTask SpawnCarRoutine()
        {
            if (_placingCar)
            {
                return;
            }
            _placingCar = true;
            if (_carManager != null)
            {
                _monoService.DestroyGameObject(_carManager.gameObject);
                _carManager = null;
            }
            _textLogger.Log($"tap to place car");
            while (_carManager == null)
            {
                if (_inputManager.IsClicking())
                {

                    _carManager = _spawner.TrySpawnCar(50, _inputManager.GetMousePosition());
                    if (_carManager == null)
                    {
                        _textLogger.Log($"failed to Spawn car try again");
                    }
                }
                await UniTask.Yield();
            }

            _textLogger.Log($"carSpawned");          
            _placingCar = false;
        }
    }
}
