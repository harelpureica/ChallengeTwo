using ChallengeTwo.InfrastrucutreLayer.Inputs;
using ChallengeTwo.VisualLayer.Menus;
using ChallengeTwo.VisualLayer.UIUtils;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    public class CarUi 
    {
        #region Injections      
        //the holding button for checking if player is pressing the acceleration ui(gaz).
        [Inject(Id ="Gaz")]
        private HoldingButton _gazPedalBtn;

        //the holding button for checking if player is pressing the breakes/reverse ui.

        [Inject(Id = "Breakes")]
        private HoldingButton _breakesPedalBtn;

        //the steering wheels ui  for input.
        [Inject]
        private CarSteeringWheel _wheel;

        //the parent panel  of the  ui elements.

        [Inject(Id ="UiParent")]
        private GameObject _uiParent;

        #endregion      

        #region Propertis
        public bool GazPressed => _gazPedalBtn.IsPressed;

        public bool BreakPressed => _breakesPedalBtn.IsPressed;

        public float SteeringHorizontal=>_wheel.HorizontalInput;
        #endregion

        #region Methods 
        //sets the ui active.
        public void SetActive(bool active)
        {
            _uiParent.SetActive(active);
        }
        #endregion
    }
}
