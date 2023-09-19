using ChallengeTwo.InfrastrucutreLayer.MonoUtils;
using Niantic.ARDK.AR.Scanning;
using Niantic.ARDK.Extensions.Scanning;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.AR
{
    //this class is responsible for manual scanning features.
    public class ManualScanning : IManualScanning
    {        
        #region Injects
        //the manager that provides ardk's area scanning features.

        [Inject]
        private ARScanManager _arScanManager;      

        //the material that used by the scan result meshRenderer.

        [Inject(Id = "Scanning")]
        private Material _scanesObjectMaterial;

        //a service for getting mono methods ,used to destory the scaned object result when clearing the mesh.
        [Inject]
        private MonoService _monoService;
        #endregion

        #region Fields
        //the scan result parent object .
        private GameObject _scanResultObj;

        //the mesh filter of the scan result.
        private MeshFilter _scanResultFilter;

        //the mesh renderer of the scan result.

        private MeshRenderer _scanResultRenderer;

        //the mesh Collider of the scan result.

        private MeshCollider _scanResultCollider;

        //the mesh object that have the rendering components on it ,child of _scanResultObj .

        private GameObject _meshObject;

        #endregion

        #region Properties

        public IScanner.State MyState => _arScanManager.ScannerState;

        #endregion


        #region Methods
        //enables/disables the features.
        public void Enable(bool enabled)
        {
            if(enabled)
            {
                _arScanManager.EnableFeatures();
            }
            else
            {
              
                _arScanManager.DisableFeatures();

            }
        }
        //destroys the scan result object. 
        public void ClearMesh()
        {
            if (_scanResultObj != null)
            {
                _monoService.DestroyGameObject(_scanResultObj);
            }
        }
        //initializes ArMeshManager and subscribes to scan processed event.
        public void Initialize()
        {
            if(!_arScanManager.gameObject.activeInHierarchy) 
             {
                _arScanManager.gameObject.SetActive(true);
            }
            _arScanManager.Initialize();
            _arScanManager.ScanProcessed -= ScanResultHandler;
            _arScanManager.ScanProcessed += ScanResultHandler;
        }
        //updates/creates the components needed to render the manual scanning result mesh and sets them up.
        private void ScanResultHandler(IScanner.ScanProcessedArgs args)
        {
            if (args.TexturedMesh == null)
            {
                return;
            }
            //gets the result mesh and assign it to a newly created gameobject's rendering components  
            var texturedMesh = args.TexturedMesh;
            if (_scanResultObj == null)
            {
                _scanResultObj = new GameObject("scanObject");
                _scanResultObj.transform.position = Vector3.zero;
                _meshObject = new GameObject("meshObject");
                _meshObject.transform.parent = _scanResultObj.transform;
                _scanResultFilter = _meshObject.AddComponent<MeshFilter>();
                _scanResultRenderer = _meshObject.AddComponent<MeshRenderer>();
                _scanResultCollider= _meshObject.AddComponent<MeshCollider>();
            }
            _scanResultFilter.sharedMesh = texturedMesh.mesh;
            _scanResultCollider.sharedMesh = texturedMesh.mesh;            
            var meshBoundary = texturedMesh.mesh.bounds;
            //sets the transform. 
            _meshObject.transform.localPosition =-1 * meshBoundary.center;
            _meshObject.transform.localScale = Vector3.one / meshBoundary.extents.magnitude;
            //sets the result texture to the material used by the _scanResultRenderer 
            if (texturedMesh.texture != null)
            {
                _scanesObjectMaterial.mainTexture = texturedMesh.texture;
            }
            _scanResultRenderer.material = _scanesObjectMaterial; 
        }
        //starts processsing the result of the scan.
        public void Process()
        {
            _arScanManager.StartProcessing();
        }
        //starts scanning .
        public void Scan()
        {            
            _arScanManager.Restart();
            _arScanManager.StartScanning();
        }

        //stops scanning.
        public void StopScan()
        {
            _arScanManager.StopScanning();
        }
        //Sets the scan result renderer enabled/disabled
        public void Visualize(bool visible)
        {
            if(_scanResultRenderer != null)
            {
                _scanResultRenderer.enabled = visible;
            }
        }
        //returns the scan processing progress.
        public float GetProcessingProgress()
        {
            var progress = _arScanManager.GetScanProgress();
            return progress;
        }
        #endregion
    }
}
