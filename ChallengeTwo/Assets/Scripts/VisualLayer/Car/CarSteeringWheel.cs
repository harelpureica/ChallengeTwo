using ChallengeTwo.InfrastrucutreLayer.Inputs;
using ChallengeTwo.VisualLayer.UIUtils;
using ModestTree;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    public class CarSteeringWheel:MonoBehaviour
    {
        #region Injections
        //the input provider.
        [Inject]
        private IInputManager _inputManager;

        //the holding button for the steering wheel,used to check if player still holding the wheels ui.

        [Inject(Id ="SteeringWheelButton")]
        private HoldingButton _holdingButton;

        //the center position of the wheel.

        [Inject(Id = "SteeringWheelCenter")]
        private RectTransform _center;
        #endregion

        #region Fields
        // the result input.
        private float _horiznotalInput;

        #endregion

        #region Properties
        public float HorizontalInput => _horiznotalInput;

        #endregion

        #region Methods
        //updates the input result based on the distance from the players touch to the center of the wheels ui.
        private void Update()
        {
            if(_holdingButton.IsPressed)
            {
                var touchPosition = _inputManager.GetNearestTouchPosition((Vector2)_center.position);
                var direction = touchPosition - new Vector2( _center.position.x,_center.position.y);
                var extent = (_center.sizeDelta.x / 2);
                var lerp =  direction.x/extent;
                _horiznotalInput = Mathf.Clamp(lerp,-1,1);
                var angle=Mathf.Clamp(_horiznotalInput * 180,-180,180);
                _center.eulerAngles = new Vector3(0, 0, -angle);

            }else
            {
                _horiznotalInput = 0;
                _center.eulerAngles = Vector3.zero;
            }
        }
      
        #endregion

    }
}
