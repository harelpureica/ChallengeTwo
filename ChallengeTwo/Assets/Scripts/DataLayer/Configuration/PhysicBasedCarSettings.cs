using UnityEngine;

namespace ChallengeTwo.DataLayer.Configuration
{
    [CreateAssetMenu(fileName = "PhysicBasedCarSettings", menuName = "Configuration/PhysicBasedCarSettings")]
    public class PhysicBasedCarSettings:ScriptableObject
    {
        #region Fields
        //the force of the motor ,will affects the speed of the car
        [SerializeField]
        private float motorForce;       
        //the amount to rotate the wheels
        [SerializeField]
        private float maxSteerAngle;

        #endregion

        #region Properties
        public float MotorForce => motorForce;
        public float MaxSteerAngle => maxSteerAngle;

        #endregion
    }
}
