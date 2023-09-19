using UnityEngine;

namespace ChallengeTwo.DataLayer.Configuration
{
    //this class holds the settings needed for CarProceduralAnimation component.
    [CreateAssetMenu(fileName = "CarProceduralAnimationSettings", menuName = "Configuration/CarProceduralAnimationSettings")]  
    public class CarProceduralAnimationSettings:ScriptableObject
    {
        #region Fields
        //Controls The torque force apllied to each corner of the car,used to simulate bounciness.
        [SerializeField]
        private float _bounciness;

        //the distance to check if the car is grounded.
        [SerializeField]
        private float _groundCheckDistance;
        #endregion

        #region Properties
        public float Bounciness => _bounciness;

        public float GroundCheckDistance => _groundCheckDistance;
        #endregion
    }
}
