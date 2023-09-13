using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ChallengeTwo.VisualLayer.StartScreen.Installers
{
    public class StartScreenInstaller:MonoInstaller<StartScreenInstaller>
    {
        #region Fields
        //button for transitioning to ar scene.
        [SerializeField]
        private Button _startBtn;

        //button for quiting the app

        [SerializeField]
        private Button _quitBtn;

        //the cameras animator for trigering its animation on start click.
        
        [SerializeField]
        private Animator _cameraAnimator;

        //the cars animator for trigering its animation on start click.

        [SerializeField]
        private Animator _carAnimator;

        //the cars lights for vfx.
        [SerializeField]
        private List<Light> _carLights;      

        #endregion
        
        #region Methods
        //binds all inputs and outputs needed for start screen.
        public override void InstallBindings()
        {
            Container
                .Bind<Button>()
                .WithId("Start")
                .FromInstance(_startBtn)
                .AsTransient();

            Container
               .Bind<Button>()
               .WithId("Quit")
               .FromInstance(_quitBtn)
               .AsTransient();

            Container
               .Bind<Animator>()
               .WithId("Car")
               .FromInstance(_carAnimator)
               .AsTransient();

            Container
               .Bind<Animator>()
               .WithId("Camera")
               .FromInstance(_cameraAnimator)
               .AsTransient();

            Container
              .Bind<List<Light>>()              
              .FromInstance(_carLights)
              .AsSingle();
        }
        #endregion
    }
}
