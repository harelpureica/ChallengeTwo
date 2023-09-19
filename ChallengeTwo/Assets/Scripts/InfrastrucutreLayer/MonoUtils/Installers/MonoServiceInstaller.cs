using Zenject;
using UnityEngine;

namespace ChallengeTwo.InfrastrucutreLayer.MonoUtils.Installers
{
    //this class is responsible for Installing the mono service component.
    [CreateAssetMenu(fileName = "MonoServiceInstaller",menuName = "Installers/MonoServiceInstaller")]
    public class MonoServiceInstaller:ScriptableObjectInstaller<MonoServiceInstaller>
    {
        #region Fields
        //the prefab with the monoService component.
        [SerializeField]
        private MonoService _monoServicePrefab;
        #endregion

        #region Methods
        //installs monoService component.
        public override void InstallBindings()
        {
            Container
                .Bind<MonoService>()
                .FromComponentInNewPrefab(_monoServicePrefab)
                .AsSingle();
        }
        #endregion
    }
}
