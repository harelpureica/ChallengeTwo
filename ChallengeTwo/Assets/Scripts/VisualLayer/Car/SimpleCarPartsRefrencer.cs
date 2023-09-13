using System.Collections.Generic;
using UnityEngine;

namespace ChallengeTwo.VisualLayer.Car
{
    public class SimpleCarPartsRefrencer:CarPartsRefrencerBase
    {
        #region Fields
        //the corners of the car,used for calculating the torque of the body.
        [SerializeField]
        private List<Transform> _corners  = new();

        #endregion

        #region properties

        public List<Transform> Corners => _corners;

        #endregion
    }
}
