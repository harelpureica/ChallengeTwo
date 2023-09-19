using ChallengeTwo.DataLayer.Configuration;
using ChallengeTwo.InfrastrucutreLayer.Inputs;
using ChallengeTwo.VisualLayer.Car;
using ChallengeTwo.VisualLayer.ReusableComponents;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    //this class is responsible for moving the physics based car.

    public class PhysicsBasedCarMovement:IMoveByInput
    {

        #region Injects       
        // the Settings needed for Physic Based car movement .
        [Inject]
        private PhysicBasedCarMovementSettings _settings;

        //holds the refernces for the physics cars parts.
        [Inject]
        private PhysicsBasedCarPartsRefrencer _refrencer;

        #endregion

        #region Methods                   
        //moves and handles steering of the car based on input.
        public void Move(Vector2 input, Rigidbody body)
        {
            HandleMotor(input);
            HandleSteering(input);
            UpdateWheels();
        }
        //setting torque to the back wheels  based on input .
        private void HandleMotor(Vector2 input)
        {
            for (int i = 0; i < _refrencer.BackWheelsColliders.Count; i++)
            {
                _refrencer.BackWheelsColliders[i].motorTorque = input.y * _settings.MotorForce;
            }                      
        }
        //steers the car by rotating the front wheels based on input.
        private void HandleSteering(Vector2 input)
        {
            var steeringAngle = _settings.MaxSteerAngle * input.x;
            for (int i = 0; i < _refrencer.FrontWheelsColliders.Count; i++)
            {
                _refrencer.FrontWheelsColliders[i].steerAngle = steeringAngle;
            }
        }
        //updates the wheels positions and rotations.
        private void UpdateWheels()
        {
            for (int i = 0; i < _refrencer.FrontWheelsColliders.Count; i++)
            {
                Vector3 pos;
                Quaternion rot;
                _refrencer.FrontWheelsColliders[i].GetWorldPose(out pos, out rot);
                _refrencer.FrontWheels[i].rotation = rot;
                _refrencer.FrontWheels[i].position = pos;
            }
            for (int i = 0; i < _refrencer.BackWheelsColliders.Count; i++)
            {
                Vector3 pos;
                Quaternion rot;
                _refrencer.BackWheelsColliders[i].GetWorldPose(out pos, out rot);
                _refrencer.BackWheels[i].rotation = rot;
                _refrencer.BackWheels[i].position = pos;
            }
        }

       
        #endregion
    }
}
