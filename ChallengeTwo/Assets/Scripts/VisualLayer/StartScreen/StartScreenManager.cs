using ChallengeTwo.InfrastrucutreLayer.Permissions;
using ChallengeTwo.InfrastrucutreLayer.SceneManaging;
using ChallengeTwo.InfrastrucutreLayer.TimeManaging;
using Cysharp.Threading.Tasks;
using Infrastructure.SceneManaging;
using Niantic.ARDK.Utilities.Permissions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ChallengeTwo.VisualLayer.StartScreen
{
    //this class is responsible for managing the start scene and transition to ar scene.

    public class StartScreenManager :IInitializable
    {
        // caching  timeManager and subscribing to OnTick event. 

        [Inject]
        public StartScreenManager(ITimeManager timeManager)
        {
            _timeManager = timeManager;           
            _timeManager.OnTick -= Tick;
            _timeManager.OnTick += Tick;
        }
        #region Injects

        //the class that is responsible for requesting  permissions for androids phones(such as camera and storage).
        [Inject]
        private AndroidPermissions _permissions;

        //button for starting  transition to ar scene.

        [Inject(Id = "Start")]
        private Button _startBtn;

        //button for quiting the app.

        [Inject(Id ="Quit")]
        private Button _quitBtn;

        //cameras animator for trigering its animations on start click.

        [Inject(Id ="Camera")] 
        private Animator _cameraAnimator ;

        //cars animator for trigering its animations on start click.

        [Inject(Id ="Car")]
        private Animator _carAnimator;

        //car lights for toggling light as vfx.

        [Inject]
        private List<Light> _carLights;

        #endregion

        #region Fields
        // the timeManager the holds the time related events(tick,fixedTick etc..)

        private ITimeManager _timeManager;

        //time value for checking lights tick time.

        private float _time;

        //a value that controlls the time to toggle lights.

        private float _nextTickTime=1f;

        //the  Light Intensity that cached when scene starts.

        private float startLightIntensity;

        //a flag to know if the lights should be on.

        private bool _lightsOn;
        #endregion

        #region Methods
        //updates the lights timer and toggles the lights 
        private void Tick()
        {
            _time += Time.deltaTime;
            if(_time>_nextTickTime)
            {
                _time = 0;
                _nextTickTime = UnityEngine.Random.Range(0.01f, 0.5f);
                _lightsOn = !_lightsOn;
                ToggleCarLights(_lightsOn);
            }
        }
        // toggles the lights by setting the  intensity.
        private void ToggleCarLights(bool active)
        {
            if(active)
            {
                for (int i = 0; i < _carLights.Count; i++)
                {
                    _carLights[i].intensity = startLightIntensity;
                }                     
            }
            else
            {
                for (int i = 0; i < _carLights.Count; i++)
                {
                    _carLights[i].intensity = 0;
                }
            }
        }
        //triggers the animations and transition to ar scene.
        public async void StartSimulation()
        {
            _startBtn.interactable = false;
            _carAnimator.SetTrigger("Enter");
            await UniTask.Delay(1000);
            _cameraAnimator.SetTrigger("Enter");
            await UniTask.Delay(5000);
            SceneLoader.LoadSceneWithLoadingScreenAsync(ScenesNames.ARSceneName, ScenesNames.StartSceneName);
        }      

        //quits the app.
        public void Quit()
        {
            Application.Quit();
        }
        //setting up the lights, gettings camera permission  and subscribing to ui events.
        public async void Initialize()
        {         
            startLightIntensity = _carLights[0].intensity;
            var granted=await _permissions.RequestCameraPermissionsAsync();
            if(granted)
            {
                _startBtn.gameObject.SetActive(true);
                _quitBtn.gameObject.SetActive(true);
                _startBtn.onClick.AddListener(StartSimulation);
                _quitBtn.onClick.AddListener(Quit);
            }else
            {
                Quit();
            }
           
        }
        #endregion
    }
}
