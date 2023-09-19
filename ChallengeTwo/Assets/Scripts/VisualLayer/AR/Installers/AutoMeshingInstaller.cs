using Niantic.ARDK.Extensions.Meshing;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.AR.Installers
{
    //this class is responsible for installing AutoMeshing component.

    public class AutoMeshingInstaller:MonoInstaller<AutoMeshingInstaller>
    {
        #region Fields
        //the manager that responsible for auto real time meshing
        [SerializeField]
        private ARMeshManager _arMeshManager;
        #endregion

        #region Methods
        //binds the AutoMeshing component and arMeshManager.
        public override void InstallBindings()
        {
            Container.Bind<ARMeshManager>()
              .FromInstance(_arMeshManager)
              .AsSingle();

            Container
             .Bind<IAutoMeshing>()
             .To<AutoMeshing>()
             .AsSingle();
        }
        #endregion
    }
}
