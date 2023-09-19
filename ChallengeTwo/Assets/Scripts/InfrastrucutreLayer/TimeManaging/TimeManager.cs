using System;
using Zenject;

namespace ChallengeTwo.InfrastrucutreLayer.TimeManaging
{
    //this class is reponsible for managing and providing time related events .

    public class TimeManager : ITimeManager, ITickable, IFixedTickable, ILateTickable
    {
        #region Events
        //invoked every frame .
        public event Action OnTick;

        //invoked every fixed ms , like FixedUpdate.
        public event Action OnFixedTick;

        //invoked every frame after OnTick .

        public event Action OnLateTick;

        #endregion

        #region Methods
        //invokes the events.

        public void Tick()
        {
            OnTick?.Invoke();            
        }
        public void LateTick()
        {
            OnLateTick?.Invoke();
        }
        public void FixedTick()
        {
            OnFixedTick?.Invoke();
        }

        #endregion
    }
}
