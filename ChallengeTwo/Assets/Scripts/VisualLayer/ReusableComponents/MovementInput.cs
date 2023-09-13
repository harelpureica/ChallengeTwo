using ChallengeTwo.InfrastrucutreLayer.Inputs;
using ChallengeTwo.VisualLayer.Car;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.ReusableComponents
{
    public class MovementInput : IMovementInput
    {
        #region Injects
        //the cars ui that gets movement input .
        [Inject]
        private CarUi _carUiInput;
        
        #endregion
        //returns the input from the ui.
        public Vector2 GetInput()
        {

            var inputY = 0;
            if(_carUiInput != null)
            {
                if (_carUiInput.BreakPressed)
                {
                    inputY = -1;
                }
                else if (_carUiInput.GazPressed)
                {
                    inputY = 1;
                }
                else
                {
                    inputY = 0;
                }
            }
           
            var input= new Vector2(_carUiInput.SteeringHorizontal, inputY);
            return input;             
        }
    }
}
