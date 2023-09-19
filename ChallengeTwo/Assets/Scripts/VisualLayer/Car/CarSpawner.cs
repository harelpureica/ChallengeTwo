using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car
{
    //this class is responsible for spawning the simple car.

    public class CarSpawner
    {
        #region Injects
        //the factory for creating CarManagers.
        [Inject]
        private CarManagerBase.CarManagerFactory _factory;
        
        #endregion

        #region Methods 
        //tries to spawn the carManager using ray casts.
        public  CarManagerBase TrySpawnCar(float rayDistance,Vector2 screenPosition)
        {
            var ray = Camera.main.ScreenPointToRay(screenPosition);
            if(Physics.Raycast(ray,out var hit,rayDistance))
            {
                var angleDifferancesFromUp=Vector3.Angle(hit.normal,Vector3.up);
                if(Mathf.Abs(angleDifferancesFromUp) <45)
                {
                    var car = _factory.Create();
                    car.transform.rotation = Quaternion.LookRotation(Vector3.forward, hit.normal);
                    car.transform.position = hit.point + new Vector3(0, 0.1f, 0);
                    return car;
                }               
            }
            return null;
          
        }
        #endregion
    }
}
