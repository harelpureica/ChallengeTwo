using ChallengeTwo.DataLayer.Configuration;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    //this class is responsible for animating the simple car.

    public class CarProceduralAnimation: ICarProceduralAnimation
    {
        #region Injections
        // the references for the car parts.
        [Inject]
        private SimpleCarPartsRefrencer _carPart;

        //the settings  needed for CarProceduralAnimation component.

        [Inject]
        private CarProceduralAnimationSettings _settings;

        #endregion

        #region Methods     
        //rotating the wheels based on  the direction of the movement.
        public void AnimateCarWheels(Vector3 direction, Vector3 forwardDirection)
        {
            if (direction == Vector3.zero)
            {
                return;
            }
            for (int i = 0; i < _carPart.FrontWheels.Count; i++)
            {
                var wheel = _carPart.FrontWheels[i];
                var angleFromForward = Vector3.Angle(forwardDirection, direction);
                var angleFromBackwards = Vector3.Angle(-forwardDirection, direction);
                if (angleFromForward < angleFromBackwards)
                {
                    wheel.localEulerAngles += new Vector3(direction.magnitude, 0, 0);
                }
                else
                {
                    wheel.localEulerAngles -= new Vector3(direction.magnitude, 0, 0);
                }
            }
            for (int i = 0; i < _carPart.BackWheels.Count; i++)
            {
                var wheel = _carPart.BackWheels[i];
                var angleFromForward = Vector3.Angle(forwardDirection, direction);
                var angleFromBackwards = Vector3.Angle(-forwardDirection, direction);
                if (angleFromForward < angleFromBackwards)
                {
                    wheel.localEulerAngles += new Vector3(direction.magnitude, 0, 0);
                }
                else
                {
                    wheel.localEulerAngles -= new Vector3(direction.magnitude, 0, 0);
                }
            }
        }

        //adding torque to the body based on the distance from each car corner to the ground.
        public void AnimateCarBody(Rigidbody body)
        {
            for (int i = 0; i < _carPart.Corners.Count; i++)
            {
                var corner = _carPart.Corners[i];
                body.AddForceAtPosition(GetCornerDirectionFromGround(corner, _settings.GroundCheckDistance) * _settings.Bounciness, corner.position, ForceMode.Force);
            }
        }
        
        //gets the distance from a car corner to the ground
        private Vector3 GetCornerDirectionFromGround(Transform corner,float groundCheckDistance)
        {
            if (Physics.Raycast(corner.position, Vector3.down, out var hitDown, groundCheckDistance))
            {
                var direction = hitDown.point - corner.position;
                return direction;
            }
            else if (Physics.Raycast(corner.position, Vector3.up, out var hitUp, groundCheckDistance))
            {
                var direction = hitUp.point - corner.position;
                return direction;

            }
            else
            {
                return Vector3.zero;
            }
        }

       
        #endregion
    }
}
