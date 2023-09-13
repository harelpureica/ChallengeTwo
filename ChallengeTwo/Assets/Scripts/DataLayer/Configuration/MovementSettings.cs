using UnityEngine;

namespace ChallengeTwo.DataLayer.Configuration
{
    [CreateAssetMenu(menuName = "Configuration/MovementSettings", fileName = "MovementSettings")]
    public class MovementSettings : ScriptableObject
    {
        #region Fields

        //Controlls the rigidbody movement speed.
        [SerializeField]
        private float maxSpeed;

        //Controlls the rigidbody rotation speed.
        [SerializeField]
        private float rotationSpeed;

        //controlls the time it takes to get to max speed.
        [SerializeField]
        private float acceleration;

        //The distance to detect ground.
        [SerializeField]
        private float groundCheckDistance;

        //The layer  for ground detection.
        [SerializeField]
        private LayerMask groundLayer;

        //the amount to rotate 
        [SerializeField]
        private float rotationAngle;

        #endregion

        #region Properties

        public float MaxSpeed => maxSpeed;
        public float Acceleration => acceleration;
        public LayerMask GroundLayer => groundLayer;
        public float  GroundCheckDistance =>groundCheckDistance;
        public float RotationSpeed => rotationSpeed;        
        public float RotationAngle=> rotationAngle;

        #endregion
    }
}
