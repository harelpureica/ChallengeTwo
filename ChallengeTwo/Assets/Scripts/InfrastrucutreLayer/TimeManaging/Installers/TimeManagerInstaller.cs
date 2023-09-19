using ChallengeTwo.InfrastrucutreLayer.TimeManaging;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.InfrastrucutreLayer.TimeManaging.Installers
{
    //this class responsible for installing timeManager.
    [CreateAssetMenu(fileName = "TimeManagerInstaller",menuName = "Installers/TimeManagerInstaller")]
    public class TimeManagerInstaller:ScriptableObjectInstaller<TimeManagerInstaller>
    {
        #region Methods
        //Binds time manager  and his interfaces .
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<TimeManager>()                
                .AsSingle();
        }
        #endregion
    }
}
