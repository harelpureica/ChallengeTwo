using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.InfrastrucutreLayer.TimeManaging
{
    //this interface is reponsible for providing time related events.
    public interface ITimeManager
    {
        //invoked every frame,like Update.
        event Action OnTick;

        //invoked every fixed ms,like FixedUpdate.
        event Action OnFixedTick;

        //invoked every frame after OnTick,like LateUpdate.

        event Action OnLateTick;
    }
}
