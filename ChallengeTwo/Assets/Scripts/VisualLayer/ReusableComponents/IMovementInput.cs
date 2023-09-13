using UnityEngine;

namespace ChallengeTwo.VisualLayer.ReusableComponents
{
    public interface IMovementInput
    {
        //gets  input for movement components.
        Vector2 GetInput();
    }
}
