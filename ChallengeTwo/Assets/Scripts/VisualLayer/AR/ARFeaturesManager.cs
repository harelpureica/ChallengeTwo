using ChallengeTwo.Infrastructure.Logging;
using ChallengeTwo.InfrastrucutreLayer.MonoUtils;
using ChallengeTwo.InfrastrucutreLayer.TimeManaging;
using ChallengeTwo.VisualLayer.Menus;
using Niantic.ARDK.AR.Scanning;
using Zenject;

namespace ChallengeTwo.VisualLayer.AR
{
    //this class is responsible for managing ar features and connecting them with ui events.

    public class ARFeaturesManager:IInitializable
    {

        #region Injects           
        
        // logger for debuging.

        [Inject]
        private TextLogger _loger;

        //the ui menu for both manual scaninng and auto real time meshing.

        [Inject]
        private IScanningMenu _scanningMenu;

        //the  component that is responsible  for auto meshing .

        [Inject]
        private IAutoMeshing _autoMeshing;

        //the  component that is responsible  for Manual meshing .

        [Inject]
        private IManualScanning _manualScanning;

        //the time manager that holds the timed related events.
        [Inject]
        private ITimeManager _timeManager;

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
       
        //the current scan mode ,ether auto real time meshing or manual scanning.

        private ScanMode _scanMode = ScanMode.autoRealTimeMeshing;       

        #endregion

        #region Methods
       
        //subscribes to ui's events and initializes ar features.
        public void Initialize()
        {
            //Initializing and enabling Features.
            _autoMeshing.Initialize();
            _manualScanning.Initialize();
            _autoMeshing.Enable(true);
            _manualScanning.Enable(false);
            //subscribing to ui events.
            _scanningMenu.ProcessClick += Process;
            _scanningMenu.ScanClick += Scan;
            _scanningMenu.VisualizeClick += ToggleVisualize;
            _scanningMenu.StopClick += StopScan;
            _scanningMenu.DropDownValueChange += SetScanMode;
            _scanningMenu.MeshingClick += ToggleMeshing;
            _timeManager.OnTick -= Tick;
            _timeManager.OnTick += Tick;
        }      

        //updates process bar  every frame if currently processing.
        public void Tick()
        {           
            if (_manualScanning.MyState == IScanner.State.Processing)
            {               
                _scanningMenu.ScanSlider.value = _manualScanning.GetProcessingProgress();
            }
        }

        //sets the current scan mode and enables/disables ar features.
        public void SetScanMode(ScanMode scanMode)
        {
            _scanMode = scanMode;
            if(_scanMode==ScanMode.autoRealTimeMeshing)
            {                             
                _autoMeshing.Enable(true);
                _autoMeshing.Visualize(true);
                _manualScanning.ClearMesh();
                _manualScanning.Enable(false);
            }
            else
            {
                _autoMeshing.ClearMesh();
                _autoMeshing.Enable(false);
                _manualScanning.Enable(true);
            }

        }

        //start manual scanning.
        public void Scan()
        {
            if (_processing||_scanning||_scanMode==ScanMode.autoRealTimeMeshing)
            {
                return;
            }
            _manualScanning.Scan();
            _loger.Log("scanning");
            _scanning = true;
        }

        //stops manual Scanning.
        public void StopScan()
        {
            if (_processing || !_scanning|| _scanMode == ScanMode.autoRealTimeMeshing)
            {
                return;
            }
            _manualScanning.StopScan();
            _loger.Log("Stopscaning");            
            _scanning = false;
            _scanedRecently = true;
        }

        //start processing manual  scan result.
        public void Process()
        {             
            if (_scanedRecently && !_scanning|| _scanMode != ScanMode.autoRealTimeMeshing)
            {
                _loger.Log("processing");
                _manualScanning.Process();
                _processing = true;
                _scanedRecently = false;
            }            
        }
        
        //toggles the visuals ,works in both scan modes
        public void ToggleVisualize()
        {
            _visualizing = !_visualizing;
            _loger.Log($"_visualizing:{_visualizing}"); 
            
            if(_scanMode== ScanMode.autoRealTimeMeshing)
            {
                _autoMeshing.Visualize(_visualizing);
            }
            else
            {
               _manualScanning.Visualize(_visualizing);
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
            _autoMeshing.Enable(_meshing);          
        }             

        #endregion
    }
}
