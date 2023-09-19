using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.ReusableComponents.Installers
{
    //this class is responsible for installing the  input for movement component.
    public class MovementInputInstaller:MonoInstaller<MovementInputInstaller>
    {
        //binds the IMovementInput interface to the  movement input class.
        public override void InstallBindings()
        {
            Container
                .Bind<IMovementInput>()
                .To<CarMovementInput>()          
                .AsSingle();         
        }
    }
}
