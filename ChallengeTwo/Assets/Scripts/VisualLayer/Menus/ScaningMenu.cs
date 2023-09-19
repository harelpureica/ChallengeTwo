using ChallengeTwo.VisualLayer.AR;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
namespace ChallengeTwo.VisualLayer.Menus
{
   //this class is responsible providing scanning related ui events.
    public class ScaningMenu :MenuBase ,IScanningMenu
    {
        #region Fields
        //button  for activating scanning .

        [SerializeField]
        private Button _scanButton;

        //button  for activating scan result  process .

        [SerializeField]
        private Button _processButton;

        //button  for stoping the scan .

        [SerializeField]
        private Button _stopScanButton;

        //button  for toggling the visuals ,works in both scan modes.

        [SerializeField]
        private Button _visualizeButton;

        // dropdown for selecting scan mode.

        [SerializeField]
        private TMP_Dropdown _scanModeDropdown;

        // a slider for displating the current scan process progress

        [SerializeField]
        private Slider _scanSlider;

        // the button for placing the car 

        [SerializeField]
        private Button _placeButton;

        // the button for toggling the   auto real time meshing features 

        [SerializeField]
        private Button _meshingButton;

        #endregion

        #region Events       

        public event Action ScanClick;

        public event Action StopClick;

        public event Action ProcessClick;

        public event Action VisualizeClick;

        public event Action<ScanMode> DropDownValueChange;

        public event Action PlaceClick;

        public event Action MeshingClick;

        #endregion

        #region Properties
        public override string MenuName => "Scanning";

        public Slider ScanSlider => _scanSlider;
        #endregion

        #region Methods
        //subscribes  methods to buttons on clicks events and sets the dropdown values
        private void Start()
        {
            _placeButton.onClick.AddListener(OnPlaceClick);
            _scanModeDropdown.onValueChanged.AddListener(OnDropDownValueChange);
            _scanButton.onClick.AddListener(OnScanClick);
            _stopScanButton.onClick.AddListener(OnStopClick);
            _processButton.onClick.AddListener(OnProcessClick);
            _visualizeButton.onClick.AddListener(OnVisualizeClick);
            _meshingButton.onClick.AddListener(OnMeshingClick);
            _scanModeDropdown.ClearOptions();
            _scanModeDropdown.AddOptions(new List<string> { "autoRealTimeMeshing", "manualScaning" });

        }

        private void OnMeshingClick()
        {
            MeshingClick?.Invoke();
        }

        public void OnScanClick()
        {
            ScanClick?.Invoke();
        }
        public void OnStopClick()
        {
            StopClick?.Invoke();
        }
        public void OnProcessClick()
        {
            ProcessClick?.Invoke();
        }
        public void OnPlaceClick()
        {
           PlaceClick?.Invoke();
        }
        public void OnVisualizeClick()
        {
            VisualizeClick?.Invoke();
        }
        public void OnDropDownValueChange(int index)
        {
            switch(index)
            {
                case 0:
                    DropDownValueChange?.Invoke(ScanMode.autoRealTimeMeshing);
                    break;

                case 1:
                    DropDownValueChange?.Invoke(ScanMode.manualScaning);
                    break;
            }
        }
        #endregion
    }
}
