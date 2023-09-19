using UnityEngine;

namespace ChallengeTwo.InfrastrucutreLayer.Inputs
{
    //this interface is responsible for getting user input.

    public interface IInputManager
    {
        //returns true if players clickes on the screen.
        bool IsClicking();

        //returns the mouse/touch position in screen space.
        Vector2 GetMousePosition();

        //returns true if player touches screen.
        bool IsPressing();

        //returns the nearest touch from screen space position .
        Vector2 GetNearestTouchPosition(Vector2 mousePosition);
    }
}
