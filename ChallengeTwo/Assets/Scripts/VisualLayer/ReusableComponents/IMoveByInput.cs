using UnityEngine;

namespace ChallengeTwo.VisualLayer.ReusableComponents
{
    //this interface is responsible for  moving rigidbodys  by input.

    public interface IMoveByInput
    {
        //moves rigidbody by input.
        void Move(Vector2 input,Rigidbody body);
    }
}
