
using System.Collections.Generic;
using UnityEngine;

namespace ChallengeTwo.VisualLayer.Car
{
    public interface ICarProceduralAnimation
    {
        #region Methods
        //animates the car body .
        void AnimateCarBody(Rigidbody carbody);

        //animate the car wheels based on the velocity and direction.
        void AnimateCarWheels(Vector3 velocity, Vector3 forwardDirection);
        #endregion
    }
}
