using ChallengeTwo.DataLayer.Configuration;
using ChallengeTwo.VisualLayer.Car;
using ChallengeTwo.VisualLayer.ReusableComponents;
using ChallengeTwo.VisualLayer.ReusableCopmponents;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car.Installers
{
    public class SimpleMovementInstaller:MonoInstaller<SimpleMovementInstaller>
    {
        #region Fields
        //the settings for the simple car movement component. 
        [SerializeField]
        private MovementSettings movementSettings;
      
        #endregion
        //binds the input and outputs needed for simple car movement component.
        public override void InstallBindings()
        {
            //bind settings.
            Container
                .Bind<MovementSettings>()
                .WithId("Movement")
                .FromInstance(movementSettings)
                .AsSingle();
            //bind IMoveByInput to Component            
            Container
               .Bind<IMoveByInput>()               
               .To<SimpleCarMovement>()
               .AsSingle();            

        }
    }
}
