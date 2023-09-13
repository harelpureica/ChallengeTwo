using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChallengeTwo.VisualLayer.Car
{
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
