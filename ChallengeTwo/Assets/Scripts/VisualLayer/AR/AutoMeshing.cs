using ChallengeTwo.VisualLayer.AR;
using Niantic.ARDK.Extensions.Meshing;
using System;
using Zenject;

namespace ChallengeTwo.VisualLayer.AR
{
    //this class is responsible for auto real time meshing features

    public class AutoMeshing : IAutoMeshing
    {
        #region Injects

        //the manager that provides the auto real time meshing features.

        [Inject]
        private ARMeshManager _arMeshManager;

        #endregion      

        #region Methods
        //destroys the mesh objects.
        public void ClearMesh()
        {
            _arMeshManager.ClearMeshObjects();
        }

        //enables/disables the feature.
        public void Enable(bool enabled)
        {
            if(enabled)
            {
                _arMeshManager.EnableFeatures();

            }else
            {
                _arMeshManager.DisableFeatures();
            }
        }
        //Initializes the feature.
        public void Initialize()
        {
            if(!_arMeshManager.gameObject.activeInHierarchy)
            {
                _arMeshManager.gameObject.SetActive(true); 
            }
            _arMeshManager.Initialize();
        }
       //sets the visuals visible/invisible.
        public void Visualize(bool visible)
        {
            _arMeshManager.SetUseInvisibleMaterial(!visible);
        }

        #endregion
    }
}
