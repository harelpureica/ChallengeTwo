using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.ReusableComponents.Installers
{
    public class MovementInputInstaller:MonoInstaller<MovementInputInstaller>
    {
        //binds the IMovementInput interface to the  movement input class.
        public override void InstallBindings()
        {
            Container
                .Bind<IMovementInput>()
                .To<MovementInput>()          
                .AsSingle();         
        }
    }
}
