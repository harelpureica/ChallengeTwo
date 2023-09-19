

using ChallengeTwo.DataLayer.Configuration;
using ChallengeTwo.VisualLayer.ReusableComponents;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car.Installers
{
    //this class is responsible for installing the needed bindings for moving the car based on physics.

    public class PhysicsBasedMovementInstaller:MonoInstaller<PhysicsBasedMovementInstaller>
    {
        #region Field
        //a class that refrence parts of the physics based car ,wheels etc..

        [SerializeField]
        private PhysicsBasedCarPartsRefrencer _refencer;

        //the settings needed for physics based car movement .
        [SerializeField]
        private PhysicBasedCarMovementSettings _settings;
        #endregion

        #region Methods
        //binds the needed inputs and outputs for physics based car movement
        public override void InstallBindings()
        {
            Container
                .Bind<PhysicBasedCarMovementSettings>()
                .FromInstance(_settings)
                .AsSingle();

            Container
               .Bind<PhysicsBasedCarPartsRefrencer>()
               .FromInstance(_refencer)
               .AsSingle();

            Container
                .Bind<IMoveByInput>()
                .To<PhysicsBasedCarMovement>()
                .AsSingle();
        }
        #endregion
    }
}
