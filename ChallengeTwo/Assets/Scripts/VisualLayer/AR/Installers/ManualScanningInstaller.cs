using Niantic.ARDK.Extensions.Scanning;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.AR.Installers
{
    //this class is responsible for installing manualScanning.

    public class ManualScanningInstaller:MonoInstaller<ManualScanningInstaller>
    {
        #region Fields
        //The material that is used by the _scanResult mesh renderer;
        [SerializeField]
        private Material _scanObjectMaterial;

        //The manager that is responsible for manual scanning features.

        [SerializeField]
        private ARScanManager _arScanManager;
        #endregion

        #region Methods
        //binds the  inputs and outputs needed for manual scaning.
        public override void InstallBindings()
        {
            Container
            .Bind<Material>()
            .WithId("Scanning")
            .FromInstance(_scanObjectMaterial)
            .AsTransient();

            Container
            .Bind<ARScanManager>()
              .FromInstance(_arScanManager)
              .AsSingle();

            Container
             .Bind<IManualScanning>()
             .To<ManualScanning>()
             .AsSingle();
        }
        #endregion
    }
}
