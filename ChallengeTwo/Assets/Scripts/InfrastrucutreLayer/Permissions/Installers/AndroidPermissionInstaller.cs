using Zenject;

namespace ChallengeTwo.InfrastrucutreLayer.Permissions.Installers
{
    public class AndroidPermissionInstaller:MonoInstaller<AndroidPermissionInstaller>
    {
        #region Methods
        public override void InstallBindings()
        {
            Container
                 .Bind<AndroidPermissions>()
                 .AsSingle();             
        }
        #endregion
    }
}
