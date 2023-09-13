using ChallengeTwo.VisualLayer.AR;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ChallengeTwo.VisualLayer.Menus
{
    public interface IScanningMenu
    {
        #region Events
        //invoked when player Clickes scan button.
        event Action ScanClick;

        //invoked when player Clickes stop scan button.

        event Action StopClick;

        //invoked when player Clickes process button.

        event Action ProcessClick;

        //invoked when player Clickes Visualize button.

        event Action VisualizeClick;

        //invoked when player changes dropdown(scanMode) value .


        event Action<ScanMode> DropDownValueChange;

        //invoked when player Clickes Place car button.

        event Action PlaceClick;

        //invoked when player Clickes toggle meshing button.

        event Action MeshingClick;
        #endregion

        #region Properties
        //the slider for showing scan process progress.
        public Slider ScanSlider { get; }

        #endregion      

    }
}
