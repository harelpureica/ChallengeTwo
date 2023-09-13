using UnityEngine;

namespace ChallengeTwo.VisualLayer.ReusableComponents
{
    public interface IMoveByInput
    {
        //moves rigidbody by input.
        void Move(Vector2 input,Rigidbody body);
    }
}
