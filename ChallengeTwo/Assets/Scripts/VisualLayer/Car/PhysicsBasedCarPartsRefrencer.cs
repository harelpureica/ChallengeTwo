using System.Collections.Generic;
using UnityEngine;

namespace ChallengeTwo.VisualLayer.Car
{
    //this class is responsible for getting the physics based car parts such as wheels.
    public class PhysicsBasedCarPartsRefrencer:CarPartsRefrencerBase
    {
        #region Fields      
        //reference to the back wheels colliders.
        [SerializeField]
        private List<WheelCollider> _backWheelsColliders;

        //reference to the front wheels colliders.

        [SerializeField]
        private List<WheelCollider> _frontWheelsColliders;

        #endregion

        #region Properties

        public List<WheelCollider> FrontWheelsColliders => _frontWheelsColliders;

        public List<WheelCollider> BackWheelsColliders => _backWheelsColliders;

        #endregion
    }
}
