
using ChallengeTwo.DataLayer.Configuration;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car.Installers
{
    public class CarInstaller:MonoInstaller<CarInstaller>
    {
        //the prefab of the carManager to spawn in
        [SerializeField]
        private CarManagerBase _carManagerPrefab;

        //the car spawner.
        [SerializeField]
        private CarSpawner _carSpawnerInstance;
       
        //binds the factory on the component and the spawner
        public override void InstallBindings()
        {          
            // bind the car factory.
            Container
                .BindFactory<CarManagerBase,CarManagerBase.CarManagerFactory>()
                .FromComponentInNewPrefab(_carManagerPrefab)
                .AsSingle();

            Container
                .Bind<CarSpawner>()
                .FromInstance(_carSpawnerInstance)
                .AsSingle();
            
        }
    }
}
