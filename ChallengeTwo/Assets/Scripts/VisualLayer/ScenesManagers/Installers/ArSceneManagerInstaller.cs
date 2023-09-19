using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.ScenesManagers.Installers
{
    //this class is responsible for installnig the ar scene manager .

    [CreateAssetMenu (fileName = "ArSceneManagerInstaller", menuName = "Installers/ArSceneManagerInstaller")]
    public class ArSceneManagerInstaller:ScriptableObjectInstaller<ArSceneManagerInstaller>
    {
        #region Methods
        //binds the ar scene manager.
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<ArSceneManager>()
                .AsSingle();

        }
        #endregion
    }
}
