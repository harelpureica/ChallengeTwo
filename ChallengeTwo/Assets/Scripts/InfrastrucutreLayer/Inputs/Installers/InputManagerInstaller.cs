using Zenject;
using UnityEngine;

namespace ChallengeTwo.InfrastrucutreLayer.Inputs.Installers
{
    //this class is responsible for installing inputManager .
    [CreateAssetMenu(fileName = "InputManagerInstaller",menuName = "Installers/InputManagerInstaller")]
    public class InputManagerInstaller:ScriptableObjectInstaller<InputManagerInstaller>
    {
        #region Methods
        // bind iinputManager interface to inputManager in the scene context.
        public override void InstallBindings()
        {
            Container
                .Bind<IInputManager>()
                .To<InputManager>()
                .AsSingle();         
        }
        #endregion
    }
}
