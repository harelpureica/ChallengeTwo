using ChallengeTwo.VisualLayer.ReusableComponents;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    [RequireComponent(typeof(Rigidbody))]
    public class SimpleCarManager : CarManagerBase
    {
        #region Fields   

        // a reference to the simple Cars procedural Animaton component

        [Inject]
        private ICarProceduralAnimation _proceduralAnimaton;

        #endregion

        #region Methods  
        //using base class method to move the car.
        //tells the procedural Animaton component to animate the cars wheels and body based on velocity.
        protected override void Update()
        {
            base.Update();        
            _proceduralAnimaton.AnimateCarBody(_rb);
            _proceduralAnimaton.AnimateCarWheels(_rb.velocity, transform.forward);
        }       
        #endregion
    }
}
