using ChallengeTwo.InfrastrucutreLayer.Inputs;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace ChallengeTwo.VisualLayer.UIUtils
{
    [RequireComponent(typeof(RectTransform))]
    public class HoldingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Fields
        // a flag to know if the button is pressed.
        private bool _isPressed = false;
        #endregion

        #region Properties

        public bool IsPressed => _isPressed;

        #endregion

        #region Methods
        //sets the flag true when player press the button.
        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }
        //sets the flag false when player release his touch from the button.

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }
        #endregion

    }
}
