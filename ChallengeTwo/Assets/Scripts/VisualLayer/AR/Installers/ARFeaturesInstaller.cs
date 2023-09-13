using Niantic.ARDK.Extensions.Meshing;
using Niantic.ARDK.Extensions.Scanning;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ChallengeTwo.VisualLayer.AR.Installers
{
    public class ARFeaturesInstaller : MonoInstaller<ARFeaturesInstaller>
    {
        #region Fields
        //the instace of ar mesh manager for real time meshing 
        [SerializeField]
        private ARMeshManager _arMeshManager;

        //the instace of ar Scan manager for manual scaning. 

        [SerializeField]
        private ARScanManager _arScanManager;

        //the instace of ArScaning thats is managing both  manual scaning and auto real time Meshing. 
        [SerializeField]
        private ARScaning _arScanning;

        //the material that used by the scaned object meshrenderer(onlu for manual scanning)

        [SerializeField]
        private Material _scanObjectMaterial;

        #endregion


        #region Methods
        //binds ar features inputs and outputs.
        public override void InstallBindings()
        {           
            Container.Bind<ARMeshManager>()
                .FromInstance(_arMeshManager)
                .AsSingle();

            Container
                .Bind<ARScanManager>()
                .FromInstance(_arScanManager)
                .AsSingle();

            Container
               .Bind<ARScaning>()
               .FromInstance(_arScanning)
               .AsSingle();
            Container
             .Bind<Material>()
             .WithId("Scanning")
             .FromInstance(_scanObjectMaterial)
             .AsTransient();
        }

        #endregion
    }
}
