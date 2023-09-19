using ChallengeTwo.VisualLayer.Car;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.ReusableComponents
{
    //this class is responsible for providing input for movement component.

    public class CarMovementInput : IMovementInput
    {
        #region Injects
        //the cars ui that gets movement input .
        [Inject]
        private CarUi _carUi;
        
        #endregion
        //returns the input from the ui.
        public Vector2 GetInput()
        {

            var inputY = 0f;
            if(_carUi != null)
            {
                if (_carUi.BreakPressed)
                {
                    inputY =-1 ;
                }
                else if (_carUi.GazPressed)
                {
                    inputY =  1;
                }
                else
                {
                    inputY = 0;
                }
            }
           
            var input= new Vector2(_carUi.SteeringHorizontal, inputY);
            return input;             
        }
    }
}
