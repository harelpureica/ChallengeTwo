using UnityEngine;

namespace ChallengeTwo.DataLayer.Configuration
{
    //this class holds the  settings needed for PhysicBasedCarMovement components.
    [CreateAssetMenu(fileName = "PhysicBasedCarMovementSettings", menuName = "Configuration/PhysicBasedCarMovementSettings")]
    public class PhysicBasedCarMovementSettings:ScriptableObject
    {
        #region Fields
        //the force of the motor ,will affects the speed of the car
        [SerializeField]
        private float motorForce;    
        
        //the max angle to rotate the front wheels on the y axis,will affect the steering of the car
        [SerializeField]
        private float maxSteerAngle;

        #endregion

        #region Properties
        public float MotorForce => motorForce;
        public float MaxSteerAngle => maxSteerAngle;

        #endregion
    }
}
