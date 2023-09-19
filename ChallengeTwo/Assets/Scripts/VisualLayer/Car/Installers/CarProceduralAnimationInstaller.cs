using ChallengeTwo.VisualLayer.Car;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.DataLayer.Configuration
{
    //this class is responsible for installing the needed bindings for animating the simple car.
    public class CarProceduralAnimationInstaller:MonoInstaller
    {
        #region Fields
        //the settings for the Cars Procedural Animation component.
        [SerializeField]
        private CarProceduralAnimationSettings _settings;
        #endregion

        #region Methods
        //binds the inputs/outputs needed for the simple Cars Procedural Animation.
        public override void InstallBindings()
        {
            var refencer = GetComponent<SimpleCarPartsRefrencer>();
            Container.Bind<SimpleCarPartsRefrencer>()
                .FromInstance(refencer)
                .AsSingle();           

            Container.Bind<CarProceduralAnimationSettings>()
              .FromInstance(_settings)
              .AsSingle();

            Container.Bind<ICarProceduralAnimation>()
             .To<CarProceduralAnimation>()
             .AsSingle();
        }
        #endregion
    }
}
