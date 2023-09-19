
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace ChallengeTwo.InfrastrucutreLayer.Inputs
{
    //InputManager serves as the main  user input provider for all input consumers.
    public class InputManager:IInputManager
    {
        #region Methods
        //returns true if the player  clicks on the screen,for testing it works also for pc and phones.
        public bool IsClicking()
        {
            var isclicking = false;

            if(EventSystem.current!=null&& EventSystem.current.IsPointerOverGameObject())
            {
                return isclicking;
            }
            if(SystemInfo.deviceType==DeviceType.Handheld)
            {
                if(Input.touchCount>0)
                {
                    if (Input.touches[0].phase == TouchPhase.Began)
                    {
                        isclicking = true;
                    } 
                }
               
            }else
            {
                isclicking=Input.GetKeyDown(KeyCode.Mouse0);
            }
            return isclicking;
        }

        //returns true if the player  is touching the screen,for testing it works also for pc and phones.

        public bool IsPressing()
        {
            var isPressing = false;           
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                if (Input.touchCount > 0)
                {
                    isPressing = true;                    
                }

            }
            else
            {
                isPressing = Input.GetKey(KeyCode.Mouse0);
            }
            return isPressing;
        }

        //returns the players touch position ,for testing it works also for pc and phones.
        public Vector2 GetMousePosition()
        {
            var mousePosition = Vector2.zero;
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                if(Input.touchCount > 0)
                {
                    mousePosition = Input.touches[0].position;
                }
            }
            else
            {
                mousePosition = (Vector2)Input.mousePosition;
            }
            return mousePosition;
        }

        //returns the players nearest touch position given a screen space postion ,
        //if player dosent touch the screen it return vector2.zero ,
        //used for holding buttons to check if player still holding the button
        //for testing it works also for pc and phones.

        public Vector2 GetNearestTouchPosition(Vector2 mousePosition)
        {
            var touchPosition = Vector2.zero;
            var minDistace = float.MaxValue;
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {                
                for (int i = 0; i < Input.touchCount; i++)
                {
                    var distance=Vector2.Distance(Input.touches[i].position, mousePosition);
                    if(minDistace>distance)
                    {
                        minDistace = distance;
                        touchPosition = Input.touches[i].position;
                    }
                }               
            }
            else
            {
                touchPosition = (Vector2)Input.mousePosition;
            }
            return touchPosition;
        }

        #endregion
    }
}
