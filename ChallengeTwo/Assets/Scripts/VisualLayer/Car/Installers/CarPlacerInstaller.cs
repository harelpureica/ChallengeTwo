using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car.Installers
{
    //this class installs the bindings needed for placing the car in the scene
    [CreateAssetMenu(fileName = "CarPlacerInstaller", menuName ="Installers/CarPlacerInstaller")]
    public class CarPlacerInstaller:ScriptableObjectInstaller<CarPlacerInstaller>
    {

        #region Methods
        //installs car placer bindings.
        public override void InstallBindings()
        {
            Container
                .Bind<CarPlacer>()
                .AsSingle();
        }
        #endregion
    }
}
