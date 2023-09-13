using ChallengeTwo.Infrastructure.Loading;
using ChallengeTwo.InfrastrucutreLayer;
using Cysharp.Threading.Tasks;
using Infrastructure.SceneManaging;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;
using ScenesManager = UnityEngine.SceneManagement.SceneManager;

namespace ChallengeTwo.VisualLayer.StartScreen
{
    public class StartScreenManager :MonoBehaviour
    {
        #region Injects
        //button for starting  transitioning to ar scene.

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
        //time value for checking lights tick time
        private float _time;

        //a value that controlls the time to toggle lights.
        private float _nextTickTime=1f;

        //the  Light Intensity that cached when scene starts.
        private float startLightIntensity;

        //a flag to know if the lights should be on.
        private bool _lightsOn;
        #endregion

        #region Methods
        //sets up the screen and lights and subscribe to ui events.  
        private void Start()
        {
            startLightIntensity = _carLights[0].intensity;
            _startBtn.onClick.AddListener(StartSimulation);
            _quitBtn.onClick.AddListener(Quit);
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        //updates the lights timer and toggles the lights 
        private void Update()
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
        #endregion
    }
}
