using ChallengeTwo.DataLayer.Configuration;
using ChallengeTwo.VisualLayer.ReusableComponents;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.ReusableCopmponents
{
    //base class for physics based movement components to inherit from.

    [RequireComponent(typeof(Rigidbody))]
    public abstract class MovementBase : IMoveByInput
    {
        #region Injects
        //the settings needed for movement.
        [Inject(Id ="Movement")]
        protected MovementSettings _settings;

        #endregion      

        #region Methods  
        // moves the rigidbody by players input.
        public abstract void Move(Vector2 input, Rigidbody body);       

        #endregion
    }
}
