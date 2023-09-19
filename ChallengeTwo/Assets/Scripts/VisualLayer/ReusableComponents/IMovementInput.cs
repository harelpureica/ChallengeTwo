using UnityEngine;

namespace ChallengeTwo.VisualLayer.ReusableComponents
{
    //this interface is responsible for providing input for movement component.

    public interface IMovementInput
    {
        //gets  input for movement components.
        Vector2 GetInput();
    }
}
