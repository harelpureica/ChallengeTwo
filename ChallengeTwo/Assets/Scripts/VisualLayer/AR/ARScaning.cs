using ChallengeTwo.VisualLayer.Menus;
using Niantic.ARDK.AR.Scanning;
using Niantic.ARDK.Extensions.Meshing;
using Niantic.ARDK.Extensions.Scanning;
using System.Diagnostics;
using System;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.AR
{
    public class ARScaning:MonoBehaviour
    {
        #region Injects
        //the manager that provides the manual scanning features.

        [Inject]
        private ARScanManager _arScanManager; 
        
        // loger for debuging.

        [Inject]
        private Loger _loger;

        //the ui menu for manual scaninng and auto real time meshing

        [Inject]
        private IScanningMenu _scanningMenu;

        //the manager that provides the auto real time meshing features.

        [Inject]
        private ARMeshManager _arMeshManager;

        //the material that used by the scaned object meshrenderer(only for manual scanning)

        [Inject(Id ="Scanning")]
        private Material _scanesObjectMaterial;

        #endregion

        #region Fields
        //a flag to know if the player scanned .
        private bool _scanedRecently;

        //a flag to know if the player is currently scanning.

        private bool _scanning;

        //a flag to know if the player is currently processing.


        private bool _processing;

        //a flag to know if the visuals should be on.

        private bool _visualizing=true;

        //a flag to know if the auto real time meshing features should be enabled.

        private bool _meshing=true;

        //the current manual scan result object.

        private GameObject _scanMeshObject;

        //the current manual scan result meshfilter.


        private MeshFilter _scanMeshFilter;

        //the current manual scan result meshrenderer.


        private MeshRenderer _scanMeshRenderer;

        //the current scan mode ,ether auto real time meshing or manual scanning.

        private ScanMode _scanMode = ScanMode.autoRealTimeMeshing;

        #endregion

        #region Methods

        #region Mono
        //subscribes to ui's events and initialize ar features.
        private void Start()
        {                        
            _arMeshManager.Initialize();            
            _arMeshManager.SetUseInvisibleMaterial(false);
            _arScanManager.Initialize();
            _arMeshManager.EnableFeatures();
            _arScanManager.DisableFeatures();
            _arScanManager.ScanProcessed += ScanResultHandler;
            _scanningMenu.ProcessClick += Process;
            _scanningMenu.ScanClick += Scan;
            _scanningMenu.VisualizeClick += ToggleVisualize;
            _scanningMenu.StopClick += StopScan;
            _scanningMenu.DropDownValueChange += SetScanMode;
            _scanningMenu.MeshingClick += ToggleMeshing;
        }

        //unsubscribes to ui's events when application quits.
        private void OnApplicationQuit()
        {
            _scanningMenu.ProcessClick -= Process;
            _scanningMenu.ScanClick -= Scan;
            _scanningMenu.VisualizeClick -= ToggleVisualize;
            _scanningMenu.StopClick -= StopScan;
            _scanningMenu.DropDownValueChange -= SetScanMode;
            _scanningMenu.MeshingClick -= ToggleMeshing;

        }

        //updates process bar if currently processing.
        private void Update()
        {
            IScanner.State state = _arScanManager.ScannerState;

            if (state == IScanner.State.Processing)
            {               
                _scanningMenu.ScanSlider.value = _arScanManager.GetScanProgress();
            }
            
        }
        #endregion

        #region Scaning
        //sets the current scan mode.
        public void SetScanMode(ScanMode scanMode)
        {
            _scanMode = scanMode;
            if(_scanMode==ScanMode.autoRealTimeMeshing)
            {
               
                if(_scanMeshObject!=null)
                {
                    Destroy(_scanMeshObject);
                }
                _arMeshManager.SetUseInvisibleMaterial(false);
                _arMeshManager.EnableFeatures();
                _arScanManager.DisableFeatures();

            }
            else
            {
                _arMeshManager.ClearMeshObjects();
                _arMeshManager.DisableFeatures();
                _arScanManager.EnableFeatures();

            }

        }

        //start manual scanning.
        public void Scan()
        {
            if (_processing||_scanning||_scanMode==ScanMode.autoRealTimeMeshing)
            {
                return;
            }
            _loger.Log("scaning");
            _scanning = true;            
            if(_scanedRecently)
            {
                _arScanManager.Restart();
                _arScanManager.StartScanning();
            }
            else
            {
                _scanedRecently = true;
                _arScanManager.StartScanning();
            }
        }

        //stops manual Scanning.
        public void StopScan()
        {
            if (_processing || !_scanning|| _scanMode == ScanMode.autoRealTimeMeshing)
            {
                return;
            }
            _loger.Log("Stopscaning");            
            _scanning = false;           
            _arScanManager.StopScanning();             
        }

        //start processing manual  scan result.
        public void Process()
        {             
            if (_scanedRecently && !_scanning|| _scanMode != ScanMode.autoRealTimeMeshing)
            {
                _loger.Log("processing");

                _arScanManager.StartProcessing();
                _processing = true;
            }            
        }

        //updates/creates the components needed to render the manual scaning result mesh and sets them up.
        private void ScanResultHandler(IScanner.ScanProcessedArgs args)
        {
            if (args.TexturedMesh == null)
            {
                return;
            }
            var texturedMesh = args.TexturedMesh;
            if (_scanMeshObject == null)
            {
                _scanMeshObject = new GameObject("scanMeshObject");
                _scanMeshObject.transform.position=Vector3.zero; 
                _scanMeshFilter = _scanMeshObject.AddComponent<MeshFilter>();
                _scanMeshRenderer = _scanMeshObject.AddComponent<MeshRenderer>();                
            }
            var meshBoundary = texturedMesh.mesh.bounds;
            _scanMeshObject.transform.localPosition = -1 * meshBoundary.center;
            _scanMeshObject.transform.localScale = Vector3.one / meshBoundary.extents.magnitude;
            _scanMeshFilter.sharedMesh = texturedMesh.mesh;
            if (texturedMesh.texture != null)
            {
                _scanesObjectMaterial.mainTexture = texturedMesh.texture;
            }
            _scanMeshRenderer.material = _scanesObjectMaterial;
          
            _loger.Log("scanResultHandled");
            _processing = false;
            _scanedRecently = false;
        }

        //toggles the visuals ,works in both scan modes
        public void ToggleVisualize()
        {
            _visualizing = !_visualizing;
            _loger.Log($"_visualizing:{_visualizing}"); 
            
            if(_scanMode== ScanMode.autoRealTimeMeshing)
            {
                _arMeshManager.SetUseInvisibleMaterial(!_visualizing);                
            }
            else
            {
                if (_scanMeshRenderer != null)
                {
                    _scanMeshRenderer.enabled = _visualizing;
                }
            }                                            
        }

        //toggles the auto real time meshing features.
        public void ToggleMeshing()
        {
            if(_scanMode!= ScanMode.autoRealTimeMeshing)
            {
                return;
            }
            _meshing = !_meshing;
            _loger.Log($"meshing:{_meshing}");
            if(_meshing)
            {
                _arMeshManager.EnableFeatures();
            }
            else
            {
                _arMeshManager.DisableFeatures();
            }
        }
        #endregion

        #endregion
    }
}
