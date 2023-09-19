using UnityEngine;

namespace ChallengeTwo.VisualLayer.Menus.Installers
{
    //this class is responsible for installing the scanning menu .

    public class ScaningMenuInstaller:MenuBaseInstaller
    {
        #region Fields
        //the scaning menu component.
        [SerializeField]
        private ScaningMenu menu;
        #endregion

        #region Methods
        //binds the base class  bindings and the IScanningMenu interface to the menu. 
        public override void InstallBindings()
        {
            base.InstallBindings();

            Container
                .Bind<IScanningMenu>()
                .FromInstance(menu)
                .AsSingle();

        }
        #endregion
    }
}
