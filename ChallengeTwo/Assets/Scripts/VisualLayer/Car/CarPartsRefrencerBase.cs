﻿using System.Collections.Generic;
using UnityEngine;

namespace ChallengeTwo.VisualLayer.Car
{
    //this class is responsible for geting a refrence to the car parts such as the wheels.
    public abstract class CarPartsRefrencerBase:MonoBehaviour
    {
        #region Fields
        // the transforms of the front wheels.
        [SerializeField]
        protected List<Transform> _frontWheels;

        // the transforms of the back wheels.

        [SerializeField]
        protected List<Transform> _backWheels;

        #endregion

        #region Properties
        public List<Transform> FrontWheels => _frontWheels;

        public List<Transform> BackWheels => _backWheels;

        #endregion
    }
}
