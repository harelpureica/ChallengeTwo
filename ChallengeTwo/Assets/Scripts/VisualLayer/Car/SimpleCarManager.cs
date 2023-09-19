using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    //this class is responsible for managing the simple car componets.

    public class SimpleCarManager : CarManagerBase
    {
        #region Fields   

        // a reference to the simple Car procedural Animaton component

        [Inject]
        private ICarProceduralAnimation _proceduralAnimaton;

        #endregion

        #region Methods  
        //using base class method to move the car.
        //tells the procedural Animaton component to animate the cars wheels and body by velocity and direction.
        protected override void Update()
        {
            base.Update();        
            _proceduralAnimaton.AnimateCarBody(_rb);
            _proceduralAnimaton.AnimateCarWheels(_rb.velocity, transform.forward);
        }       
        #endregion
    }
}
