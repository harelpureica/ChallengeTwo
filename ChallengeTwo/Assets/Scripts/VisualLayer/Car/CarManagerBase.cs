using ChallengeTwo.VisualLayer.ReusableComponents;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    //this class is responsible for managing the car components.

    [RequireComponent(typeof(Rigidbody))]
    public abstract class CarManagerBase:MonoBehaviour
    {
        #region Injects

        //the movement input component. 

        [Inject]
        protected IMovementInput _input;

        //the movement component. 

        [Inject]
        protected IMoveByInput _movement;
        #endregion

        #region Factory

        //a  factory for dynamicly creating CarManagerBase instances.
        public class CarManagerFactory : PlaceholderFactory<CarManagerBase>
        {
        }
        #endregion

        #region Fields

        //the rigidbody of the car.

        protected Rigidbody _rb;
        #endregion

        #region Methods
        #region Mono
        //caching the rigigdbody.
        protected virtual void Start()
        {
            _rb=GetComponent<Rigidbody>();
        }

        //moving the rigidBody by input.
        protected virtual void Update()
        {
            _movement.Move(_input.GetInput(),_rb);
        }
        #endregion
        #endregion
    }
}
