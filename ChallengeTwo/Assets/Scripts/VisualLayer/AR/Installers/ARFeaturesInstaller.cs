using Zenject;

namespace ChallengeTwo.VisualLayer.AR.Installers
{
    //this class is responsible for installing arFeaturesManager.
    public class ARFeaturesInstaller : MonoInstaller<ARFeaturesInstaller>
    {
        #region Methods
        //binds ar feature manager and his  interfaces (iinitializable for initializing on start) .
        public override void InstallBindings()
        {                               
            Container
               .BindInterfacesAndSelfTo<ARFeaturesManager>()               
               .AsSingle();           
        }

        #endregion
    }
}
