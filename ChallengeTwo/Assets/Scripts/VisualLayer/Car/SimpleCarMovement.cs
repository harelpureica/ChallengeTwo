using ChallengeTwo.VisualLayer.ReusableCopmponents;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    public class SimpleCarMovement : MovementBase
    {
        //moves and rotates the rigidbody based  on input,
        //the  slope direction is calculated by projecting the movement direction on the grounds normal.
        public override void Move(Vector2 input, Rigidbody body)
        {
            //Preform a raycast towards the ground.
            if (Physics.Raycast((body.position + body.transform.up),-body.transform.up, out var hit, _settings.GroundCheckDistance, _settings.GroundLayer))
            {
                //calculate local direction from input.
                var moveDirection = body.transform.forward * input.y;
                //Align direction with slopes.
                var slopeDirection = Vector3.ProjectOnPlane(moveDirection, hit.normal);
                //Checks if input is valide.
                if (input != Vector2.zero)
                {
                    //Rotate body on y axis.
                    var wantedRotation = Quaternion.Euler(body.rotation.eulerAngles + new Vector3(0, _settings.RotationAngle * input.x, 0));
                    body.rotation = Quaternion.Lerp((Quaternion)body.rotation, wantedRotation, Time.deltaTime * _settings.RotationSpeed);
                }
                //Lerp between current velocity and wanted velocity .                
                body.velocity = Vector3.Lerp((Vector3)body.velocity, slopeDirection * _settings.MaxSpeed, _settings.Acceleration * Time.deltaTime);

            }
        }

    }
}
